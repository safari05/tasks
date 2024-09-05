using Microsoft.AspNetCore.Mvc;

namespace TodoTask.Web.Controllers
{
    public class UserController : BaseController
    {

        private readonly ILogger<UserController> _logger;
        private readonly int UserId;
        private readonly string Token = string.Empty;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public UserController(ILogger<UserController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            if (_session.IsAvailable)
            {
                if (_session.GetInt32("UserId") != null)
                    UserId = (int)_session.GetInt32("UserId");
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
