using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MueblesCormar.Models.DTOs
{
    public class InventarioDTO
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentType = "Content-Type";

        public int Idproducto { get; set; }
        public string Nombre { get; set; } = null!;
        public int Cantidad { get; set; }
        public string Descripcion { get; set; } = null!;
        public string ImagenProducto { get; set; } = null!;
        public decimal PrecioUnidad { get; set; }

        public async Task<ObservableCollection<InventarioDTO>> GetListaInventario()
        {
            try
            {
                string RouteSufix = string.Format("Inventarios/GetListaProducto");

                string FinalURL = Services.CnnToAPI.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Get);

                //Agregar la info de seguridad del api, en este caso apikey
                request.AddHeader(Services.CnnToAPI.ApiKeyName, Services.CnnToAPI.ApiKeyValue);
                request.AddHeader(contentType, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<ObservableCollection<InventarioDTO>>(response.Content);

                    return list;
                }
                else
                {
                    return null;
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
