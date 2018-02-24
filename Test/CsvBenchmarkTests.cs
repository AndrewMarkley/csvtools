using System;
using System.IO;
using CsvTools;
using Xunit;
using System.Linq;
using System.Text;

namespace Test
{
    public class CsvBenchmarkTests
    {
        public string benchmarkCsvPath = "/Users/axial/Downloads/QCLCD201503/201503hourly.txt";

        [Fact]
        public void CsvTable_GetHeader_ByIndex_Success()
        {
            CsvTestHelpers.MeasureElapsedTime("Parse and Export", () =>
            {
                var table = CsvParser.ParseTable(File.ReadAllBytes(benchmarkCsvPath));
                table.ExportTable(Encoding.ASCII);
            });
        }
    }
}
