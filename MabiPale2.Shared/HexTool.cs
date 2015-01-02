using System;
using System.Text;

namespace MabiPale2.Shared
{
	public static class HexTool
	{
		/// <summary>
		/// Converts hex string to byte array. Hex string must be valid
		/// (no spaces, even number of characters, etc).
		/// </summary>
		/// <param name="hex"></param>
		/// <returns></returns>
		public static byte[] ToByteArray(string hex)
		{
			if (hex.Length % 2 != 0)
				throw new Exception("Expected an even amount of characters.");

			var result = new byte[hex.Length / 2];

			for (int i = 0; i < hex.Length; i += 2)
				result[i / 2] = (byte)((HexCharToInt(hex[i]) << 4) | HexCharToInt(hex[i + 1]));

			return result;
		}

		/// <summary>
		/// Converts hex character to int.
		/// </summary>
		/// <param name="chr"></param>
		/// <returns></returns>
		private static int HexCharToInt(char chr)
		{
			if (chr >= 'a' && chr <= 'f')
				return chr - 'a' + 10;
			if (chr >= 'A' && chr <= 'F')
				return chr - 'A' + 10;
			if (chr >= '0' && chr <= '9')
				return chr - '0';

			throw new Exception("Invalid hex character.");
		}

		/// <summary>
		/// Converts byte array to hex string.
		/// </summary>
		/// <param name="arr"></param>
		/// <returns></returns>
		public static string ToString(byte[] arr)
		{
			var sb = new StringBuilder();

			foreach (var b in arr)
				sb.Append(b.ToString("X2"));

			return sb.ToString();
		}
	}
}
