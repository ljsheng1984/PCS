using System;

namespace LJSheng.Web
{
    /// <summary>
    /// 导出列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExportColumn<T> : IExportColumn<T>
    {
        public ExportColumn(String title, Func<T, Int32, Object> funcGetValue)
        {
            if (String.IsNullOrEmpty(title)) throw new ArgumentNullException("title");
            if (funcGetValue == null) throw new ArgumentNullException("funcGetValue");
            this.Title = title;
            this._funcGetValue = funcGetValue;
        }

        private readonly Func<T, Int32, Object> _funcGetValue;
        public string Title { get; private set; }

        public object GetValue(T row, int index)
        {
            return this._funcGetValue(row, index);
        }
    }
}
