using Microsoft.AspNetCore.Mvc;
using PresentationMVC.ViewModels;
using Repository.EFCore.Repositories;

namespace PresentationMVC.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteRepository ClienteRepository;
        private readonly DireccionRepository DireccionRepository;
        public ClienteController(ClienteRepository clienteRepository, DireccionRepository direccionRepository)
            => (ClienteRepository, DireccionRepository) = (clienteRepository, direccionRepository);

        // GET: ClienteController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(ClienteViewModel viewModel)
        {
            ClienteRepository.Create(new Domain.Entities.Cliente() { Nombre = viewModel.Nombre, Apellidos = viewModel.Apellidos, Direcciones = new List<Domain.Entities.Direccion>() { new Domain.Entities.Direccion() { Descripcion = viewModel.Direccion, IdEstatus = 1 } } });
            return RedirectToAction(nameof(Listado));
        }

        public ActionResult Listado()
        {
            List<ClienteViewModel> Resultado = new List<ClienteViewModel>();
            var Clientes = ClienteRepository.GetList(x => true, "Direcciones").Result;
            foreach (var cliente in Clientes)
                Resultado.Add(new ClienteViewModel() { Apellidos = cliente.Apellidos, Nombre = cliente.Nombre, Direccion = cliente.Direcciones.FirstOrDefault(x => x.IdEstatus == 1)!.Descripcion, Id = cliente.Id });

            return View(Resultado);
        }

        public ActionResult Actualizar(int id, string propertyName, string value)
        {
            bool status = false;
            switch (propertyName)
            {
                case "Direccion":
                    //Creamos la dirección nueva
                    status = DireccionRepository.Create(new Domain.Entities.Direccion() { ClienteId = id, Descripcion = value, IdEstatus = 1 }).Result != null;
                    if (status)
                    {
                        //Actualizamos las direcciones anteriores
                        var clienteDirecciones = ClienteRepository.GetFirstOrDefault(x => x.Id == id, "Direcciones").Result;
                        foreach (var direccion in clienteDirecciones.Direcciones.Where(x => x.IdEstatus == 1))
                            DireccionRepository.Update(x => x.Id == direccion.Id, "IdEstatus", (byte)2);
                    }
                    break;
                default:
                    status = ClienteRepository.Update(x => x.Id == id, propertyName, value).Result;
                    break;
            }

            return Json(new { status, value });
        }
    }
}