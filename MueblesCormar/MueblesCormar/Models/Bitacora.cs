using MueblesCormar.Models.DTOs;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MueblesCormar.Models
{
    public class Bitacora
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentType = "Content-Type";

        public int Idbitacora { get; set; }
        public string Accion { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public int Idusuario { get; set; }

        public virtual Usuario IdusuarioNavigation { get; set; } = null!;

        public async Task<bool> InsertarEnBitacora()
        {
            try
            {
                string RouteSufix = string.Format("Bitacoras");
                string FinalURL = Services.CnnToAPI.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Post);

                request.AddHeader(Services.CnnToAPI.ApiKeyName, Services.CnnToAPI.ApiKeyValue);
                request.AddHeader(contentType, mimetype);

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

        //public void EjecutarAccion(int tipoAccion, string pNombreTabla, Usuario pUsuario)
        //{
        //    string accion = "";

        //    switch (tipoAccion)
        //    {
        //        case 1:
        //            accion = "se insertó en la tabla: " + pNombreTabla;
        //            break;
        //        case 2:
        //            accion = "se modificó en la tabla: " + pNombreTabla;
        //            break;
        //        case 3:
        //            accion = "se eliminó en la tabla: " + pNombreTabla;
        //            break;
        //        case 4:
        //            accion = "se activó un dato en la tabla: " + pNombreTabla;
        //            break;
        //    }

        //    string usuario = "";

        //    switch (pUsuario.IdrolUsuario)
        //    {
        //        case 1:
        //            usuario = "Admin";
        //            break;
        //        case 2:
        //            usuario = pUsuario.Nombre;
        //            break;

        //    }

        //    int idTipoUsuario = pUsuario.IdrolUsuario;

        //    InsertarEnBitacora(accion, usuario, idTipoUsuario);
        //}

        public async Task<Bitacora> GetDataBitacora(int idBitacora)
        {
            try
            {
                string RouteSufix = string.Format("Bitacoras/GetDataBitacora?idBitacora={0}", idBitacora);

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
                    var list = JsonConvert.DeserializeObject<List<Bitacora>>(response.Content);

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

        public async Task<ObservableCollection<Bitacora>> GetListaBitacora()
        {
            try
            {
                string RouteSufix = string.Format("Bitacoras/GetListaBitacora");

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
                    var list = JsonConvert.DeserializeObject<ObservableCollection<Bitacora>>(response.Content);

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
