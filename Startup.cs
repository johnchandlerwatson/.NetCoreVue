﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Vue
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Setup WebpackDevMidleware for "Hot module replacement" while debugging
                var options = new WebpackDevMiddlewareOptions() { HotModuleReplacement = true };
                app.UseWebpackDevMiddleware(options);
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                /* 
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");*/

                // Setup additional routing for SPA
                routes.MapSpaFallbackRoute(
                name: "spa-fallback",
                defaults: new { controller = "Home", action = "Index" });
            });

            SetCulture(app);
        }

        private void SetCulture(IApplicationBuilder app)
        {
            var locale = "en-US";
            var cultureInfo = new CultureInfo(locale);
            cultureInfo.NumberFormat.CurrencySymbol = "$";

            RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions
            {
                SupportedCultures = new List<CultureInfo> { cultureInfo },
                SupportedUICultures = new List<CultureInfo> { cultureInfo },
                DefaultRequestCulture = new RequestCulture(locale)
            };
            app.UseRequestLocalization(localizationOptions);
            
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
    }
}
