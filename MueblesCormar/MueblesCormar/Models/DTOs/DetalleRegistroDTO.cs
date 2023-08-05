using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MueblesCormar.Models.DTOs
{
    public class DetalleRegistroDTO
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentType = "Content-Type";

        public int IddetalleRegistro { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnidad { get; set; }
        public decimal Subtotal { get; set; }
        public decimal? Impuestos { get; set; }
        public decimal Total { get; set; }
        public int Idregistro { get; set; }
        public int Idproducto { get; set; }
    }
}
