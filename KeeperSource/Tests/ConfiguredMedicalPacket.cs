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
    
    public partial class ConfiguredMedicalPacket
    {
        public ConfiguredMedicalPacket()
        {
            this.ConfiguredMedicalPacketToEmployee = new HashSet<ConfiguredMedicalPacketToEmployee>();
        }
    
        public int ConfiguredMedicalPacketID { get; set; }
        public int MedicalPacketID { get; set; }
        public Nullable<int> BeneficiaryGroupID { get; set; }
    
        public virtual BeneficiaryGroupId BeneficiaryGroupId1 { get; set; }
        public virtual MedicalPacketTypes MedicalPacketTypes { get; set; }
        public virtual ICollection<ConfiguredMedicalPacketToEmployee> ConfiguredMedicalPacketToEmployee { get; set; }
    }
}
