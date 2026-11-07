using RestWithASPNET10.Hyppermedia.Enricher;
using RestWithASPNET10.Hyppermedia.Filters;

namespace RestWithASPNET10.Configurations
{
    public static class HateosConfig
    {
        public static IServiceCollection AddHateoasConfiguration(this IServiceCollection services)
        {
            var filterOptions = new HypermediaFilterOptions();
            filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());
            filterOptions.ContentResponseEnricherList.Add(new BookEnricher());
            services.AddSingleton(filterOptions);

            services.AddScoped<HypermediaFilter>();

            return services;
        }

        public static void UseHateosRoutes(this IEndpointRouteBuilder app)
        {
           app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
