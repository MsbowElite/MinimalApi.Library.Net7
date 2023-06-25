namespace MinimalApi.Library.Net7.Responses
{
    public class PagedCollectionResponse<T> where T : class
    {
        public IEnumerable<T> Items { get; set; } = default!;
        public Uri NextPage { get; set; } = default!;
        public Uri PreviousPage { get; set; } = default!;
        public int TotalCount { get; set; } = default!;
    }
}
