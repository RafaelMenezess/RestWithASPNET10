using RestWithASPNET10.Hyppermedia.Abstract;

namespace RestWithASPNET10.Hyppermedia.Filters
{
    public class HypermediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = [];
    }
}
