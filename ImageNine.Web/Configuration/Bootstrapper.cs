using StructureMap;

namespace ImageNine.Web.Configuration
{
    public class Bootstrapper
    {
        public static void ConfigureStructureMap(IContainer container)
        {
            container.Configure(x => x.AddRegistry(new WebRegistry()));
        }
    }
}