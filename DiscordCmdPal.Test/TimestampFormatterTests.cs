using DiscordCmdPal.Core;
using DiscordCmdPal.Core.Format;

namespace DiscordCmdPal.Test;

public class TimestampFormatterTests
{
	// October 19th, 2025 9:00 AM
	private static DateTime TestTime { get; } = new( 2025, 10, 19, 9, 0, 0 );

	[Test]
	public void ShortTime()
	{
		var provider = new TimeStampFormatProvider();
		var str = string.Format( provider, "{0:t}", TimeStamp.FromDateTime( TestTime ) );

		TestContext.Out.WriteLine( str );

		Assert.That( str, Is.EqualTo( "<t:1760889600:t>" ) );
	}

	[Test]
	public void LongTime()
	{
		var provider = new TimeStampFormatProvider();
		var str = string.Format( provider, "{0:T}", TimeStamp.FromDateTime( TestTime ) );

		TestContext.Out.WriteLine( str );

		Assert.That( str, Is.EqualTo( "<t:1760889600:T>" ) );
	}

	[Test]
	public void ShortDate()
	{
		var provider = new TimeStampFormatProvider();
		var str = string.Format( provider, "{0:d}", TimeStamp.FromDateTime( TestTime ) );

		TestContext.Out.WriteLine( str );

		Assert.That( str, Is.EqualTo( "<t:1760889600:d>" ) );
	}

	[Test]
	public void LongDate()
	{
		var provider = new TimeStampFormatProvider();
		var str = string.Format( provider, "{0:D}", TimeStamp.FromDateTime( TestTime ) );

		TestContext.Out.WriteLine( str );

		Assert.That( str, Is.EqualTo( "<t:1760889600:D>" ) );
	}

	[Test]
	public void ShortDateTime()
	{
		var provider = new TimeStampFormatProvider();
		var str = string.Format( provider, "{0:f}", TimeStamp.FromDateTime( TestTime ) );

		TestContext.Out.WriteLine( str );

		Assert.That( str, Is.EqualTo( "<t:1760889600:f>" ) );
	}

	[Test]
	public void LongDateTime()
	{
		var provider = new TimeStampFormatProvider();
		var str = string.Format( provider, "{0:F}", TimeStamp.FromDateTime( TestTime ) );

		TestContext.Out.WriteLine( str );

		Assert.That( str, Is.EqualTo( "<t:1760889600:F>" ) );
	}

	[Test]
	public void Relative()
	{
		var provider = new TimeStampFormatProvider();
		var str = string.Format( provider, "{0:R}", TimeStamp.FromDateTime( TestTime ) );

		TestContext.Out.WriteLine( str );

		Assert.That( str, Is.EqualTo( "<t:1760889600:R>" ) );
	}

	[Test]
	public void None()
	{
		var provider = new TimeStampFormatProvider();
		var str = string.Format( provider, "{0}", TimeStamp.FromDateTime( TestTime ) );

		TestContext.Out.WriteLine( str );
	}
}