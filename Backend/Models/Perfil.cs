using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Backend.Models
{
    public partial class Perfil
    {
       /* public Perfil()
        {
            Usuario = new HashSet<Usuario>();
        }*/

        public int IdPerfil { get; set; }
        public string NombrePerfil { get; set; }

       // [JsonIgnore]
      //  public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
