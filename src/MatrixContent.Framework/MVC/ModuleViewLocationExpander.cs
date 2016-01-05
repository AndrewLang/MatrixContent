using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.Razor;

namespace MatrixContent.Framework
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Mvc.Razor.IViewLocationExpander" />
    public class ModuleViewLocationExpander:IViewLocationExpander
    {
        readonly string mPrefix;
        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleViewLocationExpander"/> class.
        /// </summary>
        /// <param name="prefix">The prefix.</param>
        public ModuleViewLocationExpander(string prefix)
        {
            mPrefix = prefix;
        }

        /// <summary>
        /// Expands the view locations.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="viewLocations">The view locations.</param>
        /// <returns></returns>
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context,IEnumerable<string> viewLocations)
        {
            foreach(var location in viewLocations)
            {
                yield return location;
            }

            if(IsArea(context))
            {
                yield return "/Areas/" + mPrefix + ".{2}/Views/{1}/{0}.cshtml";
                yield return "/Areas/" + mPrefix + ".{2}/Views/Shared/{0}.cshtml";
            }
        }

        /// <summary>
        /// Populates the values.
        /// </summary>
        /// <param name="context">The context.</param>
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            var name = context.ViewName;
        }

        /// <summary>
        /// Determines whether the specified context is area.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        bool IsArea(ViewLocationExpanderContext context)
        {
            if(context.ActionContext.ActionDescriptor.RouteConstraints.Any(x => x.RouteKey == "area" && !string.IsNullOrEmpty(x.RouteValue)))
                return true;
            return false;
        }
    }
}
