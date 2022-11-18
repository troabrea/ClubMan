using System.Resources;
using Humanizer.Localisation;
using Syncfusion.Blazor;

namespace ClubMan.Web.Services;

public class SyncfusionLocalizer : ISyncfusionStringLocalizer
{
    public string GetText(string key)
    {
        return ResourceManager.GetString(key);
    }

    public ResourceManager ResourceManager
    {
        get
        {
            return Resources.SfResources.ResourceManager;
        }
    }
}