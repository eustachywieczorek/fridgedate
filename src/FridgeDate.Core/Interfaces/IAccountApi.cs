using FridgeDate.Core.Requests;
using FridgeDate.Core.Responses;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FridgeDate.Core.Interfaces
{
    public interface IAccountApi
    {
        [Post("/api/Account/Logout")]
        Task<HttpResponseMessage> Logout();

        [Get("/api/Account/ManageInfo?returnUrl=%2F&generateState=true")]
        Task<ManageInfoResponse> GetManageInfo(string returnUrl, bool generateState = false);

        [Post("/api/Account/ChangePassword")]
        Task<HttpResponseMessage> ChangePassword(ChangePasswordRequest request);

        [Post("/api/Account/SetPassword")]
        Task<HttpResponseMessage> SetPassword(SetPasswordRequest request);

        [Post("/api/Account/AddExternalLogin")]
        Task<HttpResponseMessage> AddExternalLogin(AddExternalLoginRequest request);

        [Post("/api/Account/RemoveLogin")]
        Task<HttpResponseMessage> RemoveLogin(RemoveLoginRequest request);

        [Get("/api/Account/ExternalLogin")]
        Task<HttpResponseMessage> GetExternalLogin(string provider, string error = null);

        [Get("/api/Account/ExternalLogins?returnUrl={returnUrl}&generateState={generateState}")]
        Task<IEnumerable<ExternalLogin>> GetExternalLogins(string returnUrl, bool generateState = false);
        [Post("/api/Account/Register")]
        Task<HttpResponseMessage> Register([Body] RegisterRequest request);
    
        [Post("/api/Account/RegisterExternal")]
        Task<HttpResponseMessage> RegisterExternal(RegisterExternalRequest request);


    }
}
