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
    
    public partial class tblPaciente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPaciente()
        {
            this.tblCitas = new HashSet<tblCita>();
            this.tblHistorials = new HashSet<tblHistorial>();
        }
    
        public int id_paciente { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string tipo_documento { get; set; }
        public string numero_documento { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public Nullable<System.DateTime> fecha_nacimiento { get; set; }
        public string direccion { get; set; }
        public int estado { get; set; }
        public string estado_civil { get; set; }
        public string sexo { get; set; }
        public string ocupacion { get; set; }
        public string celular { get; set; }
        public string nombre_acudiente { get; set; }
        public string relacion_acudiente { get; set; }
        public string telefono_acudiente { get; set; }
        public int fk_odontologo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCita> tblCitas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblHistorial> tblHistorials { get; set; }
        public virtual tblUsuario tblUsuario { get; set; }
    }
}
