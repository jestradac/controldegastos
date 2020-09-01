using System;
using System.Collections.Generic;
using System.Linq;

namespace BRL
{
    public partial class tbl_Cuenta
    {
        //Entidades
        BRL.db_ControlGastosEntities objEntidad = new db_ControlGastosEntities();

        /// <summary>
        /// Guardar
        /// </summary>
        /// <returns></returns>
        public bool guardar()
        {
            DatosComun.dbContexto.tbl_Cuenta.Add(this);
            return Convert.ToBoolean(DatosComun.dbContexto.SaveChanges());
        }

        /// <summary>
        /// Modificar
        /// </summary>
        /// <returns></returns>
        public bool modificar()
        {
            return Convert.ToBoolean(DatosComun.dbContexto.SaveChanges());
        }

        /// <summary>
        /// Listar tbl_Cuentas
        /// </summary>
        /// <returns></returns>
        public List<BRL.tbl_Cuenta> listartbl_Cuentas(int auxUsuario)
        {
            return (from C in DatosComun.dbContexto.tbl_Cuenta
                    where C.eliminado.Equals(false)
                    && C.idUsuario.Equals(auxUsuario)
                    orderby C.nombre ascending
                    select C).ToList();
        }

        /// <summary>
        /// Traer tbl_Cuenta por ID
        /// </summary>
        /// <param name="auxtbl_Cuenta"></param>
        /// <returns></returns>
        public BRL.tbl_Cuenta traertbl_Cuenta(int auxtbl_Cuenta)
        {
            return (from C in DatosComun.dbContexto.tbl_Cuenta
                    where C.idCuenta.Equals(auxtbl_Cuenta)
                    select C).Take(1).Single();
        }
        /// <summary>
        /// Verificar si existe Nombre
        /// </summary>
        /// <param name="auxNombre"></param>
        /// <returns></returns>
        public bool existeNombre(String auxNombre, int auxUsuario)
        {
            try
            {
                return (from C in BRL.DatosComun.dbContexto.tbl_Cuenta
                        where C.nombre.ToLower().Trim().Equals(auxNombre.ToLower().Trim())
                        && C.idUsuario.Equals(auxUsuario)
                        select C).Count() > 0;
            }
            catch
            {
                return false;
            }
        }
        public decimal verSaldo(int auxSaldo)
        {
            try
            {
                return
                        (from C in BRL.DatosComun.dbContexto.tbl_Transaccion
                        where C.idCuenta.Equals(auxSaldo)
                        select C.monto
                        ).Sum();
            }
            catch
            {
                return -1;
            }
        }
    }
}
