
using Application.Interfaces;
using Application.Services;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System.IdentityModel.Tokens.Jwt;
using System.Net.WebSockets;

namespace Presentation.Filters
{
    public class JwtAuthorize : Attribute, IAuthorizationFilter
    {
        public const string _jwtHeader = "Authorization";
        public JwtSecurityToken DecodeJwt(AuthorizationFilterContext context)
        {
            string jwtToken = context.HttpContext.Request.Headers[_jwtHeader];
            if (string.IsNullOrEmpty(jwtToken))
            {
                context.Result = new UnauthorizedObjectResult(context);
            }
            string reformatted = jwtToken.Replace("Bearer ", string.Empty);
            var handler = new JwtSecurityTokenHandler();
            var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(reformatted);

            return token;
        }

        public bool IsOwner(long EntityId, long OwnerId)
        {
            return EntityId == OwnerId;
        }

        public bool isAdmin(string jwtRole)
        {
            return jwtRole == "Administrator";
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string jwtToken = context.HttpContext.Request.Headers[_jwtHeader];
            if (string.IsNullOrEmpty(jwtToken))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            var jwtSecurityToken = DecodeJwt(context);
            var role = jwtSecurityToken.Claims.First(claim => claim.Type == "Role").Value;
            var id = jwtSecurityToken.Claims.First(claim => claim.Type == "Id").Value;

            

            var noteService = context.HttpContext.RequestServices.GetService<INoteService>();
            var entityID = Convert.ToInt64(context.RouteData.Values["Id"]);
            var UserID = long.Parse(id);
            var note = noteService.GetNoteAsync(entityID).GetAwaiter().GetResult();
            if (!IsOwner(note.Data.OwnerId, UserID) && !isAdmin(role))
            {
                context.Result = new ForbidResult();
            }

        }
    }
}

