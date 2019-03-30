using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;

namespace OCAT.API
{
    public class WebAuthenticationFilter : BasicAuthenticationFilter
    {

        public WebAuthenticationFilter()
        { }

        public WebAuthenticationFilter(bool active) : base(active)
        { }

        protected override bool OnAuthorizeUser(string username, string password, HttpActionContext actionContext)
        {
            // However we want to validate the users - validate here. 
            if ( (username == "OCAT_user") && (password == "Cambria123"))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}