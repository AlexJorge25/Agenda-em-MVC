using AgendaMVC.Crud;
using AgendaMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly CrudContato _crudContato;

        public ContatoController()
        {
            _crudContato = new CrudContato();
        }

        public IActionResult Index()
        {
            List<Contato> contatos = _crudContato.Consultar();
            return View(contatos);
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
            /*Dados.Db.contatos.Add(contato);*/
            new Crud.CrudContato().salvar(contato);
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
        public IActionResult Deletar1(int id)
        {
            ViewData["Id"] = id;
            return View();
        }

        [HttpPost]
        public IActionResult VoltarDeletar1(int id)
        {
            new Crud.CrudContato().Deletar(id);
            return RedirectToAction("Index");
        }



    }
}
