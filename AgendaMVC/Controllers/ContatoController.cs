using AgendaMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMVC.Controllers
{
	public class ContatoController : Controller
	{
		static List<Models.Contato> contatos = new() {new Contato()
            {
                Id = 1,
                Nome = "Maria",
                Email = "Maria@gmail.com",
                Telefone = "(47) 99278-2893"
            } };

        public IActionResult Index()
        {
            return View(Dados.Db.contatos);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Contato contato)
        {
            contato.Id = Dados.Db.contatos.Count + 1;
            Dados.Db.contatos.Add(contato);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Models.Contato contato = Dados.Db.contatos.FirstOrDefault(ct => ct.Id == id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Edit(Models.Contato contato)
        {
            Models.Contato cont = Dados.Db.contatos.FirstOrDefault(ct => ct.Id == contato.Id);
            cont.Nome = contato.Nome;
            cont.Email = contato.Email;
            cont.Telefone = contato.Telefone;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            Models.Contato contato = Dados.Db.contatos.FirstOrDefault(ct => ct.Id == id);
            return View(contato);
        }
        [HttpGet]
        public IActionResult Deletar1(string email)
        {
            ViewData["Email"] = email;
            return View();
        }

        [HttpPost]
        public IActionResult VoltarDeletar1(string email)
        {
            Dados.Db.contatos.RemoveAll(ct => ct.Email == email);
            return RedirectToAction("Index");
        }



    }
}
