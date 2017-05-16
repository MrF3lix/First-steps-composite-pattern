namespace BillOfMaterial
{
    public abstract class BaseMachineComponent
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public virtual MachineComponent GetComposite()
        {
            return null;
        }

        public virtual string Display()
        {
            return $"{Name} - {Id}";
        }
    }
}