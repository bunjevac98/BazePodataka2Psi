//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Baze2PRojekat
{
    using System;
    using System.Collections.Generic;
    
    public partial class Snima
    {
        public int BendIdBenda { get; set; }
        public int AlbumIdAlb { get; set; }
    
        public virtual Bend Bend { get; set; }
        public virtual Album Album { get; set; }
    }
}