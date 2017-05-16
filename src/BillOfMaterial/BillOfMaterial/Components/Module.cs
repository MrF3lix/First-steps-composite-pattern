using System.Collections.Generic;

namespace MachinePartsList.Components
{
    public class Module : BaseMachineComponent
    {
        public Module()
        {
            ChildComponents = new List<BaseMachineComponent>();
        }

        public ICollection<BaseMachineComponent> ChildComponents { get; }

        public override Module GetComposite()
        {
            return this;
        }

        public override void AddChild(BaseMachineComponent component)
        {
            ChildComponents.Add(component);
        }

        public override void RemoveChild(BaseMachineComponent component)
        {
            ChildComponents.Remove(component);
        }
    }
}