using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VisitorSystem.Models
{
    public class AuthorizeADAttribute:AuthorizeAttribute
    {
        public string Groups { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (base.AuthorizeCore(httpContext))
            {
                /*
                 * Return true immediately if the authorization is not locked down to any particular AD group
                 */
                if (String.IsNullOrEmpty(Groups))
                    return true;

                //Get the AD groups
                var groups = Groups.Split(',').ToList();

                //Verify that the user is in the given AD group (if any)
                var context = new PrincipalContext(
                                        ContextType.Domain,
                                        "SASREFALJ");
                var userPrincipal = UserPrincipal.FindByIdentity(
                                          context,
                                          IdentityType.SamAccountName,
                                          httpContext.User.Identity.Name.ToUpper());

                foreach (var group in groups)
                    if (userPrincipal.IsMemberOf(context, IdentityType.SamAccountName, group))
                        return true;
            }
            return false;

            }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var result = new ViewResult();
                result.ViewName = "NotAuthorized";
                result.MasterName = "_Layout";
                filterContext.Result = result;
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }

}
