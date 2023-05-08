namespace DotNetIdentityAuthentication_Authorization
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", options =>
            {
                options.Cookie.Name = "MyCookieAuth";
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly",
                    policy => policy.RequireClaim("Admin"));

                options.AddPolicy("MustBelongToHRDepartment",
                    policy => policy.RequireClaim("Department", "HR"));

                options.AddPolicy("HRManagerOnly",
                    policy => policy
                    .RequireClaim("Deapartment", "HR")
                    .RequireClaim("HR"));
            });
             
            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}