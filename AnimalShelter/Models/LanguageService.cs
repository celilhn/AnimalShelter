using Microsoft.Extensions.Localization;
using System.Reflection;

namespace AnimalShelter.Models
{
    public class LanguageService
    {
        private readonly IStringLocalizer locaizer;

        public LanguageService(IStringLocalizerFactory factory)
        {
            var type = typeof(ShareResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            locaizer = factory.Create("SharedResource", assemblyName.Name);
        }

        public LocalizedString GetKey(string key)
        {
            return locaizer[key];
        }
    }
}
