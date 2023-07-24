namespace SiiTestBackEndDotNetCore
{
    public static class CorsConfigurationExtensions
    {
        public static string AllowSpecificOrigins
        {
            get { return "_AllowSpecificOrigins"; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(AllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
        }
    }
}
