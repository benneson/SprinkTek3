using Abp.AspNetCore.Mvc.Authorization;
using SprintTek.Authorization;
using SprintTek.Storage;
using Abp.BackgroundJobs;

namespace SprintTek.Web.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Users)]
    public class UsersController : UsersControllerBase
    {
        public UsersController(IBinaryObjectManager binaryObjectManager, IBackgroundJobManager backgroundJobManager)
            : base(binaryObjectManager, backgroundJobManager)
        {
        }
    }
}