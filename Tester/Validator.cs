using System.Security.Cryptography;
using System.Text;

namespace Tester
{
	internal static class Validator
	{
		public static byte[] Hash(string password) => SHA512.HashData(Encoding.UTF8.GetBytes(password));

		public static string ToPostgreByteaLiteral(byte[] data)
		{
			var hex = BitConverter.ToString(data).Replace("-", "").ToLowerInvariant();
			return $"E'\\\\x{hex}'";
		}
	}
}
