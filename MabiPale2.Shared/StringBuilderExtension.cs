using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MabiPale2.Shared
{
	public static class StringBuilderExtension
	{
		public static void AppendLine(this StringBuilder sb, string format, params object[] args)
		{
			sb.AppendLine(string.Format(CultureInfo.InvariantCulture, format, args));
		}

		public static void Append(this StringBuilder sb, string format, params object[] args)
		{
			sb.Append(string.Format(CultureInfo.InvariantCulture, format, args));
		}
	}
}
