using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MueblesCormar.Models
{
    public class ProveedorInventario
    {
        public int IdproveedorInventario { get; set; }
        public int Idproveedor { get; set; }
        public int Idproducto { get; set; }

        public virtual Inventario IdproductoNavigation { get; set; } = null!;
        public virtual Proveedor IdproveedorNavigation { get; set; } = null!;


    }
}
