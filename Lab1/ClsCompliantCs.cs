using Lab1Cl;
using System.Linq;

namespace Lab1
{
	internal class ClsCompliantCs : IClsCompliant
	{
		public int Average(int[] data)
		{
			return (int)data.Average();
		}

		public string Merge(char[] data)
		{
			return new string(data);
		}
	}
}
