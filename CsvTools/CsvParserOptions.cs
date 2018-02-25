namespace CsvTools
{
    public class CsvParserOptions
    {
        public readonly char FieldsSeparator;

        public readonly bool SkipHeader;

        public readonly bool NormalizeHeaderNames;

        public readonly int DegreeOfParallelism;

        public readonly bool KeepOrder;

        public CsvParserOptions(bool skipHeader = false, char fieldsSeparator = ',', int degreeOfParallelism = 1, bool keepOrder = true, bool normalizeHeaderNames = false)
        {
            SkipHeader = skipHeader;
            DegreeOfParallelism = degreeOfParallelism;
            KeepOrder = keepOrder;
            FieldsSeparator = fieldsSeparator;
            NormalizeHeaderNames = normalizeHeaderNames;
        }
    }
}
