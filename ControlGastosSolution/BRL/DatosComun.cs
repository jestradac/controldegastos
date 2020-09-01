using System;
using System.Web;

namespace BRL
{
    public static class DatosComun
    {
        /// <summary>
        /// Variable Global del Contexto
        /// </summary>
        public static BRL.db_ControlGastosEntities _dbContexto = new BRL.db_ControlGastosEntities();

        /// <summary>
        /// Contexto SAFE! >> Generado por Daniel Lobo
        /// </summary>
        public static BRL.db_ControlGastosEntities dbContexto
        {
            get
            {
                //Codigo de Contexto
                String cContexto = "dbGrusep" + HttpContext.Current.GetHashCode().ToString("x");

                //Verificando si ya fue Creado
                if (!HttpContext.Current.Items.Contains(cContexto))
                {
                    //Agrega una nueva Instancia
                    HttpContext.Current.Items.Add(cContexto, new BRL.db_ControlGastosEntities());
                }

                //Devuelve la Instancia
                return (BRL.db_ControlGastosEntities)HttpContext.Current.Items[cContexto];
            }
        }

    }
}
