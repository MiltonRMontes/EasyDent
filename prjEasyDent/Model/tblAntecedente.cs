//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace prjEasyDent.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblAntecedente
    {
        public int id_antecedente { get; set; }
        public int fk_historial { get; set; }
        public int fk_patologia { get; set; }
        public string observacion { get; set; }
    
        public virtual tblHistorial tblHistorial { get; set; }
        public virtual tblPatologia tblPatologia { get; set; }
    }
}
