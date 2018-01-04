using System;
using System.Data;

namespace LJSheng.Web
{
    public class DataRowExportColumn : IExportColumn<DataRow>
    {
        public DataRowExportColumn(String name)
            : this(name, String.Empty)
        {

        }

        public DataRowExportColumn(String name, String title)
            : this(name, title, null)
        {

        }
        public DataRowExportColumn(String name, String title, Func<Object, Int32, Object> funcFormatValue)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
            this.Name = name;
            this._title = title;
            this._funcFormatValue = funcFormatValue;
        }

        public String Name { get; private set; }
        private readonly String _title;
        private readonly Func<Object, Int32, Object> _funcFormatValue;
        public string Title
        {
            get { return String.IsNullOrEmpty(this._title) ? this.Name : this._title; }
        }

        public object GetValue(DataRow row, int index)
        {
            var val = row[this.Name];
            return this._funcFormatValue != null ? _funcFormatValue(val, index) : val;
        }
    }
}
