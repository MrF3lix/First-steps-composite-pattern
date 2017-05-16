using System;
using System.Collections.Generic;
using System.Linq;
using MachinePartsList.Components;
using MachinePartsList.Fixtures;
using MachinePartsList.Helper;

namespace MachinePartsList
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var dataFixture = new DataFixture();
            var positionListFromDb = dataFixture.GetMachineParts();
            var componentTree = positionListFromDb.BuildTree();

            DisplayTreeBfs(componentTree.First());

            Console.ReadKey();
        }

        private static void DisplayTreeBfs(BaseMachineComponent rootComponent)
        {
            var currentLevel = 0;
            var depthIncrease = 1;
            var nextDepthIncrease = 0;

            var queue = new Queue<BaseMachineComponent>();
            queue.Enqueue(rootComponent);

            while (queue.Any())
            {
                var node = queue.Dequeue();
                
                PrintLine(node.Display(), currentLevel);

                var composite = node.GetComposite();
                if (composite == null)
                {
                    depthIncrease--;
                    continue;
                }

                nextDepthIncrease += composite.ChildComponents.Count - 1;
                if (--depthIncrease <= 0)
                {
                    currentLevel++;
                    depthIncrease = nextDepthIncrease;
                    nextDepthIncrease = 0;
                }

                foreach (var child in composite.ChildComponents)
                {
                    queue.Enqueue(child);
                }
            }
        }

        private static void PrintLine(string value, int level)
        {
            var output = "";
            for (var i = 0; i < level; i++)
            {
                output += "-";
            }

            Console.WriteLine(output + value);
        }
    }
}