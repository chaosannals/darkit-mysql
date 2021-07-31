using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Darkit.MySQL.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MySQLBind
    {
        public IntPtr LengthPtr; // unsign long *
        public IntPtr IsNullPtr; // char *
        public IntPtr Buffer; // void *
        public IntPtr ErrorPtr; // char *
        public IntPtr RowPtr; // unsigned char *
        public IntPtr StoreParamFunc; // void (*store_param_func)(NET *net, struct st_mysql_bind *param)
        public IntPtr FetchResultFunc; // void (*fetch_result)(struct st_mysql_bind *, MYSQL_FIELD *, unsigned char** row)
        public IntPtr SkipResultFunc; // (struct st_mysql_bind *, MYSQL_FIELD *, unsigned char** row)
        public ulong BufferLength;
        public ulong Offset;
        public ulong LengthValue;
        public uint ParamNumber;
        public uint PackLength;
        public MySQLFieldType BufferType;
        public bool ErrorValue;
        public bool IsUnsigned;
        public bool LongDataUsed;
        public bool IsNullValue;
        public IntPtr Extension;
    }
}
