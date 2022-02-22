using Microsoft.AspNetCore.Mvc;
using Repository.EFCore.Repositories;

namespace PresentationMVC.Controllers
{
    public class DireccionController : Controller
    {
        private readonly ClienteRepository ClienteRepository;
        private readonly DireccionRepository DireccionRepository;
        public DireccionController(ClienteRepository clienteRepository, DireccionRepository direccionRepository)
            => (ClienteRepository, DireccionRepository) = (clienteRepository, direccionRepository);

        public IActionResult Index()
        {
            List<PresentationMVC.ViewModels.ClienteViewModel> Resultado = new List<ViewModels.ClienteViewModel>();
            var Clientes = ClienteRepository.GetList(x => true).Result;

            foreach (var cliente in Clientes)
                Resultado.Add(new ViewModels.ClienteViewModel() { Id = cliente.Id, Nombre = cliente.Nombre});

            return View(Resultado);
        }

        public IActionResult Consulta(int clienteId)
        {
            return Json(new { DireccionRepository.GetList(x => x.ClienteId == clienteId).Result });
        }
    }
}