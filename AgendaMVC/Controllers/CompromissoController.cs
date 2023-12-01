using AgendaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgendaMVC.Controllers
{
	public class CompromissoController : Controller
	{
		public IActionResult Index()
		{
			return View(Dados.Db.compromissos);
		}

		[HttpGet]
		public IActionResult Create()
		{
			List<SelectListItem> Contatos = new List<SelectListItem>();
			Contatos = Dados.Db.contatos.Select(c => new SelectListItem()
			{ Text = c.Email, Value = c.Id.ToString() }).ToList();
			ViewBag.Contatos = Contatos;
			return View();
		}

		[HttpPost]
		public IActionResult Create(Compromisso compromisso)
		{
			if (Dados.Db.compromissos.Count > 0 ){
				compromisso.Id = Dados.Db.compromissos.Max(c => c.Id) + 1;
			}
			else
			{
				compromisso.Id = 1;
			}
			compromisso.Contato = Dados.Db.contatos.FirstOrDefault(c => c.Id == compromisso.Contato.Id);
			Dados.Db.compromissos.Add(compromisso);

            return RedirectToAction("Index");
		}
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            Models.Contato contato = Dados.Db.contatos.FirstOrDefault(ct => ct.Id == id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Editar(Models.Contato contato)
        {
            Models.Contato cont = Dados.Db.contatos.FirstOrDefault(ct => ct.Id == contato.Id);
            cont.Nome = contato.Nome;
            cont.Email = contato.Email;
            cont.Telefone = contato.Telefone;
            return RedirectToAction("Index");
        }
    }
}