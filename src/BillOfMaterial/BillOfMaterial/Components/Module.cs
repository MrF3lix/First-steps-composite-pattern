namespace BillOfMaterial
{
    public class Module : BaseMachineComponent
    {
        public string ModuleNumber { get; set; }

        public override string Display()
        {
            return $"{Name} - {Id} - {ModuleNumber}";
        }
    }
}