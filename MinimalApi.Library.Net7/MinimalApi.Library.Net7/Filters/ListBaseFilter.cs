namespace MinimalApi.Library.Net7.Filters
{
    public abstract class ListBaseFilter : ICloneable
    {
        public short Limit { get; set; }
        public short Offset { get; set; } = default!;

        public ListBaseFilter()
        {
            Limit = 10;
            Offset = 0;
        }

        public abstract object Clone();
    }
}
