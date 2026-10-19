using Microsoft.AspNetCore.Mvc.Filters;

namespace RestWithASPNET10.Hyppermedia.Abstract
{
    public interface IResponseEnricher
    {
        bool CanEnrich(ResultExecutedContext context);
        Task Enrich(ResultExecutedContext context);
    }
}
