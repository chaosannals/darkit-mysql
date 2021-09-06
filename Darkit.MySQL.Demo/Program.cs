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

            IntPtr c = MySQLDll.RealConnect(mysql, "127.0.0.1", "root", "password", null, 3306, null, 8192);
            if (c == IntPtr.Zero)
            {
                Console.WriteLine("数据库连接失败");
                int errno = MySQLDll.ErrNo(mysql);
                string error = MySQLDll.GetError(mysql);
                Console.WriteLine(errno);
                Console.WriteLine(error);
            }
            byte[] sql = Encoding.UTF8.GetBytes("CREATE DATABASE IF NOT EXISTS darkit DEFAULT CHARSET utf8mb4 COLLATE utf8mb4_unicode_ci;");
            int result = MySQLDll.RealQuery(mysql, sql, sql.Length);
            if (result != 0)
            {
                Console.WriteLine(result);
                int errno = MySQLDll.ErrNo(mysql);
                string error = MySQLDll.GetError(mysql);
                Console.WriteLine(errno);
                Console.WriteLine(error);
            }
            //

            MySQLDll.Close(mysql);
            Console.WriteLine("结束");
            Console.ReadKey();
        }
    }
}
