using System;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace DiscordCmdPal.Forms;

internal sealed partial class SubmitFormArgs : EventArgs
{
	public required string Inputs { get; init; }
}

internal abstract partial class FormCommon : FormContent
{
	public event EventHandler<SubmitFormArgs>? OnSubmitForm;

	public override ICommandResult SubmitForm( string inputs )
	{
		var args = new SubmitFormArgs()
		{
			Inputs = inputs
		};

		OnSubmitForm?.Invoke( this, args );

		return CommandResult.GoBack();
	}
}