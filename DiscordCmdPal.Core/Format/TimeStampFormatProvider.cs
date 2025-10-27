namespace DiscordCmdPal.Core.Format;

public sealed partial class TimeStampFormatProvider : IFormatProvider
{
	public static TimeStampFormatProvider Instance { get; } = new();

	private TimeStampFormatter CustomFormatter { get; } = new();

	public object? GetFormat( Type? formatType )
	{
		if ( formatType == typeof(ICustomFormatter) )
		{
			return CustomFormatter;
		}

		return null;
	}
}