using System.Collections.Generic;
using System.Linq;
using BillOfMaterial.InfoObjects;

namespace BillOfMaterial.Helper
{
    public static class TreeEnumerableExtension
    {
        public static IEnumerable<BaseMachineComponent> BuildTree(this IEnumerable<BillOfMaterialPositionInfo> positions)
        {
            var componentTree = new List<BaseMachineComponent>();
            var groups = positions.GroupBy(p => p.ParentId);
            var rootElements = groups.FirstOrDefault(p => p.Key.HasValue == false);
            var allChildElements = groups.Where(p => p.Key.HasValue).ToDictionary(p => p.Key.Value, p => p.OrderBy(m => m.Id).ToList());
            
            if (rootElements != null)
            {
                foreach (var root in rootElements)
                {
                    var component = GetComponentFromPosition(root, allChildElements);
                    AddChildElements(component, allChildElements);
                    componentTree.Add(component);
                }
            }

            return componentTree;
        }

        private static void AddChildElements(BaseMachineComponent currentNode,
            IDictionary<int, List<BillOfMaterialPositionInfo>> childElements)
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
                    currentComposite.AddChild(GetComponentFromPosition(child, childElements));
                    AddChildElements(GetComponentFromPosition(child, childElements), childElements);
                }
            }
        }

        private static BaseMachineComponent GetComponentFromPosition(BillOfMaterialPositionInfo position,
            IDictionary<int, List<BillOfMaterialPositionInfo>> childElements)
        {
            BaseMachineComponent component;
            if (childElements.ContainsKey(position.Id))
            {
                component = new MachineComponent() {Id = position.Id, Name = position.Name};
                return component;
            }

            if (position.IsArticle)
            {
                component = new Article() { Id = position.Id, Name = position.Name, LinkToDetailPage = position.AdditionalInformations };
                return component;
            }

            component = new Module() { Id = position.Id, Name = position.Name, ModuleNumber = position.AdditionalInformations };
            return component;
        }
    }
}
