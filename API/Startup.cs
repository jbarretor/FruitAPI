using BusinessLogic;
using DataAcess;
using DataAcess.Repository;
using Microsoft.EntityFrameworkCore;

namespace FruitApplication
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

            //services.AddControllers();
            string DBUUID = Guid.NewGuid().ToString();
            services.AddDbContext<FruitContext>(opt => opt.UseInMemoryDatabase("FruitList" + DBUUID));
            services.AddControllers();


            services.AddScoped<IFruitRepository, FruitRepository>();
            services.AddScoped<IFruitTypeRepository, FruitTypeRepository>();

            services.AddScoped<IBLFruit, BLFruit>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
