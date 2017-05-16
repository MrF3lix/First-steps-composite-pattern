namespace MachinePartsList.Components
{
    public abstract class BaseMachineComponent
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public virtual Module GetComposite()
        {
            return null;
        }

        public virtual string Display()
        {
            return $"{Name} - {Id}";
        }

        public virtual void AddChild(BaseMachineComponent component){}

        public virtual void RemoveChild(BaseMachineComponent component){}
    }
}