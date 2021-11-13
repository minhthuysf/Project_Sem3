//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RailwayReservationAndManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TrainSchedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrainSchedule()
        {
            this.BetweenStations = new HashSet<BetweenStation>();
        }
    
        public int TrainID { get; set; }
        public int StationID { get; set; }
        public string StartStationID { get; set; }
        public string EndStationID { get; set; }
        public int Distances { get; set; }
        public System.TimeSpan ArrivalTime { get; set; }
        public System.TimeSpan DepartureTime { get; set; }
        public int Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BetweenStation> BetweenStations { get; set; }
        public virtual Station Station { get; set; }
        public virtual Train Train { get; set; }
    }
}
