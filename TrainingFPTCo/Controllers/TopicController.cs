using Microsoft.AspNetCore.Mvc;

namespace TrainingFPTCo.Controllers
{
    public class TopicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
