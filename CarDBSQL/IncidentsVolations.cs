//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarDBSQL
{
    using System;
    using System.Collections.Generic;
    
    public partial class IncidentsVolations
    {
        public long idIncident { get; set; }
        public long idVolation { get; set; }
        public decimal penalty { get; set; }
        public long statePenalty { get; set; }
    
        public virtual Incident Incident { get; set; }
        public virtual State State { get; set; }
        public virtual Violation Violation { get; set; }
    }
}
