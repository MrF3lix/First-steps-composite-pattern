using System;
using System.Collections.Generic;
using BillOfMaterial.Fixtures;
using BillOfMaterial.Helper;

namespace BillOfMaterial
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dataFixture = new DataFixture();
            var positionListFromDb = dataFixture.GetBillOfMaterialPositions();
            var componentTree = positionListFromDb.BuildTree();

            DisplayTree(componentTree);

            Console.ReadKey();
        }

        private static void DisplayTree(IEnumerable<BaseMachineComponent> components)
        {
            foreach (var component in components)
            {
                DisplayPosition(component);
            }
        }

        private static void DisplayPosition(BaseMachineComponent position)
        {
            MachineComponent component = position.GetComposite();
            if (component != null)
            {
                Console.WriteLine("+" + position.Display());
                DisplayTree(component.ChildComponents);
            }
            else
            {
                Console.WriteLine("-" + position.Display());
            }
        }
    }
}
