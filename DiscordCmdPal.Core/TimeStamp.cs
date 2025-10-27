using System.Diagnostics;

namespace DiscordCmdPal.Core;

[DebuggerDisplay("{TotalSeconds}")]
public struct TimeStamp
{
	public long TotalSeconds { get; set; }

	public override string ToString()
	{
		return $"TimeStamp = {{ {TotalSeconds} }}";
	}

	public static TimeStamp FromDateTime( DateTime dateTime )
	{
		return new TimeStamp()
		{
			TotalSeconds = new DateTimeOffset( dateTime ).ToUnixTimeSeconds(),
		};
	}
}