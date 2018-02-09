using Microsoft.Extensions.DependencyInjection;
using Sitecore.Data.Items;
using Sitecore.Pipelines.GetPlaceholderRenderings;
using Sitecore.XA.Foundation.PlaceholderSettings;
using Sitecore.XA.Foundation.SitecoreExtensions.Extensions;
using System.Linq;

namespace Sitecore.Support.XA.Foundation.PlaceholderSettings.Pipelines.GetPlaceholderRenderings
{
  public class GetAllowedRenderings : Sitecore.XA.Foundation.PlaceholderSettings.Pipelines.GetPlaceholderRenderings.GetAllowedRenderings
  {
    protected override Item GetSxaPlaceholderItem(GetPlaceholderRenderingsArgs args, Item currentItem)
    {
      var placeholderSettings = Sitecore.DependencyInjection.ServiceLocator.ServiceProvider.GetService<IPlaceholderSettingsContext>().GetPlaceholderSettingsFolder(currentItem);
      #region Added code
      string placeholderKey = args.PlaceholderKey;
      int num = args.PlaceholderKey.LastIndexOf('/');
      if (num >= 0)
      {
        placeholderKey = StringUtil.Mid(args.PlaceholderKey, num + 1);
      } 
      #endregion
      var sitePlaceholderItem = placeholderSettings?.Axes.GetDescendants()
        .Where(i => i.InheritsFrom(Templates.Placeholder.ID))
        #region Changed code
        .FirstOrDefault(item => item[Templates.Placeholder.Fields.PlaceholderKey].Equals(placeholderKey));
        #endregion
      return sitePlaceholderItem;
    }
  }
}