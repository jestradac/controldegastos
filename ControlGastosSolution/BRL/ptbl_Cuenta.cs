using System;
using System.Collections.Generic;
using System.Linq;

namespace BRL
{
    public partial class tbl_Cuenta
    {
        //Entidades
        BRL.db_ControlGastosEntities1 objEntidad = new db_ControlGastosEntities1();

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
        public List<BRL.tbl_Cuenta> listartbl_Cuentas()
        {
            return (from C in DatosComun.dbContexto.tbl_Cuenta
                    where C.eliminado.Equals(false)
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
        public bool existeNombre(String auxNombre)
        {
            try
            {
                return (from C in BRL.DatosComun.dbContexto.tbl_Cuenta
                        where C.nombre.ToLower().Trim().Equals(auxNombre.ToLower().Trim())
                        select C).Count() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
