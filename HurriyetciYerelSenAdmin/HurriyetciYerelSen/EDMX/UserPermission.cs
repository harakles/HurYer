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
    
    public partial class UserPermission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserPermission()
        {
            this.UserPages = new HashSet<UserPage>();
        }
    
        public int Id { get; set; }
        public string PermissionName { get; set; }
        public string Icon { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public string Link { get; set; }
        public Nullable<int> DropdownID { get; set; }
        public string UrlParameter { get; set; }
    
        public virtual Dropdown Dropdown { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserPage> UserPages { get; set; }
    }
}