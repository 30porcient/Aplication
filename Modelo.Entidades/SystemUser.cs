using System.ComponentModel.DataAnnotations;

namespace Modelo.Entidades
{
    public class SystemUser
    {
        [Key]
        [Required]
        [StringLength(8)]
        public string Usuario { get; set; }

        [Required]
        [StringLength(8)]
        public string Clave { get; set; }
    }
}
