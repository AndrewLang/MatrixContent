using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatrixContent.Framework;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

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
        /// Gets the repository.
        /// </summary>
        /// <value>
        /// The repository.
        /// </value>
        IRepository Repository
        {
            get
            {
                return mServiceProvider.GetService<IRepository>();
            }
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

        /// <summary>
        /// Invalids the response.
        /// </summary>
        /// <returns></returns>
        object InvalidResponse()
        {
            return new
            {
                Success = false,
                Message = "Operation failed."
            };
        }
        /// <summary>
        /// Gets the posts.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        [ApiCommand("Blog.GetPosts")]
        object GetPosts(dynamic parameters)
        {
            if(parameters != null)
            {
                int? page = parameters.Page;
                int? pageSize = parameters.PageSize;

                return new CommandExecuteResult()
                {
                    Data = Repository.GetPagedPosts(page ?? 1,pageSize ?? Consts.DefaultPageSize),
                    Success = true
                };
            }

            return InvalidResponse();
        }
        /// <summary>
        /// Searches the post.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        object SearchPost(dynamic parameters)
        {
            if(parameters != null)
            {
                string keyword = parameters.keyword;
                int? page = parameters.page;
                int? pageSize = parameters.pageSize;

                if(string.IsNullOrEmpty(keyword))
                    return InvalidResponse();

                return Repository.Search(keyword,page ?? 1,pageSize ?? Consts.DefaultPageSize);
            }

            return InvalidResponse();
        }
        /// <summary>
        /// Gets the posts by category.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        object GetPostsByCategory(dynamic parameters)
        {
            if(parameters != null)
            {
                string name = parameters.name;
                int? id = parameters.id;
                int? page = parameters.page;
                int? pageSize = parameters.pageSize;

                if(id == null && string.IsNullOrEmpty(name))
                    return InvalidResponse();

                return Repository.GetPostsByCategory(id.Value,name,page,pageSize);
            }
            return InvalidResponse();
        }
        /// <summary>
        /// Gets the posts by tag.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        object GetPostsByTag(dynamic parameters)
        {
            if(parameters != null)
            {
                string name = parameters.name;
                int? id = parameters.id;
                int? page = parameters.page;
                int? pageSize = parameters.pageSize;

                if(id == null && string.IsNullOrEmpty(name))
                    return InvalidResponse();

                return Repository.GetPostsByTag(id.Value,name,page,pageSize);
            }
            return InvalidResponse();
        }
        /// <summary>
        /// Gets the posts by year.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        object GetPostsByYear(dynamic parameters)
        {
            if(parameters != null)
            {
                int? year = parameters.year;
                int? page = parameters.page;
                int? pageSize = parameters.pageSize;

                if(!year.HasValue)
                    return InvalidResponse();

                return Repository.GetPostsByYear(year.Value,page,pageSize);
            }
            return InvalidResponse();
        }

    }
}
