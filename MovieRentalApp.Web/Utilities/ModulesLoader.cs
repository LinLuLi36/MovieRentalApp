using System.Collections.Generic;

namespace MovieRentalApp.Web.Utilities
{
    public static class ModulesLoader
    {
        /// <summary>
        /// Loads modules to a List
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<T> LoadModules<T>() where T : class
        {
            return ReflectiveEnumerator.GetEnumerableOfType<T>();
        }
    }
}
