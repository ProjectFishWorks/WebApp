using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProjectFishWorksWebApp;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Load environment-specific configs
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.HostEnvironment.Environment}.json", optional: true, reloadOnChange: true);

// Add core authorization services
builder.Services.AddAuthorizationCore();

#if DEBUG
builder.Services.AddScoped<AuthenticationStateProvider, ProjectFishWorksWebApp.Services.FakeAuthenticationStateProvider>();
builder.Services.AddCascadingAuthenticationState();
#else
builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Auth0", options.ProviderOptions);
    options.ProviderOptions.ResponseType = "code";
    options.ProviderOptions.AdditionalProviderParameters.Add("audience", builder.Configuration["Auth0:Audience"]);
});
builder.Services.AddCascadingAuthenticationState();
#endif

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<MQTTnet.ClientLib.MqttService>();
builder.Services.AddMudServices();

await builder.Build().RunAsync();
