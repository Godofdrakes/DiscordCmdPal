using System;
using System.Text.Json.Serialization;
using DiscordCmdPal.Forms;

namespace DiscordCmdPal.Serialization;

[JsonSerializable( typeof(DateAndTime) )]
[JsonSerializable( typeof(DateOnly) )]
[JsonSerializable( typeof(TimeOnly) )]
[JsonSerializable( typeof(long) )]
[JsonSerializable( typeof(int) )]
internal sealed partial class DateAndTimeContext : JsonSerializerContext;