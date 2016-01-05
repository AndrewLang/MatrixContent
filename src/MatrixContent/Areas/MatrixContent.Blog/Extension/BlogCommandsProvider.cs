using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatrixContent.Framework;

namespace MatrixContent.Blog
{
    /// <summary>
    /// Commands provider for blog
    /// </summary>
    /// <seealso cref="MatrixContent.Framework.IApiCommandProvider" />
    public class BlogCommandsProvider:IApiCommandProvider
    {
        readonly IServiceProvider mServiceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogCommandsProvider" /> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public BlogCommandsProvider(IServiceProvider serviceProvider)
        {
            mServiceProvider = serviceProvider;
        }

        /// <summary>
        /// Gets the commands.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string,Func<object,object>> GetCommands()
        {
            var commands = new Dictionary<string,Func<object,object>>();

            foreach(var item in this.DiscoveryApiCommands())
            {
                commands.Add(item.Key,item.Value);
            }
            return commands;
        }


    }
}
