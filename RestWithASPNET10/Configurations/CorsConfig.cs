namespace RestWithASPNET10.Configurations
{
    public static class CorsConfig
    {
        public static void AddCorsConfiguration(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("LocalPolicy",
                   policy => policy.WithOrigins(
                           "http://localhost:3000")
                       .AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowCredentials());

                options.AddPolicy("MultipleOriginPolicy",
                    policy => policy.WithOrigins(
                            "http://localhost:3000",
                            "http://localhost:8080",
                            "https://erudio.com.br"
                            )
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials());

            });
        }

        public static IApplicationBuilder UseCorsConfiguration(this IApplicationBuilder app)
        {
            app.UseCors();
            return app;
        }
    }
}
