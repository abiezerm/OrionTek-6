using Domain.Common;

namespace Domain.Entities
{
    public class Direccion : EntityBase<int>
    {
        public string Descripcion { get; set; }
        public byte IdEstatus { get; set; }
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }
    }
}