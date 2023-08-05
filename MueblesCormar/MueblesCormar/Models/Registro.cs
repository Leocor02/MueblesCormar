using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MueblesCormar.Models
{
    public class Registro
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentType = "Content-Type";
        public Registro()
        {
            //DetalleRegistros = new HashSet<DetalleRegistro>();
        }

        public int Idregistro { get; set; }
        public DateTime Fecha { get; set; }
        public string Nota { get; set; } = null!;
        public int Idusuario { get; set; }

        public virtual Usuario IdusuarioNavigation { get; set; } = null!;
        //public virtual ICollection<DetalleRegistro> DetalleRegistros { get; set; }
    }
}
