namespace DiscordCmdPal.Core.Format;

public sealed partial class TimeStampFormatter : SimpleCustomFormatter<TimeStamp>
{
	public TimeStampFormatter()
	{
		FormatFuncs.Add( "t", HandleFormatShortTime );
		FormatFuncs.Add( "T", HandleFormatLongTime );
		FormatFuncs.Add( "d", HandleFormatShortDate );
		FormatFuncs.Add( "D", HandleFormatLongDate );
		FormatFuncs.Add( "f", HandleFormatShortDateTime );
		FormatFuncs.Add( "F", HandleFormatLongDateTime );
		FormatFuncs.Add( "R", HandleFormatRelative );
		FormatFuncs.Add( "r", HandleFormatRelative );
	}

	private static string HandleFormatShortTime( string? format, in TimeStamp timeStamp, IFormatProvider? formatProvider )
	{
		return string.Format( formatProvider, "<t:{0}:t>", timeStamp.TotalSeconds );
	}

	private static string HandleFormatLongTime( string? format, in TimeStamp timeStamp, IFormatProvider? formatProvider )
	{
		return string.Format( formatProvider, "<t:{0}:T>", timeStamp.TotalSeconds );
	}

	private static string HandleFormatShortDate( string? format, in TimeStamp timeStamp, IFormatProvider? formatProvider )
	{
		return string.Format( formatProvider, "<t:{0}:d>", timeStamp.TotalSeconds );
	}

	private static string HandleFormatLongDate( string? format, in TimeStamp timeStamp, IFormatProvider? formatProvider )
	{
		return string.Format( formatProvider, "<t:{0}:D>", timeStamp.TotalSeconds );
	}

	private static string HandleFormatShortDateTime( string? format, in TimeStamp timeStamp, IFormatProvider? formatProvider )
	{
		return string.Format( formatProvider, "<t:{0}:f>", timeStamp.TotalSeconds );
	}

	private static string HandleFormatLongDateTime( string? format, in TimeStamp timeStamp, IFormatProvider? formatProvider )
	{
		return string.Format( formatProvider, "<t:{0}:F>", timeStamp.TotalSeconds );
	}

	private static string HandleFormatRelative( string? format, in TimeStamp timeStamp, IFormatProvider? formatProvider )
	{
		return string.Format( formatProvider, "<t:{0}:R>", timeStamp.TotalSeconds );
	}
}