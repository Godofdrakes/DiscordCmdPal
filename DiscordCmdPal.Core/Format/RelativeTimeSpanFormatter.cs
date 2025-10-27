namespace DiscordCmdPal.Core.Format;

public class RelativeTimeSpanFormatter : SimpleCustomFormatter<TimeSpan>
{
	public RelativeTimeSpanFormatter()
	{
		FormatFuncs.Add( "R", HandleRelativeFormat );
		FormatFuncs.Add( "r", HandleRelativeFormat );
	}

	private static string HandleRelativeFormat( string? format, in TimeSpan timeSpan, IFormatProvider? formatProvider )
	{
		var abs = timeSpan.Duration();

		if ( abs < TimeSpan.FromSeconds( 1 ) )
		{
			return "just now";
		}

		var suffix = timeSpan.Ticks >= 0 ? "from now" : "ago";

		if ( abs < TimeSpan.FromSeconds( 60 ) )
		{
			var seconds = (int) abs.TotalSeconds;
			return $"{seconds} {(seconds > 1 ? "seconds" : "second")} {suffix}";
		}

		if ( abs < TimeSpan.FromMinutes( 60 ) )
		{
			var minutes = (int) abs.TotalMinutes;
			return $"{minutes} {(minutes > 1 ? "minutes" : "minute")} {suffix}";
		}

		if ( abs < TimeSpan.FromHours( 24 ) )
		{
			var hours = (int) abs.TotalHours;
			return $"{hours} {(hours > 1 ? "hours" : "hour")} {suffix}";
		}

		if ( abs < TimeSpan.FromDays( 31 ) )
		{
			var days = (int) abs.TotalDays;
			return $"{days} {(days > 1 ? "days" : "day")} {suffix}";
		}

		if ( abs < TimeSpan.FromDays( 365 ) )
		{
			var months = (int) abs.TotalDays / 31;
			return $"{months} {(months > 1 ? "months" : "month")} {suffix}";
		}

		var years = (int) abs.TotalDays / 365;
		return $"{years} {(years > 1 ? "years" : "year")} {suffix}";
	}
}