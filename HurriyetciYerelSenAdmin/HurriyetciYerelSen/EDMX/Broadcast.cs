//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HurriyetciYerelSen.EDMX
{
    using System;
    using System.Collections.Generic;
    
    public partial class Broadcast
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Broadcast()
        {
            this.FileGalleries = new HashSet<FileGallery>();
        }
    
        public int Id { get; set; }
        public Nullable<int> BroadcastClassID { get; set; }
        public string BroadcastName { get; set; }
        public string BroadcastTextEditor { get; set; }
        public Nullable<bool> Deleted { get; set; }
    
        public virtual BrodcastClass BrodcastClass { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FileGallery> FileGalleries { get; set; }
    }
}