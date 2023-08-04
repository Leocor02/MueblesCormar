using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MueblesCormar.Models
{
    public class Inventario
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentType = "Content-Type";

        public Inventario()
        {
            //DetalleRegistros = new HashSet<DetalleRegistro>();
            //ProveedorInventarios = new HashSet<ProveedorInventario>();
        }

        public int Idproducto { get; set; }
        public string Nombre { get; set; } = null!;
        public int Cantidad { get; set; }
        public string Descripcion { get; set; } = null!;
        public string ImagenProducto { get; set; } = null!;
        public decimal PrecioUnidad { get; set; }

        //public virtual ICollection<DetalleRegistro> DetalleRegistros { get; set; }
        //public virtual ICollection<ProveedorInventario> ProveedorInventarios { get; set; }

        public async Task<bool> AddProducto()
        {
            try
            {
                string RouteSufix = string.Format("Inventarios");
                string FinalURL = Services.CnnToAPI.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Post);

                //Agregar la info de seguridad del api, en este caso apikey
                request.AddHeader(Services.CnnToAPI.ApiKeyName, Services.CnnToAPI.ApiKeyValue);
                request.AddHeader(contentType, mimetype);

                //tenemos que serializar la clase para poderla enviar al api
                string SerialClass = JsonConvert.SerializeObject(this);

                request.AddBody(SerialClass, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }
        }
    }
}
