using System.Linq;
using System.Web.Mvc;
using SMC.WebApi.Models;

namespace SMC.WebApi.Controllers
{
    public class OldPerfilEscolaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: PerfilEscola
        public ActionResult Index()
        {
            //var escola = db.Escolas.Where(x => x.Id == "1").FirstOrDefault();
            var escola = new Escola();
            escola.Bairro = "Jardim Nova Mercedes";
            escola.Id = "1";
            escola.Endereco = "Rua Jose Follegati";
            escola.Telefone = "3256-5556";
            escola.NomeUnidadeEscolar = "Escola San Diego";


            return View(escola);
        }
    }
}