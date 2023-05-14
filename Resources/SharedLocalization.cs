using Microsoft.Extensions.Localization;
using System.Reflection;

namespace PrintSite.Resources
{
    public class SharedLocalization
    {
        private readonly IStringLocalizer _localizer;
        public SharedLocalization(IStringLocalizerFactory factory)
        {
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("SharedResource", assemblyName.Name);

        }
        public LocalizedString this[string key]
        {
            get { return _localizer[key]; }
        }
    }
}
