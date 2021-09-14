using System.Text.RegularExpressions;

namespace MultisportDataFetch
{
    public class RaceDataTimeReference : RaceDataReference
    {
        public RaceDataTimeReference(int index, Regex? pattern = null, string format = @"hh\:mm\:ss") : base(index, pattern)
        {
            Format = format;
        }

        public string Format { get; set; }
    }
}