using System;
using System.Collections.Generic;
using System.Linq;

namespace BRL
{
    public partial class tbl_Concepto
    {
        //Entidades
        BRL.db_ControlGastosEntities objEntidad = new db_ControlGastosEntities();

        /// <summary>
        /// Guardar
        /// </summary>
        /// <returns></returns>
        public bool guardar()
        {
            DatosComun.dbContexto.tbl_Concepto.Add(this);
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
        /// Listar tbl_Conceptos
        /// </summary>
        /// <returns></returns>
        public List<BRL.tbl_Concepto> listartbl_Conceptos(int idUsuario, bool esEgreso)
        {
            return (from C in DatosComun.dbContexto.tbl_Concepto
                    where C.eliminado.Equals(false)
                    && C.idUsuario.Equals(idUsuario)
                    // 1 y 2 son Traspaso
                    && (C.idConcepto > 2)
                    && C.tipoTransaccion.Equals(esEgreso)
                    orderby C.nombre ascending
                    select C).ToList();
        }

        /// <summary>
        /// Traer tbl_Concepto por ID
        /// </summary>
        /// <param name="auxtbl_Concepto"></param>
        /// <returns></returns>
        public BRL.tbl_Concepto traertbl_Concepto(int auxtbl_Concepto)
        {
            return (from C in DatosComun.dbContexto.tbl_Concepto
                    where C.idConcepto.Equals(auxtbl_Concepto)
                    select C).Take(1).Single();
        }
        /// <summary>
        /// Verificar si existe el Nombre del Concepto
        /// </summary>
        /// <param name="auxNombre"></param>
        /// <returns></returns>
        public bool existeCombinacion(String auxNombre, Boolean auxTipoTransaccion)
        {
            try
            {
                return (from C in BRL.DatosComun.dbContexto.tbl_Concepto
                        where C.nombre.ToLower().Trim().Equals(auxNombre.ToLower().Trim())
                        && C.tipoTransaccion.Equals(auxTipoTransaccion)
                        select C).Count() > 0;
            }
            catch
            {
                return false;
            }
        }
        public List<BRL.tbl_Concepto> listarTipoTransaccion(bool auxTipoTransaccion)
        {
            try
            {
                return (from C in BRL.DatosComun.dbContexto.tbl_Concepto
                        where C.tipoTransaccion.Equals(auxTipoTransaccion)
                        select C).ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
