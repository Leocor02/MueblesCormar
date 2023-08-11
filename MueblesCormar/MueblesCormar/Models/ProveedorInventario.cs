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
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentType = "Content-Type"; 

        public int IdproveedorInventario { get; set; }
        public int Idproveedor { get; set; }
        public int Idproducto { get; set; }

        public virtual Inventario IdproductoNavigation { get; set; } = null!;
        public virtual Proveedor IdproveedorNavigation { get; set; } = null!;

        public async Task<bool> AddProveedorInventario()
        {
            try
            {
                string RouteSufix = string.Format("ProveedorInventarios");
                string FinalURL = Services.CnnToAPI.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Post);

                //Agregar la info de seguridad del api, en este caso apikey
                request.AddHeader(Services.CnnToAPI.ApiKeyName, Services.CnnToAPI.ApiKeyValue);
                request.AddHeader(contentType, mimetype);

                //var settings = new JsonSerializerSettings();
                //settings.NullValueHandling = NullValueHandling.Ignore;

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
