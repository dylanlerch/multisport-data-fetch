using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace MultisportDataFetch
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var baseUrl = "https://www.multisportaustralia.com.au/races";
            var map = new RaceDataMap
            {
                RaceId = "ironman-703-sunshine-coast-2021",
                EventId = "1",
                Position = new(0),
                Name = new(1, new Regex(@"^[\w\s]+")),
                Number = new(1, new Regex(@"(?<=#)\d+")),
                Category = new(3, new Regex(@"\d+-\d+")),
                Gender = new(4, new Regex(@"[A-Za-z]+")),
                Time = new RaceDataTimeReference(2),
                Swim = new RaceDataTimeReference(5),
                T1 = new RaceDataTimeReference(6),
                Bike = new RaceDataTimeReference(7),
                T2 = new RaceDataTimeReference(8),
                Run = new RaceDataTimeReference(9),
            };

            // Load all the data
            var web = new HtmlWeb();
            var data = new List<List<string>>();
            var page = map.StartPage;

            while (true)
            {
                var url = $"{baseUrl}/{map.RaceId}/events/{map.EventId}?page={page}";

                // Get the results from the page
                var doc = await web.LoadFromWebAsync(url);

                if (doc.DocumentNode.OuterHtml.Contains(map.EmptyPageText))
                {
                    break;
                }

                var results = doc.DocumentNode.SelectNodes("//table/tbody/tr");

                foreach (var result in results)
                {
                    // Get the rows from the page
                    var dataColumns = result.SelectNodes("td");
                    data.Add(dataColumns.Select(c => c.InnerText.CleanWhitespace()).ToList());
                }

                page += 1;
            }


            var rows = data.Select(r =>
            {
                return new RaceDataRow
                {
                    Position = GetValue(r, map.Position),
                    Name = GetValue(r, map.Name),
                    Number = GetValue(r, map.Number),
                    Category = GetValue(r, map.Category),
                    Gender = GetValue(r, map.Gender),
                    Time = GetTimeValue(r, map.Time),
                    Swim = GetTimeValue(r, map.Swim),
                    T1 = GetTimeValue(r, map.T1),
                    Bike = GetTimeValue(r, map.Bike),
                    T2 = GetTimeValue(r, map.T2),
                    Run = GetTimeValue(r, map.Run),
                };
            }).ToList();
        }

        static string? GetValue(List<string> input, RaceDataReference reference)
        {
            if (input.Count <= reference.Index)
            {
                return null;
            }
            else
            {
                var value = input[reference.Index];

                if (reference.Pattern is not null)
                {
                    value = reference.Pattern.Match(value).Value;
                }

                return value.Trim();
            }

        }

        static TimeSpan? GetTimeValue(List<string> input, RaceDataTimeReference timeReference)
        {
            var value = GetValue(input, timeReference);

            if (!string.IsNullOrWhiteSpace(value))
            {
                return TimeSpan.ParseExact(value, timeReference.Format, CultureInfo.InvariantCulture);
            }
            else
            {
                return null;
            }
        }
    }
}
