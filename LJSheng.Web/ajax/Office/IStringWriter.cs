using System;

namespace LJSheng.Web
{
    internal interface IStringWriter
    {
        void WriteLine();
        void Write(String str);
        void Write(Char c);
    }
}
