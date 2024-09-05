using Microsoft.AspNetCore.Mvc;
using TodoTask.Web.Data.Entity;

namespace TodoTask.Web.Controllers
{
    public class DashboardController : BaseController
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly int UserId;
        private readonly string Token = string.Empty;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public DashboardController(ILogger<DashboardController> logger, IHttpContextAccessor httpContextAccessor)
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
