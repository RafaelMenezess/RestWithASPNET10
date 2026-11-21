using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using RestWithASPNET10.Hyppermedia.Abstract;
using RestWithASPNET10.Hyppermedia.Utils;

namespace RestWithASPNET10.Hyppermedia
{
    public abstract class ContentResponseEnricher<T>
        : IResponseEnricher where T : ISupportsHypermedia
    {
        public virtual bool CanEnrich(Type contentType)
        {
            return contentType == typeof(T) || contentType == typeof(List<T>) || contentType == typeof(PagedSearchDTO<T>);
        }

        protected abstract Task EnrichModel(T content, IUrlHelper urlHelper);
        bool IResponseEnricher.CanEnrich(ResultExecutingContext response)
        {
            if (response.Result is ObjectResult objectResult)
            {
                return CanEnrich(objectResult.Value?.GetType());
            }
            return false;
        }

        public async Task Enrich(ResultExecutingContext response)
        {
            var urlHelper = new UrlHelperFactory().GetUrlHelper(response);
            if (response.Result is ObjectResult objectResult)
            {
                if (objectResult.Value is T model)
                {
                    await EnrichModel(model, urlHelper);
                }
                else if (objectResult.Value is List<T> collection)
                {
                    foreach (var item in collection)
                    {
                        await EnrichModel(item, urlHelper);
                    }
                }
                else if (objectResult.Value is PagedSearchDTO<T> pagedSearch)
                {
                    foreach (var item in pagedSearch.List)
                    {
                        await EnrichModel(item, urlHelper);
                    }
                }
            }
            await Task.CompletedTask;
        }
    }
}
