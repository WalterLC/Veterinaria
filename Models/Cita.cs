using System;
using System.ComponentModel.DataAnnotations;
namespace Veterinaria.Models
{
    public  class Cita
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public int MascotaID { get; set; }
        public Mascota Mascota { get; set ;}
        public int VeterinarioID { get; set; }
        public Veterinario Veterinario { get; set; }
        public int MedicamentoID { get; set; }
        public Medicamento Medicamento { get; set; }
    }
}
