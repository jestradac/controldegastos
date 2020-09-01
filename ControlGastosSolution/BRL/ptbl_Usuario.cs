using System;
using System.Collections.Generic;
using System.Linq;

namespace BRL
{
    public partial class tbl_Usuario
    {
        //Entidades
        BRL.db_ControlGastosEntities objEntidad = new db_ControlGastosEntities();

        /// <summary>
        /// Guardar
        /// </summary>
        /// <returns></returns>
        public bool guardar()
        {
            DatosComun.dbContexto.tbl_Usuario.Add(this);
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
        /// Listar tbl_Usuarios
        /// </summary>
        /// <returns></returns>
        public List<BRL.tbl_Usuario> listartbl_Usuarios()
        {
            return (from C in DatosComun.dbContexto.tbl_Usuario
                    orderby C.nombreCompleto ascending
                    select C).ToList();
        }

        /// <summary>
        /// Traer tbl_Usuario por ID
        /// </summary>
        /// <param name="auxtbl_Usuario"></param>
        /// <returns></returns>
        public BRL.tbl_Usuario traertbl_Usuario(int auxtbl_Usuario)
        {
            return (from U in DatosComun.dbContexto.tbl_Usuario
                    where U.idUsuario.Equals(auxtbl_Usuario)
                    select U).Take(1).Single();
        }
        /// <summary>
        /// Verificar si el Correo Electrónico existe
        /// </summary>
        /// <param name="auxCorreoElectronico"></param>
        /// <returns></returns>
        public bool existeEmail(String auxCorreoElectronico)
        {
            try
            {
                return (from U in BRL.DatosComun.dbContexto.tbl_Usuario
                        where U.correoElectronico.ToLower().Trim().Equals(auxCorreoElectronico.ToLower().Trim())
                        select U).Count() > 0;
            }
            catch
            {
                return false;
            }
        }
        public BRL.tbl_Usuario verificarCombinacion(String auxCorreoElectronico, String auxContrasena)
        {
            try
            {
                return (from U in BRL.DatosComun.dbContexto.tbl_Usuario
                        where U.correoElectronico.ToLower().Trim().Equals(auxCorreoElectronico.ToLower().Trim())
                        && U.contrasena.Trim().Equals(auxContrasena.Trim())
                        select U).First();
            }
            catch
            {
                return null;
            }
        }
    }
}
