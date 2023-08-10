using MueblesCormar.Models;
using MueblesCormar.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MueblesCormar.ViewModels
{
    public class BitacoraViewModel : BaseViewModel
    {
        public Bitacora MiBitacora { get; set; }

        public BitacoraViewModel()
        {
            MiBitacora = new Bitacora();
        }
        public async Task<bool> InsertarEnBitacora(string pAccion,
                                                   DateTime pFecha,
                                                   int IdUsuario)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MiBitacora.Accion = pAccion;
                MiBitacora.Fecha = pFecha;
                MiBitacora.Idusuario = IdUsuario;

                bool R = await MiBitacora.InsertarEnBitacora();

                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
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


        //    InsertarEnBitacora(accion, pFecha, usuario);
        //}

        public async Task<Bitacora> GetDataBitacora(int idBitacora)
        {
            try
            {
                Bitacora bitacora = new Bitacora();

                bitacora = await MiBitacora.GetDataBitacora(idBitacora);

                if (bitacora == null)
                {
                    return null;
                }
                else
                {
                    return bitacora;
                }

            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<ObservableCollection<Bitacora>> GetFullListaBitacora()
        {
            if (IsBusy)
            {
                return null;
            }
            else
            {
                IsBusy = true;

                try
                {
                    ObservableCollection<Bitacora> list = new ObservableCollection<Bitacora>();

                    list = await MiBitacora.GetListaBitacora();

                    if (list == null)
                    {
                        return null;
                    }

                    return list;

                }
                catch (Exception)
                {
                    return null;
                }
                finally { IsBusy = false; }

            }

        }


    }
}
