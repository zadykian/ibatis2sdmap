using System;
using System.IO;

namespace ibatis2sdmap
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var converted = SdmapConverter.IBatisToSdmap(
                File.ReadAllText(@"D:\Repository\Skipp\mobile-park\StandardDemo\MP.Model.ME\Config\SqlMapME.config"));
            Console.WriteLine(converted);
        }
    }
}
