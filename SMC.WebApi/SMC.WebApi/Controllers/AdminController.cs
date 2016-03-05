using SMC.WebApi.Models;
using System.Web.Mvc;

namespace SMC.WebApi.Controllers
{
    public class AdminController : Controller
    {
        public void SyncData()
        {
            var escola = new Escola();
            escola.SyncData();
        }
    }
}