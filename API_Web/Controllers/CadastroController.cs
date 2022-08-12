using API_Web.Data;
using API_Web.Models;
using Microsoft.AspNetCore.Mvc;


namespace API_Web.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class CadastroController : Controller
    {
        private readonly Contexto _context;

        public CadastroController(Contexto context)
        {
            _context = context;
        }

        // ---------- GET DE LISTA GERAL ----------
        [Route("Cadastro")]
        [HttpGet]
        public ActionResult<List<CadastroModel>> Cadastro()
        {
            List<CadastroModel> cadastroModel = new List<CadastroModel>();

            var cad = _context.TB_CADASTRO.ToList();

            foreach (var item in cad)
            {
                CadastroModel dados = new CadastroModel()
                {
                    id = item.id,
                    Nome = item.Nome,
                    Telefone = item.Telefone,
                    Email = item.Email,
                    Endereco = item.Endereco
                };
                cadastroModel.Add(dados);
            }

            return Json(cadastroModel);
        }

        // ---------- UPDATE DO DADO ----------
        [Route("Update")]
        [HttpPost]
        public ActionResult<List<CadastroModel>> Update(CadastroModel dados)
        {

            var cad = _context.TB_CADASTRO.Where(x => x.id == dados.id).FirstOrDefault();

            if (cad != null)
            {
                cad.id = dados.id;
                cad.Nome = dados.Nome;
                cad.Telefone = dados.Telefone;
                cad.Email = dados.Email;
                cad.Endereco = dados.Endereco;
                _context.SaveChanges();
            }

            return Json(cad);
        }

        // ---------- BUSCANDO DADO POR ID ----------
        [Route("Get/{id}")]
        [HttpGet]
        public ActionResult<CadastroModel> Get(int id)
        {
            var cad = _context.TB_CADASTRO.Where(x => x.id == id).FirstOrDefault();
            return Json(cad);
        }

        // ---------- INSERIR DADO ----------
        [Route("Insert")]
        [HttpPost]
        public ActionResult<List<CadastroModel>> Insert(CadastroModel dados)
        {

            TB_CADASTRO tB_CADASTRO = new TB_CADASTRO();

            tB_CADASTRO.Nome = dados.Nome;
            tB_CADASTRO.Telefone = dados.Telefone;
            tB_CADASTRO.Email = dados.Email;
            tB_CADASTRO.Endereco = dados.Endereco;
            _context.TB_CADASTRO.Add(tB_CADASTRO);
            _context.SaveChanges();

            return Json(tB_CADASTRO);
        }

        // ---------- DELETAR DADO ----------
        [Route("Delete")]
        [HttpPost]
        public bool Delete(IdModel dados)
        {
            try
            {
                //int id1 = int.Parse(codigo);
                var cad = _context.TB_CADASTRO.Where(x => x.id == dados.id).FirstOrDefault();

                if (cad != null)
                {
                    _context.TB_CADASTRO.Remove(cad);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
