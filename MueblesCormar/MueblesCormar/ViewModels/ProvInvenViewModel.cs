using MueblesCormar.Models;
using MueblesCormar.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MueblesCormar.ViewModels
{
    public class ProvInvenViewModel : BaseViewModel
    {
        public ProveedorInventario MiProveedorInventario { get; set; }
        public ProveedorInventarioDTO MiProveedorInventarioDTO { get; set; }

        public ProvInvenViewModel()
        {
            MiProveedorInventario = new ProveedorInventario();
            MiProveedorInventarioDTO = new ProveedorInventarioDTO();
        }

        public async Task<bool> AddProveedorInventario(int pIdProveedor,
                                                                int pIdProducto,
                                                                string pNombreProveedor,
                                                                string pNombreProducto)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MiProveedorInventarioDTO.Idproveedor = pIdProveedor;
                MiProveedorInventarioDTO.Idproducto = pIdProducto;
                MiProveedorInventarioDTO.NombreProveedor = pNombreProveedor;
                MiProveedorInventarioDTO.NombreProducto = pNombreProducto;


                bool R = await MiProveedorInventarioDTO.AddProveedorInventario();

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

        public async Task<ProveedorInventarioDTO> GetDataProveedorInventario(int idProveedorInventario)
        {
            try
            {
                ProveedorInventarioDTO proveedorInventario = new ProveedorInventarioDTO();

                proveedorInventario = await MiProveedorInventarioDTO.GetDataProveedorInventario(idProveedorInventario);

                if (proveedorInventario == null)
                {
                    return null;
                }
                else
                {
                    return proveedorInventario;
                }

            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ObservableCollection<ProveedorInventarioDTO>> GetFullListaProveedorInventario()
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
                    ObservableCollection<ProveedorInventarioDTO> list = new ObservableCollection<ProveedorInventarioDTO>();

                    list = await MiProveedorInventarioDTO.GetListaProveedorInventario();

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

        //función para actualizar proveedor inventario
        public async Task<bool> UpdateProveedorInventario(int idProveedorInventario,
                                                              int pIdProveedor,
                                                              int pIdProducto,
                                                              string pNombreProveedor,
                                                              string pNombreProducto)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MiProveedorInventarioDTO.IdproveedorInventario = idProveedorInventario;
                MiProveedorInventarioDTO.Idproveedor = pIdProveedor;
                MiProveedorInventarioDTO.Idproducto = pIdProducto;
                MiProveedorInventarioDTO.NombreProveedor = pNombreProveedor;
                MiProveedorInventarioDTO.NombreProducto = pNombreProducto;


                bool R = await MiProveedorInventarioDTO.UpdateProveedorInventario(idProveedorInventario);

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

        public async Task<bool> DeleteProveedorInventario(int idProveedorInventario)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                bool R = await MiProveedorInventarioDTO.DeleteProveedorInventario(idProveedorInventario);

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
