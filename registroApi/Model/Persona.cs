using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace registroApi.Model
{
    public class Persona
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public DateTime fechaNacimiento { get; set; }
    }
}
