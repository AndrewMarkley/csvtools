using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CsvTools
{
    public class CsvParser
    {
        private CsvTable _table;
        private StreamReader _reader;
        private readonly CsvParserOptions _options;

        private CsvParser(CsvParserOptions options)
        {
            _options = options;
        }

        public static CsvTable ParseTable(StreamReader stream)
        {
            return new CsvParser(new CsvParserOptions()).InternalParse(stream);
        }

        public static CsvTable ParseTable(StreamReader stream, CsvParserOptions options)
        {
            return new CsvParser(options).InternalParse(stream);
        }

        public static CsvTable ParseTable(byte[] data)
        {
            return new CsvParser(new CsvParserOptions()).InternalParse(new StreamReader(new MemoryStream(data)));
        }

        public static CsvTable ParseTable(byte[] data, CsvParserOptions options)
        {
            return new CsvParser(options).InternalParse(new StreamReader(new MemoryStream(data)));
        }

        private CsvTable InternalParse(StreamReader stream)
        {
            _table = new CsvTable();
            _reader = stream;
            List<string> unAlteredRows = new List<string>();

            if (!_options.SkipHeader) {
                ReadHeaders(_reader.ReadLine());
            }

            while(!_reader.EndOfStream) {
                unAlteredRows.Add(_reader.ReadLine());
            }

            Parallel.ForEach(unAlteredRows, t =>
            {
                _table.AddRow(GetLineValues(t));
            });

            return _table;
        }

        private void ReadHeaders(string data)
        {
            string[] line = GetLineValues(data);

            int hIndex = 0;
            foreach (var name in line) {
                string columnName = name;
                if (_options.NormalizeHeaderNames) {
                    columnName = new string(name.ToLower()
                        .Where(c => char.IsLetterOrDigit(c)).ToArray());
                }
                var header = new CsvHeader(hIndex++, columnName);
                _table.AddHeader(header);
            }
        }

        private string[] GetLineValues(string line)
        {
            string[] result;

            if (line == null) {
                return null;
            }

            result = Regex.Split(line, @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))");

            return result;
        }
    }
}
