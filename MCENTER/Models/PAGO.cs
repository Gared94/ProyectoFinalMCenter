//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MCENTER.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PAGO
    {
        public int id_pago { get; set; }
        public Nullable<int> Id { get; set; }
        public string tarjeta { get; set; }
        public System.DateTime fecharVencimiento { get; set; }
        public string titular { get; set; }
    
        public virtual Venta Venta { get; set; }
    }
}