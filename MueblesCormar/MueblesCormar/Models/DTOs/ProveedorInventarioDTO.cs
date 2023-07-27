using System;
using System.Collections.Generic;
using System.Text;

namespace MueblesCormar.Models.DTOs
{
    public class ProveedorInventarioDTO
    {
        public int IdproveedorInventario { get; set; }
        public int Idproveedor { get; set; }
        public int Idproducto { get; set; }
    }
}
