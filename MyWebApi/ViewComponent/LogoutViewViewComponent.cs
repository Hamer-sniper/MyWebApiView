using Microsoft.AspNetCore.Mvc;

namespace MyWebApiView.Component
{
    public class LogoutViewViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }

}
