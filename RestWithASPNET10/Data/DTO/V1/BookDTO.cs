using RestWithASPNET10.Hypermedia;
using RestWithASPNET10.Hyppermedia.Abstract;

namespace RestWithASPNET10.Data.DTO
{
    public class BookDTO : ISupportsHypermedia
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime LaunchDate { get; set; }
        public List<HypermediaLink> Links { get; set; } = [];
    }
}