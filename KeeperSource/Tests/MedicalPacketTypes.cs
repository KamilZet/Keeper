//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tests
{
    using System;
    using System.Collections.Generic;
    
    public partial class MedicalPacketTypes
    {
        public MedicalPacketTypes()
        {
            this.ConfiguredMedicalPacket = new HashSet<ConfiguredMedicalPacket>();
            this.MedicalPacketTypeSettings = new HashSet<MedicalPacketTypeSettings>();
        }
    
        public int MedicalPacketID { get; set; }
        public string MedicalPacketName { get; set; }
    
        public virtual ICollection<ConfiguredMedicalPacket> ConfiguredMedicalPacket { get; set; }
        public virtual ICollection<MedicalPacketTypeSettings> MedicalPacketTypeSettings { get; set; }
    }
}
