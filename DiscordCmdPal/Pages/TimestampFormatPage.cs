// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using DiscordCmdPal.Commands;
using DiscordCmdPal.Core;
using DiscordCmdPal.Core.Format;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace DiscordCmdPal.Pages;

internal sealed partial class TimestampFormatPage : ListPage
{
	private DateTime _dateTime;

	private IListItem[] _listItems = [];

	private readonly DateTimePage _dateTimePage = new();

	public TimestampFormatPage()
	{
		_dateTimePage.OnSubmitDateTime += ( _, args ) =>
		{
			_dateTime = args.DateTime;

			UpdateListItems();
		};

		_dateTime = DateTime.Now;

		UpdateListItems();
	}

	public override IListItem[] GetItems()
	{
		return _listItems;
	}

	private void UpdateListItems()
	{
		_listItems =
		[
			new ListItem()
			{
				Title = "Select a date and time",
				Icon = Icons.DateTime,
				Command = _dateTimePage,
			},
			new ListItem()
			{
				Title = $"{_dateTime:hh:mm tt}",
				Subtitle = "Short Time",
				Icon = Icons.Copy,
				Command = new CopyTextCommand( string.Format(
					TimeStampFormatProvider.Instance,
					"{0:t}",
					TimeStamp.FromDateTime( _dateTime ) ) )
			},
			new ListItem()
			{
				Title = $"{_dateTime:hh:mm:ss tt}",
				Subtitle = "Long Time",
				Icon = Icons.Copy,
				Command = new CopyTextCommand( string.Format(
					TimeStampFormatProvider.Instance,
					"{0:T}",
					TimeStamp.FromDateTime( _dateTime ) ) )
			},
			new ListItem()
			{
				Title = $"{_dateTime:M/d/yy}",
				Subtitle = "Short Date",
				Icon = Icons.Copy,
				Command = new CopyTextCommand( string.Format(
					TimeStampFormatProvider.Instance,
					"{0:d}",
					TimeStamp.FromDateTime( _dateTime ) ) )
			},
			new ListItem()
			{
				Title = $"{_dateTime:MMMM dd, yyyy}",
				Subtitle = "Long Date",
				Icon = Icons.Copy,
				Command = new CopyTextCommand( string.Format(
					TimeStampFormatProvider.Instance,
					"{0:D}",
					TimeStamp.FromDateTime( _dateTime ) ) )
			},
			new ListItem()
			{
				Title = $"{_dateTime:MMMM dd, yyyy a\\t hh:mm tt}",
				Subtitle = "Short Date Time",
				Icon = Icons.Copy,
				Command = new CopyTextCommand( string.Format(
					TimeStampFormatProvider.Instance,
					"{0:f}",
					TimeStamp.FromDateTime( _dateTime ) ) )
			},
			new ListItem()
			{
				Title = $"{_dateTime:dddd, MMMM dd, yyyy a\\t hh:mm tt}",
				Subtitle = "Long Date Time",
				Icon = Icons.Copy,
				Command = new CopyTextCommand( string.Format(
					TimeStampFormatProvider.Instance,
					"{0:F}",
					TimeStamp.FromDateTime( _dateTime ) ) )
			},
			new ListItem()
			{
				Title = string.Format( RelativeTimeSpanFormatProvider.Instance, "{0:R}", (_dateTime - DateTime.Now) ),
				Subtitle = "Relative",
				Icon = Icons.Copy,
				Command = new CopyTextCommand( string.Format(
					TimeStampFormatProvider.Instance,
					"{0:R}",
					TimeStamp.FromDateTime( _dateTime ) ) )
			},
		];

		RaiseItemsChanged();
	}
}