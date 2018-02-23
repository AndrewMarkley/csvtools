using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsvTools
{
    public class CsvTable : IEnumerable<CsvRow>
    {
        private List<CsvHeader> _headers = new List<CsvHeader>();
        private List<CsvRow> _rows = new List<CsvRow>();

        public CsvRow this[int index]
        {
            get
            {
                return _rows[index];
            }
        }
        public int NumColumns
        {
            get
            {
                return _headers.Count;
            }
        }
        public int NumRows
        {
            get
            {
                return _rows.Count;
            }
        }

        public byte[] ExportTable(Encoding encoding)
        {
            StringBuilder sb = new StringBuilder();

            string headersAsRow = string.Join(",", _headers.Select(t => t.CsvSafeToString()));
            sb.AppendLine(headersAsRow);

            foreach (var row in _rows) {
                sb.AppendLine(row.CsvSafeToString());
            }

            byte[] result = encoding.GetBytes(sb.ToString());

            return result;
        }

        public bool HasColumn(string name)
        {
            return _headers.Any(t => t.Name == name);
        }

        public CsvHeader GetHeader(int index)
        {
            if (!_headers.Any() || _headers.Count < index) {
                throw new IndexOutOfRangeException();
            }

            return _headers[index];
        }

        public CsvHeader GetHeader(string name)
        {
            return _headers.FirstOrDefault(t => t.Name == name);
        }

        public IEnumerator<CsvRow> GetEnumerator()
        {
            return _rows.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _rows.GetEnumerator();
        }

        internal void AddHeader(CsvHeader header)
        {
            _headers.Add(header);
        }

        public void AddHeader(string header)
        {
            if (header == null) {
                throw new ArgumentNullException();
            }

            _headers.Add(new CsvHeader(_headers.Count, header));
        }

        public void AddHeaders(List<string> headers)
        {
            for (int i = 0; i < headers.Count; ++i) {
                _headers.Add(new CsvHeader(_headers.Count + i, headers[i]));
            }
        }

        public void AddRow(string[] row)
        {
            _rows.Add(new CsvRow(row, this));
        }

        public void AddRow(List<string> row)
        {
            AddRow(row.ToArray());
        }
    }
}
