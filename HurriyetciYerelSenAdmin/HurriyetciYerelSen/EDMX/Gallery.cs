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
    
    public partial class Gallery
    {
        public int Id { get; set; }
        public Nullable<int> MediaID { get; set; }
        public Nullable<int> UrlID { get; set; }
        public Nullable<int> GelleryTypeID { get; set; }
        public Nullable<bool> Deleted { get; set; }
    
        public virtual GalleryType GalleryType { get; set; }
        public virtual MediaUrl MediaUrl { get; set; }
        public virtual SystemMedia SystemMedia { get; set; }
    }
}
