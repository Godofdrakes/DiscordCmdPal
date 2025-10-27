using DiscordCmdPal.Pages;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace DiscordCmdPal;

public sealed partial class DiscordCmdPalCommandsProvider : CommandProvider
{
	private readonly ICommandItem[] _commands;

	public DiscordCmdPalCommandsProvider()
	{
		DisplayName = "Discord Commands";
		Icon = IconHelpers.FromRelativePath( "Assets\\StoreLogo.png" );
		_commands =
		[
			new CommandItem( new TimestampFormatPage() )
			{
				Title = "Generate Discord Timestamp",
				Icon = Icons.DateTime,
			},
		];
	}

	public override ICommandItem[] TopLevelCommands()
	{
		return _commands;
	}
}