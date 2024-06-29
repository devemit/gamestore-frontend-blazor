using GameStore.Frontend.Clients;
using GameStore.Frontend.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
 .AddInteractiveServerComponents();


var gameStoreApiUri = builder.Configuration["GameStoreApiUrl"] ?? throw new Exception("Game store api url is not set");
builder.Services.AddHttpClient<GamesClient>(client => client.BaseAddress = new Uri(gameStoreApiUri));
builder.Services.AddHttpClient<GenresClient>(client => client.BaseAddress = new Uri(gameStoreApiUri));

// we dont need this2 lines because we added httpclient connection to the classes
// builder.Services.AddSingleton<GamesClient>();
// builder.Services.AddSingleton<GenresClient>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}


// these are middlewares
// definition: A middleware is nothing but a component (class) which is executed on every request in ASP.NET Core application. In the classic ASP.NET, HttpHandlers and HttpModules were part of request pipeline. Middleware is similar to HttpHandlers and HttpModules where both needs to be configured and executed in each request.
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
 .AddInteractiveServerRenderMode();

app.Run();
