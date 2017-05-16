using System.Collections.Generic;

namespace BillOfMaterial
{
    public class MachineComponent : BaseMachineComponent
    {
        public MachineComponent()
        {
            ChildComponents = new List<BaseMachineComponent>();
        }

        public ICollection<BaseMachineComponent> ChildComponents { get; set; }

        public override MachineComponent GetComposite()
        {
            return this;
        }

        public void AddChild(BaseMachineComponent component)
        {
            ChildComponents.Add(component);
        }

        public void RemoveChild(BaseMachineComponent component)
        {
            ChildComponents.Remove(component);
        }
    }
}