using System;
using System.Threading;
using System.Threading.Tasks;
using DiscordCmdPal.Forms;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace DiscordCmdPal.Pages;

internal sealed partial class SubmitDateTimeArgs : EventArgs
{
	public required DateTime DateTime { get; init; }
}

internal sealed partial class DateTimePage : ContentPage
{
	public event EventHandler<SubmitDateTimeArgs>? OnSubmitDateTime;

	private readonly DateTimeForm _dateTimeForm;

	public DateTimePage()
	{
		_dateTimeForm = new DateTimeForm();
		_dateTimeForm.OnSubmitForm += OnSubmitForm;
	}

	private void OnSubmitForm( object? sender, SubmitFormArgs args )
	{
		try
		{
			var outArgs = new SubmitDateTimeArgs
			{
				DateTime = _dateTimeForm.DateAndTime.DateTime,
			};

			OnSubmitDateTime?.Invoke( this, outArgs );
		}
		catch ( Exception e )
		{
			ClipboardHelper.SetText( e.ToString() );

			var errorStatus = new StatusMessage()
			{
				Message = e.ToString(),
				State = MessageState.Error,
			};

			ExtensionHost.ShowStatus( errorStatus, StatusContext.Page );

			_ = Task.Run( () =>
			{
				Thread.Sleep( TimeSpan.FromSeconds( 7.5 ) );

				ExtensionHost.HideStatus( errorStatus );
			} );
		}
	}

	public override IContent[] GetContent()
	{
		_dateTimeForm.DateAndTime = DateAndTime.Now;

		return [_dateTimeForm];
	}
}