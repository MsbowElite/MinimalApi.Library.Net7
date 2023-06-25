namespace MinimalApi.Library.Net7.Models
{
    public class Book
    {
        public string Isbn { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public string ShortDescription { get; set; } = default!;
        public PackedValue PageCount { get; set; }
        public DateTime ReleaseDate { get; set; }
    }

    public struct PackedValue
    {
        private PackedValue(int val)
        {
            if (val >= (1 << 12)) throw new ArgumentOutOfRangeException("val");
            this._value = val;
        }
        private int _value;
        public static explicit operator PackedValue(int value)
        {
            return new PackedValue(value);
        }

        public static implicit operator int(PackedValue me)
        {
            return me._value;
        }
    }
}
