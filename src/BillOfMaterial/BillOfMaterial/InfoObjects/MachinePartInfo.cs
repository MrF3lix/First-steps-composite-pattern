namespace MachinePartsList.InfoObjects
{
    public class MachinePartInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AdditionalInformations { get; set; }

        public int? ParentId { get; set; }
    }
}