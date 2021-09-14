using System;
using System.Text.RegularExpressions;

namespace MultisportDataFetch
{
        public class RaceDataRow
    {
        public string? Position { get; set; }
        public string? Number { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public string? Gender { get; set; }
        public TimeSpan? Time { get; set; }
        public TimeSpan? Swim { get; set; }
        public TimeSpan? T1 { get; set; }
        public TimeSpan? Bike { get; set; }
        public TimeSpan? T2 { get; set; }
        public TimeSpan? Run { get; set; }
    }
}