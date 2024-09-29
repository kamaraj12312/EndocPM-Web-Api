using System;

namespace EndocPM.WebAPI
{
    public class Lonic
    {
        public int LonicID { get; set; }
        public string Code { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public string Component { get; set; }
        public string Status { get; set; }
        public string System { get; set; }
        public string UnitsAndRange { get; set; }
        public string HL7FieldSubFieldID { get; set; }
        public string HL7AttachmentStructure { get; set; }
        public DateTime DateLastChanged { get; set; }
        public string DefinitionDescription { get; set; }
        public string RelatedName2 { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
   
    }
}
