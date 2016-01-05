using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MatrixContent.Framework
{
    public static class ApiCommandExtensions
    {
        static BindingFlags DiscoveryFlag = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        /// <summary>
        /// Discoveries the commands.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static IEnumerable<KeyValuePair<string,Func<object,object>>> DiscoveryCommands(this object instance)
        {
            var type = instance.GetType();
            var commands = type.GetMethods(DiscoveryFlag)
                     .Where(x => x.GetCustomAttributes(typeof(ApiCommandAttribute),false).Length > 0)
                     .Select(x =>
                     {
                         var attribute = x.GetCustomAttribute<ApiCommandAttribute>(false);
                         if(!string.IsNullOrEmpty(attribute.Name))
                         {
                             // mCommands.Add(attribute.Name,args => { return x.Invoke(this,new object[] { args }); });
                             return new KeyValuePair<string,Func<object,object>>(attribute.Name,args => { return x.Invoke(instance,new object[] { args }); });
                         }
                     });

            return commands;
        }
    }
}
