using Microsoft.AspNetCore.Mvc.Filters;

namespace RestWithASPNET10.Hyppermedia.Abstract
{
    public interface IResponseEnricher
    {
        bool CanEnrich(ResultExecutingContext context);
        Task Enrich(ResultExecutingContext context);
    }
}
