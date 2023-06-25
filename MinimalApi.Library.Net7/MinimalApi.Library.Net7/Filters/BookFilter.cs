using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MinimalApi.Library.Net7.Filters
{
    public class BookFilter : ListBaseFilter
    {
        [FromQuery]
        public string SearchTerm { get; set; }

        public BookFilter(string searchTerm, short? limit, short? offset) : base()
        {
            SearchTerm = searchTerm;

            if (limit is not null)
                Limit = limit.Value;
            if (offset is not null)
                Offset = offset.Value;
        }

        public static bool TryParse(string? value, IFormatProvider? provider,
                                    out BookFilter? bookFilter)
        {
            //var trimmedValue = value?.TrimStart()
            bookFilter = null;
            return false;
        }

        public override object Clone()
        {
            var jsonString = JsonSerializer.Serialize(this);
            return JsonSerializer.Deserialize(jsonString, GetType());
        }
    }
}
