using System.IO;
using System.Text;
using CsvTools;
using Xunit;
using Xunit.Abstractions;

namespace Test
{
    public class CsvBenchmarkTests
    {
        public string benchmarkCsvPath = "D://Downloads//QCLCD201503//201503hourly.txt";
        private ITestOutputHelper _outputHelper;

        public CsvBenchmarkTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void CsvBenchmark_ParseAndExport()
        {
            CsvTestHelpers.MeasureElapsedTime("Parse and Export", _outputHelper, () =>
            {
                var table = CsvParser.ParseTable(File.ReadAllBytes(benchmarkCsvPath));
                table.ExportTable(Encoding.ASCII);
            });
        }
    }
}
