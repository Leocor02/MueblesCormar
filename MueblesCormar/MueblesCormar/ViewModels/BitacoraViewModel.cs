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

        public async Task<bool> UpdateBitacora(int idBitacora, string pAccion, DateTime pFecha, int idUsuario)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MiBitacora.Idbitacora = idBitacora;
                MiBitacora.Accion = pAccion;
                MiBitacora.Fecha = pFecha;
                MiBitacora.Idusuario = idUsuario;

                bool R = await MiBitacora.UpdateBitacora(idBitacora);

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

        public async Task<bool> DeleteBitacora(int idBitacora)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                bool R = await MiBitacora.DeleteBitacora(idBitacora);

                return R;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            { IsBusy = false; }

        }


    }
}
