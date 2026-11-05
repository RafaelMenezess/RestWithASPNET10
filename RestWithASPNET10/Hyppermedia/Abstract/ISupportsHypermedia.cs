using RestWithASPNET10.Hypermedia;

namespace RestWithASPNET10.Hyppermedia.Abstract
{
    public interface ISupportsHypermedia
    {
        List<HypermediaLink> Links { get; set; }
    }
}