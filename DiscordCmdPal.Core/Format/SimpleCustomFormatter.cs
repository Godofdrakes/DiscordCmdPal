namespace DiscordCmdPal.Core.Format;

public abstract partial class SimpleCustomFormatter<T> : ICustomFormatter
{
	public delegate string FormatFunc( string? format, in T? arg, IFormatProvider? formatProvider );

	protected Dictionary<string, FormatFunc> FormatFuncs { get; }

	protected FormatFunc? DefaultFormatFunc { get; set; }

	protected SimpleCustomFormatter( IEqualityComparer<string> equalityComparer )
	{
		FormatFuncs = new Dictionary<string, FormatFunc>( equalityComparer );
	}

	protected SimpleCustomFormatter() : this( StringComparer.InvariantCulture ) { }

	public string Format( string? format, object? arg, IFormatProvider? formatProvider )
	{
		if ( arg is T value )
		{
			if ( !string.IsNullOrEmpty( format ) )
			{
				if ( FormatFuncs.TryGetValue( format, out var func ) )
				{
					return func( format, value, formatProvider );
				}
			}

			if ( DefaultFormatFunc is not null )
			{
				return DefaultFormatFunc( format, value, formatProvider );
			}
		}

		// A simple fallback implementation

		if ( arg is IFormattable formattable )
		{
			return formattable.ToString( format, formatProvider );
		}

		return arg?.ToString() ?? string.Empty;
	}
}