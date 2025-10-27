using System.Globalization;
using System.Text.Json;

namespace DiscordCmdPal.Test;

[TestFixture]
public class DateTimeParsingTests
{

	[Test]
	public void DateAndTime()
	{
		var input = """{"Date":"2025-10-24","Time":"05:56"}""";

		using var document = JsonDocument.Parse( input );

		var dateInput = document.RootElement.GetProperty( "Date" ).GetString();
		var timeInput = document.RootElement.GetProperty( "Time" ).GetString();

		var date = DateOnly.ParseExact( dateInput!, "yyyy-MM-dd", CultureInfo.InvariantCulture );
		var time = TimeOnly.ParseExact( timeInput!, "HH:mm", CultureInfo.InvariantCulture );

		var dateTime = new DateTime( date, time );

		TestContext.Out.WriteLine( $"{dateTime}" );

		Assert.That( dateTime, Is.EqualTo( new DateTime( 2025, 10, 24, 05, 56, 0 ) ) );
	}
}