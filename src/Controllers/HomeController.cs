using Microsoft.AspNetCore.Mvc;


namespace Sduig9suidng.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public object Get()
        {
            return "{\"result\": \"Приветик! Иди, пожалуйста, на /api/pet\"}";
        }
    }
}