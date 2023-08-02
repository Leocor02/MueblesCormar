using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using MueblesCormar.Models;
using MueblesCormar.Models.DTOs;

namespace MueblesCormar.ViewModels
{
    public class ProviderViewModel : BaseViewModel
    {
        public Proveedor MiProveedor { get; set; }
        public ProveedorDTO MiProveedorDTO { get; set; }

        public ProviderViewModel()
        {
            MiProveedor = new Proveedor();
            MiProveedorDTO = new ProveedorDTO();
        }

        public async Task<bool> AgregarNuevoProveedor(string pNombre,
                                                      string pDireccion)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MiProveedor.Nombre = pNombre;
                MiProveedor.Direccion = pDireccion;
                

                bool R = await MiProveedor.AgregarProvedor();

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

        //función para actualizar proveedor
        public async Task<bool> ActualizarProveedor(int idProveedor, string pNombre, string pDireccion)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MiProveedorDTO.Idproveedor = idProveedor;
                MiProveedorDTO.Nombre = pNombre;
                MiProveedorDTO.Direccion = pDireccion;


                bool R = await MiProveedorDTO.ActualizarProveedor(idProveedor);

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

        public async Task<ProveedorDTO> GetDataProveedor(int idProveedor)
        {
            try
            {
                ProveedorDTO proveedor = new ProveedorDTO();

                proveedor = await MiProveedorDTO.GetDataProveedor(idProveedor);

                if (proveedor == null)
                {
                    return null;
                }
                else
                {
                    return proveedor;
                }

            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<ObservableCollection<ProveedorDTO>> GetFullListaProveedor()
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
                    ObservableCollection<ProveedorDTO> list = new ObservableCollection<ProveedorDTO>();

                    list = await MiProveedorDTO.GetListaProveedor();

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

        public async Task<bool> DeleteProveedor(int idProveedor)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                bool R = await MiProveedorDTO.DeleteProveedor(idProveedor);

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
