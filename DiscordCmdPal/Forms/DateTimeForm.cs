using System;
using System.Text.Json;
using DiscordCmdPal.Serialization;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace DiscordCmdPal.Forms;

internal struct DateAndTime
{
	public DateOnly Date { get; set; }

	public TimeOnly Time { get; set; }

	public DateTime DateTime => new( Date, Time );

	public static DateAndTime FromDateTime( DateTime dateTime )
	{
		return new DateAndTime
		{
			Date = DateOnly.FromDateTime( dateTime ),
			Time = TimeOnly.FromDateTime( dateTime ),
		};
	}

	public static DateAndTime Now => FromDateTime( DateTime.Now );
	public static DateAndTime UtcNow => FromDateTime( DateTime.UtcNow );

	public override string ToString()
	{
		return $$"""{"Date": "{{Date:yyy-MM-dd}}","Time": "{{Time:HH:mm}}"}""";
	}
}

internal sealed partial class DateTimeForm : FormCommon
{
	private DateAndTime _dateAndTime;

	public DateAndTime DateAndTime
	{
		get => _dateAndTime;
		set
		{
			_dateAndTime = value;

			DataJson = value.ToString();

			ClipboardHelper.SetText( DataJson );
		}
	}

	public DateTimeForm()
	{
		TemplateJson = """
		               {
		                   "type": "AdaptiveCard",
		                   "$schema": "https://adaptivecards.io/schemas/adaptive-card.json",
		                   "version": "1.5",
		                   "body": [
		                       {
		                           "type": "Input.Date",
		                           "label": "Date",
		                           "isRequired": true,
		                           "errorMessage": "Please enter a date",
		                           "id": "Date",
		                           "value": "${Date}"
		                       },
		                       {
		                           "type": "Input.Time",
		                           "label": "Time",
		                           "isRequired": true,
		                           "errorMessage": "Please enter a time",
		                           "id": "Time",
		                           "value": "${Time}"
		                       },
		                       {
		                           "type": "ActionSet",
		                           "actions": [
		                               {
		                                   "type": "Action.Submit",
		                                   "title": "Submit",
		                                   "style": "positive",
		                                   "tooltip": "Submit form"
		                               }
		                           ],
		                           "spacing": "ExtraLarge"
		                       }
		                   ]
		               }
		               """;

		DateAndTime = DateAndTime.Now;
	}

	public override ICommandResult SubmitForm( string inputs )
	{
		_dateAndTime = JsonSerializer.Deserialize( inputs, DateAndTimeContext.Default.DateAndTime );

		return base.SubmitForm( inputs );
	}
}