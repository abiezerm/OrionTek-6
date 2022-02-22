using Domain.Common;

namespace Domain.Entities
{
    public class Cliente : EntityBase<int>
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        public List<Direccion> Direcciones { get; set; }
    }
}