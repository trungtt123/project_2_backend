using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WareHouse.Service.Implementations;
using WareHouse.Service.Interfaces;

namespace WareHouse.Controllers
{
    public class VerifyRoleFilter : Attribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var _userservice = (IUserService)context.HttpContext.RequestServices.GetService(typeof(IUserService));
            if (context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            { 
                var token = context.HttpContext.Request.Headers.First(x => x.Key == "Authorization").Value.ToString().Replace("Bearer ", string.Empty);
                var kt = _userservice.VerifyToken(token);
                if (!kt) context.Result = new ForbidResult();
            }
            
        }
    }
}
