using Domain.Common;

namespace Domain.Entities
{
    public class Estatu : EntityBase<byte>
    {
        public string Descripcion { get; set; }
    }
}