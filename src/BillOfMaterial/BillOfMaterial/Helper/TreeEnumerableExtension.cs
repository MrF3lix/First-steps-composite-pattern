using System.Collections.Generic;
using System.Linq;
using MachinePartsList.Components;
using MachinePartsList.InfoObjects;

namespace MachinePartsList.Helper
{
    public static class TreeEnumerableExtension
    {
        public static IEnumerable<BaseMachineComponent> BuildTree(this IEnumerable<MachinePartInfo> part)
        {
            var componentTree = new List<BaseMachineComponent>();
            var groups = part.GroupBy(p => p.ParentId);
            var rootElements = groups.FirstOrDefault(p => p.Key.HasValue == false);
            var allChildElements = groups.Where(p => p.Key.HasValue)
                .ToDictionary(p => p.Key.Value, p => p.ToList());

            if (rootElements != null)
            {
                foreach (var root in rootElements)
                {
                    var component = GetComponentFromPart(root, allChildElements.Keys);
                    AddChildElements(component, allChildElements);
                    componentTree.Add(component);
                }
            }

            return componentTree;
        }

        private static void AddChildElements(BaseMachineComponent currentNode,
            IDictionary<int, List<MachinePartInfo>> childElements)
        {
            if (!childElements.ContainsKey(currentNode.Id))
            {
                return;
            }

            var currentComposite = currentNode.GetComposite();
            if (currentComposite != null)
            {
                foreach (var child in childElements[currentNode.Id])
                {
                    var childComponent = GetComponentFromPart(child, childElements.Keys);

                    currentNode.AddChild(childComponent);
                    AddChildElements(childComponent, childElements);
                }
            }
        }

        private static BaseMachineComponent GetComponentFromPart(MachinePartInfo position,
            IEnumerable<int> parentElementIds)
        {
            BaseMachineComponent component;

            if (parentElementIds.Contains(position.Id))
            {
                component = new Module {Id = position.Id, Name = position.Name};
                return component;
            }

            component = new Article
            {
                Id = position.Id,
                Name = position.Name,
                LinkToDetailPage = position.AdditionalInformations
            };
            return component;
        }
    }
}