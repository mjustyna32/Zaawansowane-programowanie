using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaawansowane_programowanie
{
    public class Column
    {
        private List<bool> rows;
        private int columnIndex;

        public List<bool> GetRows 
        {
            set { }
            get { return rows; }

        }
        public int GetRowsCount
        {
            get { return rows.Count; }
        }
        public bool getRowValueAt(int index)
        {
            return rows.ElementAt(index);
        }
        public int ColumnIndex
        {
            get { return columnIndex; }
            set { }
        }
        public Column(int index)
        {
            columnIndex = index;
            rows = new List<bool>();
        }
        public void AddRow(string value)
        {
            if (value.IndexOf("1") >= 0)
            {
                rows.Add(true);
            }
            else if(value.IndexOf("0") >= 0)
            {
                rows.Add(false);
            }
        }
        public void CloneObject(Column col)
        {
            this.columnIndex = col.ColumnIndex;
            foreach(bool value in col.GetRows)
            {
                this.rows.Add(value);
            }
        }
        public string Show()
        {
            string s = "";
            foreach(bool val in rows)
            {
                s += " " + val;
            }
            return s;
        }
    }
}
