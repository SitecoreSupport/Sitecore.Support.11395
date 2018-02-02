using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.XA.Foundation.PlaceholderSettings.Services;

namespace Sitecore.Support
{
  public class RegisterDependencies : IServicesConfigurator
  {
    public void Configure(IServiceCollection serviceCollection)
    {
      serviceCollection.AddTransient<ILayoutsPageContext, Sitecore.Support.XA.Foundation.PlaceholderSettings.Services.LayoutsPageContext>();
    }
  }
}