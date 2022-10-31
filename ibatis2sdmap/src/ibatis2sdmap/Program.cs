using System;
using System.IO;
using System.Linq;

namespace ibatis2sdmap;

internal class Program
{
	public static void Main(string[] args)
	{
		var converted = SdmapConverter.IBatisToSdmap(File.ReadAllText(args.First()));
		Console.WriteLine(converted);
	}
}