namespace BSTicketSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Map")]
    public partial class Map
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Map()
        {
            Activity = new HashSet<Activity>();
        }

        public int Id { get; set; }

        public int Seat_Quantity { get; set; }

        public int Seat_Id { get; set; }

        [StringLength(50)]
        public string Map_Name { get; set; }

        public bool IsAgree { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activity { get; set; }

        public virtual Seat Seat { get; set; }
    }
}
