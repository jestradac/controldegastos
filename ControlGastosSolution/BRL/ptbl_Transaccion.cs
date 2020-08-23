using System;
using System.Collections.Generic;
using System.Linq;

namespace BRL
{
    public partial class tbl_Transaccion
    {
        //Entidades
        BRL.db_ControlGastosEntities1 objEntidad = new db_ControlGastosEntities1();

        /// <summary>
        /// Guardar
        /// </summary>
        /// <returns></returns>
        public bool guardar()
        {
            DatosComun.dbContexto.tbl_Transaccion.Add(this);
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
        /// Listar tbl_Transaccions
        /// </summary>
        /// <returns></returns>
        public List<BRL.tbl_Transaccion> listartbl_Transaccions()
        {
            return (from T in DatosComun.dbContexto.tbl_Transaccion
                    select T).ToList();
        }

        /// <summary>
        /// Traer tbl_Transaccion por ID
        /// </summary>
        /// <param name="auxtbl_Transaccion"></param>
        /// <returns></returns>
        public BRL.tbl_Transaccion traertbl_Transaccion(int auxtbl_Transaccion)
        {
            return (from T in DatosComun.dbContexto.tbl_Transaccion
                    where T.idTransaccion.Equals(auxtbl_Transaccion)
                    select T).Take(1).Single();
        }
    }
}
