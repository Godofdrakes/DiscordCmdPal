namespace DiscordCmdPal.Core.Format;

public class RelativeTimeSpanFormatProvider : IFormatProvider
{
	public static RelativeTimeSpanFormatProvider Instance { get; } = new();

	private RelativeTimeSpanFormatter CustomFormatter { get; } = new();

	public object? GetFormat( Type? formatType )
	{
		if ( formatType == typeof(ICustomFormatter) )
		{
			return CustomFormatter;
		}

		return null;
	}
}