using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Darkit.MySQL.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("开始");
            MySQLDll.Initialize();
            IntPtr mysql = MySQLDll.Init(IntPtr.Zero);

            MySQLDll.RealConnect(mysql, "127.0.0.1", "root", "password", null, 3306, null, 0);
            int result = MySQLDll.Query(mysql, "CREATE DATABASE IF NOT EXISTS darkit DEFAULT CHARSET utf8mb4 COLLATE utf8mb4_unicode_ci;");
            Console.WriteLine(result);
            MySQLDll.Close(mysql);
            Console.WriteLine("结束");
            Console.ReadKey();
        }
    }
}
