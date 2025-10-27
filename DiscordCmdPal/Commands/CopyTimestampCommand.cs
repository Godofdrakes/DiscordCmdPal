using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace DiscordCmdPal.Commands;

public sealed partial class CopyTimestampCommand : InvokableCommand
{
	[StringSyntax( StringSyntaxAttribute.CompositeFormat )]
	public string Format { get; set; }

	public DateTime DateTime { get; set; }

	public IFormatProvider? FormatProvider { get; set; }

	public CommandResult Result { get; set; }

	public CopyTimestampCommand()
	{
		Format = "{0}";
		DateTime = DateTime.Now;
		FormatProvider = CultureInfo.CurrentCulture;

		var toast = new ToastArgs
		{
			Message = "Copied to clipboard",
			Result = CommandResult.Dismiss(),
		};

		Result = CommandResult.ShowToast( toast );
	}

	public override ICommandResult Invoke()
	{
		var str = string.Format( FormatProvider, Format, DateTime );

		ClipboardHelper.SetText( str );

		return Result;
	}
}