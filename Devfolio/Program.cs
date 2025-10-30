using Devfolio.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Con esto el repositorio de proyectos será instanciado automaticamente
// siempre que se tenga que usar.
builder.Services.AddTransient<IRepositorioProyectos,RepositorioProyectos>();

// Configurando un servicio de cada tipo:
builder.Services.AddTransient<ServicioTransitorio>();
builder.Services.AddScoped<ServicioDelimitado>();
builder.Services.AddSingleton<ServicioUnico>();

// Servicio de GMAIL
builder.Services.AddTransient<IServicioGmail, ServicioGmail>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
