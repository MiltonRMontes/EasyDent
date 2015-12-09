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
    
    public partial class tblHistorial
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblHistorial()
        {
            this.tblAntecedentes = new HashSet<tblAntecedente>();
            this.tblOdontogramas = new HashSet<tblOdontograma>();
        }
    
        public int id_historial { get; set; }
        public string motivo_consulta { get; set; }
        public string enfermedad_actual { get; set; }
        public string antecedentes_familiares { get; set; }
        public int cepilladas_dia { get; set; }
        public string momento_cepilladas { get; set; }
        public string usa_seda_dental { get; set; }
        public string momento_seda { get; set; }
        public int numero_dientes { get; set; }
        public int dientes_cariados { get; set; }
        public int dientes_obturados { get; set; }
        public int dientes_extraidos { get; set; }
        public int dientes_perdidos { get; set; }
        public int total_dientes_cop { get; set; }
        public string labios { get; set; }
        public string carrillos { get; set; }
        public string lengua { get; set; }
        public string amigdalas { get; set; }
        public string paladar_duro { get; set; }
        public string piso_boca { get; set; }
        public string frenillos { get; set; }
        public string mucosa_masticadora { get; set; }
        public string perfil { get; set; }
        public string oclusion { get; set; }
        public string actividad_muscular { get; set; }
        public string atm_palpacion_muscular { get; set; }
        public string diagnostico_presuntivo { get; set; }
        public string diagnostico_definitivo { get; set; }
        public string interpretacion_paraclinicos { get; set; }
        public string pronostico { get; set; }
        public string plan_tratamiento { get; set; }
        public string evolucion { get; set; }
        public int fk_paciente { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAntecedente> tblAntecedentes { get; set; }
        public virtual tblPaciente tblPaciente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOdontograma> tblOdontogramas { get; set; }
    }
}
