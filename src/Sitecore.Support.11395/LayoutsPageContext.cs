namespace Sitecore.Support.XA.Foundation.PlaceholderSettings.Services
{
  using Microsoft.Extensions.DependencyInjection;
  using Sitecore.Data.Items;
  using Sitecore.DependencyInjection;
  using Sitecore.XA.Foundation.PlaceholderSettings;
  using Sitecore.XA.Foundation.SitecoreExtensions.Extensions;
  using System.Linq;

  public class LayoutsPageContext : Sitecore.XA.Foundation.PlaceholderSettings.Services.LayoutsPageContext
  {
    public override Item GetSxaPlaceholderItem(string phKey, Item currentItem)
    {
      Item placeholderSettingsFolder = ServiceLocator.ServiceProvider.GetService<IPlaceholderSettingsContext>().GetPlaceholderSettingsFolder(currentItem);
      if (placeholderSettingsFolder == null)
      {
        return null;
      }
      string placeholderKey = phKey;
      int num = phKey.LastIndexOf('/');
      if (num >= 0)
      {
        placeholderKey = StringUtil.Mid(phKey, num + 1);

      }
      return (from i in placeholderSettingsFolder.Axes.GetDescendants()
              where i.InheritsFrom(Templates.Placeholder.ID)
              select i).FirstOrDefault((Item item) => ((BaseItem)item)[Templates.Placeholder.Fields.PlaceholderKey].Equals(placeholderKey));
    }
  }
}