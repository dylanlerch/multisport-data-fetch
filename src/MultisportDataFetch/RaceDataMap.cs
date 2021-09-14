namespace MultisportDataFetch
{
    public class RaceDataMap
    {
        public string? RaceId { get; set; }
        public string? EventId { get; set; }
        public int StartPage { get; set; } = 1;
        public string EmptyPageText { get; set; } = "search query has returned no results";
        public RaceDataReference? Position { get; set; }
        public RaceDataReference? Name { get; set; }
        public RaceDataReference? Number { get; set; }
        public RaceDataReference? Category { get; set; }
        public RaceDataReference? Gender { get; set; }
        public RaceDataTimeReference? Time { get; set; }
        public RaceDataTimeReference? Swim { get; set; }
        public RaceDataTimeReference? T1 { get; set; }
        public RaceDataTimeReference? Bike { get; set; }
        public RaceDataTimeReference? T2 { get; set; }
        public RaceDataTimeReference? Run { get; set; }
    }
}