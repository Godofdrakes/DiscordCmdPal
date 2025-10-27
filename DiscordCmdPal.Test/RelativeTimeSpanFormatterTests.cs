using DiscordCmdPal.Core.Format;

namespace DiscordCmdPal.Test;

[TestFixture]
public class RelativeTimeSpanFormatterTests
{
	[Test]
	public void JustNow()
	{
		var timeSpan = TimeSpan.Zero;
		var formatProvider = new RelativeTimeSpanFormatProvider();
		var str = string.Format( formatProvider, "{0:R}", timeSpan );
		TestContext.Out.WriteLine( str );
		Assert.That( str, Is.EqualTo( "just now" ) );
	}

	[Test]
	public void OneSecondAgo()
	{
		var timeSpan = TimeSpan.FromSeconds( -1 );
		var formatProvider = new RelativeTimeSpanFormatProvider();
		var str = string.Format( formatProvider, "{0:R}", timeSpan );
		TestContext.Out.WriteLine( str );
		Assert.That( str, Is.EqualTo( "1 second ago" ) );
	}

	[Test]
	public void OneSecondFromNow()
	{
		var timeSpan = TimeSpan.FromSeconds( 1 );
		var formatProvider = new RelativeTimeSpanFormatProvider();
		var str = string.Format( formatProvider, "{0:R}", timeSpan );
		TestContext.Out.WriteLine( str );
		Assert.That( str, Is.EqualTo( "1 second from now" ) );
	}

	[Test]
	public void TwoMinutesAgo()
	{
		var timeSpan = TimeSpan.FromMinutes( -2 );
		var formatProvider = new RelativeTimeSpanFormatProvider();
		var str = string.Format( formatProvider, "{0:R}", timeSpan );
		TestContext.Out.WriteLine( str );
		Assert.That( str, Is.EqualTo( "2 minutes ago" ) );
	}

	[Test]
	public void TwoMinutesFromNow()
	{
		var timeSpan = TimeSpan.FromMinutes( 2 );
		var formatProvider = new RelativeTimeSpanFormatProvider();
		var str = string.Format( formatProvider, "{0:R}", timeSpan );
		TestContext.Out.WriteLine( str );
		Assert.That( str, Is.EqualTo( "2 minutes from now" ) );
	}

	[Test]
	public void ThreeHoursAgo()
	{
		var timeSpan = TimeSpan.FromHours( -3 );
		var formatProvider = new RelativeTimeSpanFormatProvider();
		var str = string.Format( formatProvider, "{0:R}", timeSpan );
		TestContext.Out.WriteLine( str );
		Assert.That( str, Is.EqualTo( "3 hours ago" ) );
	}

	[Test]
	public void ThreeHoursFromNow()
	{
		var timeSpan = TimeSpan.FromHours( 3 );
		var formatProvider = new RelativeTimeSpanFormatProvider();
		var str = string.Format( formatProvider, "{0:R}", timeSpan );
		TestContext.Out.WriteLine( str );
		Assert.That( str, Is.EqualTo( "3 hours from now" ) );
	}

	[Test]
	public void FourDaysAgo()
	{
		var timeSpan = TimeSpan.FromDays( -4 );
		var formatProvider = new RelativeTimeSpanFormatProvider();
		var str = string.Format( formatProvider, "{0:R}", timeSpan );
		TestContext.Out.WriteLine( str );
		Assert.That( str, Is.EqualTo( "4 days ago" ) );
	}

	[Test]
	public void FourDaysFromNow()
	{
		var timeSpan = TimeSpan.FromDays( 4 );
		var formatProvider = new RelativeTimeSpanFormatProvider();
		var str = string.Format( formatProvider, "{0:R}", timeSpan );
		TestContext.Out.WriteLine( str );
		Assert.That( str, Is.EqualTo( "4 days from now" ) );
	}

	[Test]
	public void FiveMonthsAgo()
	{
		var timeSpan = TimeSpan.FromDays( 31 * -5 );
		var formatProvider = new RelativeTimeSpanFormatProvider();
		var str = string.Format( formatProvider, "{0:R}", timeSpan );
		TestContext.Out.WriteLine( str );
		Assert.That( str, Is.EqualTo( "5 months ago" ) );
	}

	[Test]
	public void FiveMonthsFromNow()
	{
		var timeSpan = TimeSpan.FromDays( 31 * 5 );
		var formatProvider = new RelativeTimeSpanFormatProvider();
		var str = string.Format( formatProvider, "{0:R}", timeSpan );
		TestContext.Out.WriteLine( str );
		Assert.That( str, Is.EqualTo( "5 months from now" ) );
	}

	[Test]
	public void SixYearsAgo()
	{
		var timeSpan = TimeSpan.FromDays( 365 * -6 );
		var formatProvider = new RelativeTimeSpanFormatProvider();
		var str = string.Format( formatProvider, "{0:R}", timeSpan );
		TestContext.Out.WriteLine( str );
		Assert.That( str, Is.EqualTo( "6 years ago" ) );
	}

	[Test]
	public void SixYearsFromNow()
	{
		var timeSpan = TimeSpan.FromDays( 365 * 6 );
		var formatProvider = new RelativeTimeSpanFormatProvider();
		var str = string.Format( formatProvider, "{0:R}", timeSpan );
		TestContext.Out.WriteLine( str );
		Assert.That( str, Is.EqualTo( "6 years from now" ) );
	}
}