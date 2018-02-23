using System;
using CsvTools;
using Xunit;

namespace Test.CsvTableTests
{
    public class CsvTableTests
    {
        [Fact]
        public void CsvTable_GetHeader_ByIndex_Success()
        {
            var table = new CsvTable();
            string headerName = "test";

            table.AddHeader(headerName);

            CsvHeader returnedHeader = table.GetHeader(0);

            Assert.Equal(headerName, returnedHeader.Name);
            Assert.Equal(0, returnedHeader.Index);
        }

        [Fact]
        public void CsvTable_GetHeader_ByIndex_IndexOutOfRange()
        {
            var table = new CsvTable();

            Assert.Throws<IndexOutOfRangeException>(() => table.GetHeader(0));
        }

        [Fact]
        public void CsvTable_HasColumn_Success()
        {
            var table = new CsvTable();
            string headerName = "test";

            table.AddHeader(headerName);

            Assert.True(table.HasColumn(headerName));
        }

        [Fact]
        public void CsvTable_HasColumn_NullArgument()
        {
            var table = new CsvTable();
            string headerName = "test";

            table.AddHeader(headerName);

            Assert.False(table.HasColumn(null));
        }

        [Fact]
        public void CsvTable_HasColumn_HeaderDoesNotExist()
        {
            var table = new CsvTable();
            string headerName = "test";
            string nonExistingheaderName = "iDontExist";

            table.AddHeader(headerName);

            Assert.False(table.HasColumn(nonExistingheaderName));
        }

        [Fact]
        public void CsvTable_AddHeader_ByName_Success()
        {
            var table = new CsvTable();
            string headerName = "test";

            table.AddHeader(headerName);

            CsvHeader returnedHeader = table.GetHeader(0);

            Assert.Equal(headerName, returnedHeader.Name);
            Assert.Equal(0, returnedHeader.Index);
        }

        [Fact]
        public void CsvTable_AddHeader_ByName_NullHeader()
        {
            var table = new CsvTable();
            string headerName = null;

            Assert.Throws<ArgumentNullException>(() => table.AddHeader(headerName));
        }
    }
}
