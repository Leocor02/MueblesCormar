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
    public class ProveedorInventarioDTO
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentType = "Content-Type";

        public int IdproveedorInventario { get; set; }
        public int Idproveedor { get; set; }
        public int Idproducto { get; set; }
        public string NombreProveedor { get; set; } = null!;
        public string NombreProducto { get; set; } = null!;

        //función para agregar un usuario a la base de datos
        public async Task<bool> AgregarProveedorInventario()
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

        public async Task<ProveedorInventarioDTO> GetDataProveedorInventario(int idProveedorInventario)
        {
            try
            {
                string RouteSufix = string.Format("ProveedorInventario/GetDataProveedorInventario?idProveedorInventario={0}", idProveedorInventario);

                string FinalURL = Services.CnnToAPI.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Get);

                //agregar la info de seguridad del api, en este caso ApiKey
                request.AddHeader(Services.CnnToAPI.ApiKeyName, Services.CnnToAPI.ApiKeyValue);
                request.AddHeader(contentType, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<List<ProveedorInventarioDTO>>(response.Content);

                    var item = list[0];

                    return item;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                //TODO: guardar estos errores en una bitácora para su posterior analisis
                throw;
            }
        }

        public async Task<ObservableCollection<ProveedorInventarioDTO>> GetListaProveedorInventario()
        {
            try
            {
                string RouteSufix = string.Format("ProveedorInventarios/GetListaProveedorInventario");

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
                    var list = JsonConvert.DeserializeObject<ObservableCollection<ProveedorInventarioDTO>>(response.Content);

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

        public async Task<bool> ActualizarProveedorInventario(int idProveedorInventario)
        {
            try
            {
                string RouteSufix = string.Format("ProveedorInventarios/{0}", idProveedorInventario);
                string FinalURL = Services.CnnToAPI.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Put);

                //Agregar la info de seguridad del api, en este caso apikey
                request.AddHeader(Services.CnnToAPI.ApiKeyName, Services.CnnToAPI.ApiKeyValue);
                request.AddHeader(contentType, mimetype);

                //tenemos que serializar la clase para poderla enviar al api
                string SerialClass = JsonConvert.SerializeObject(this);

                request.AddBody(SerialClass, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
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

        public async Task<bool> DeleteProveedorInventario(int idProveedorInventario)
        {
            try
            {
                string RouteSufix = string.Format("ProveedorInventarios/{0}", idProveedorInventario);
                string FinalURL = Services.CnnToAPI.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Delete);

                request.AddHeader(Services.CnnToAPI.ApiKeyName, Services.CnnToAPI.ApiKeyValue);
                request.AddHeader(contentType, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.NoContent)
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
