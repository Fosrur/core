namespace core.Extensions
{
    /// <summary>
    /// Definition of BuilderExtensions
    /// </summary>
    public static class BuilderExtensions
    {
        /// <summary>
        /// Definition of AddCoreBuilderExtensions
        /// </summary>
        public static IApplicationBuilder AddCoreBuilderExtensions(this IApplicationBuilder app, IHostEnvironment environment) => app.UseOtherBuilder(environment);
		
        /// <summary>
		/// Definition of UseOtherBuilder
		/// </summary>
		public static IApplicationBuilder UseOtherBuilder(this IApplicationBuilder app, IHostEnvironment environment)
        {
			if (environment.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseResponseCaching();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            return app;
        }
    }
}
