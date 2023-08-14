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
        public async Task<bool> AddBitacora(int tipoAccion,
                                            string pNombreTabla,
                                            int pUsuarioId
                                            )
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MiBitacora.EjecutarAccion(tipoAccion, pNombreTabla, pUsuarioId);

                bool R = await MiBitacora.AddBitacora();

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


    }
}
