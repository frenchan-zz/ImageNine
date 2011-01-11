using StructureMap;

namespace ImageNine.Web.Development
{
    public static class ServiceLocator
    {
        public static T GetService<T>()
        {
            return ObjectFactory.GetInstance<T>();
        }   
    }
}