//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BRL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Transaccion
    {
        public int idTransaccion { get; set; }
        public decimal monto { get; set; }
        public System.DateTime fechaTransaccion { get; set; }
        public int idCuenta { get; set; }
        public int idConcepto { get; set; }
        public Nullable<bool> idTransaccionRef { get; set; }
        public bool eliminado { get; set; }
    
        public virtual tbl_Concepto tbl_Concepto { get; set; }
        public virtual tbl_Cuenta tbl_Cuenta { get; set; }
    }
}