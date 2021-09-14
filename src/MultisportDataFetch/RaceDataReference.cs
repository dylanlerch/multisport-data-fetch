using System.Text.RegularExpressions;

namespace MultisportDataFetch
{
    public class RaceDataReference
    {
        public RaceDataReference(int index, Regex? pattern = null)
        {
            Index = index;
            Pattern = pattern;
        }

        public int Index { get; set; }
        public Regex? Pattern { get; set; }
    }
}