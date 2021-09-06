using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Darkit.MySQL.Properties;

namespace Darkit.MySQL
{
    public static class MySQLDll
    {
        [DllImport("libmysql", EntryPoint = "mysql_init")]
        public extern static IntPtr Init(IntPtr mysql);

        [DllImport("libmysql", EntryPoint = "mysql_close")]
        public extern static void Close(IntPtr mysql);

        [DllImport("libmysql", EntryPoint = "mysql_kill")]
        public extern static int Kill(IntPtr mysql, ulong pid); 

        [DllImport("libmysql", EntryPoint = "mysql_ping")]
        public extern static int Ping(IntPtr mysql);

        [DllImport("libmysql", EntryPoint = "mysql_errno")]
        public extern static int ErrNo(IntPtr mysql);

        [DllImport("libmysql", EntryPoint = "mysql_error")]
        public extern static IntPtr Error(IntPtr mysql);

        [DllImport("libmysql", EntryPoint = "mysql_options")]
        public extern static int Options(IntPtr mysql, byte name, IntPtr arg);

        [DllImport("libmysql", EntryPoint = "mysql_query")]
        public extern static int Query(IntPtr mysql, string sql);

        [DllImport("libmysql", EntryPoint = "mysql_real_connect")]
        public extern static IntPtr RealConnect(IntPtr mysql, string host, string user, string password, string dbname, ushort port, string socket, ulong clientFlag);

        [DllImport("libmysql", EntryPoint = "mysql_real_query")]
        public extern static int RealQuery(IntPtr mysql, byte[] sql, long length);

        /**
         * 预处理
         */

        [DllImport("libmysql", EntryPoint = "mysql_stmt_init")]
        public extern static IntPtr StmtInit(IntPtr mysql);

        [DllImport("libmysql", EntryPoint = "mysql_stmt_prepare")]
        public extern static int StmtPrepare(IntPtr stmt, byte[] sql, ulong length);

        public static void Initialize()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "libmysql.dll");
            string prefix = Path.GetFileNameWithoutExtension(path).Replace('.', '_');
            string tag = IntPtr.Size == 8 ? "winx64" : "winx32";
            string field = string.Format("{0}_{1}", prefix, tag);
            byte[] data = Resources.ResourceManager.GetObject(field) as byte[];
            File.WriteAllBytes(path, data);
        }

        public static string GetError(IntPtr mysql)
        {
            IntPtr ep = Error(mysql);
            return Marshal.PtrToStringAnsi(ep);
        }
    }
}
