using System.Linq;
using BillOfMaterial;
using BillOfMaterial.Fixtures;
using BillOfMaterial.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BillOfMaterialTest
{
    [TestClass]
    public class MachineComponentTest
    {
        private static DataFixture _dataFixture;

        [TestInitialize]
        public void InitializeData()
        {
            _dataFixture = new DataFixture();
        }

        [TestMethod]
        public void AddChildMachineComponent_Success()
        {
            BaseMachineComponent machineComponent = _dataFixture.GetMachineComponentWithoutChildComponents();
            Article childMachineComponent = new Article() {Id = 2, Name = "Article 1", LinkToDetailPage = "articles/1"};

            var currentComposite = machineComponent.GetComposite();
            
            if (currentComposite != null)
            {
                currentComposite.AddChild(childMachineComponent);
                Assert.IsNotNull(currentComposite.ChildComponents);
                Assert.AreEqual(2, currentComposite.ChildComponents.First().Id);
                Assert.AreEqual("Article 1", currentComposite.ChildComponents.First().Name);
            }
        }

        [TestMethod]
        public void RemoveChildMachineComponent_Success()
        {
            BaseMachineComponent machineComponent = _dataFixture.GetMachineComponentWithoutChildComponents();
            Article childMachineComponent = new Article() { Id = 2, Name = "Article 1", LinkToDetailPage = "articles/1" };

            var currentComposite = machineComponent.GetComposite();

            if (currentComposite != null)
            {
                machineComponent.AddChild(childMachineComponent);
                Assert.IsNotNull(currentComposite.ChildComponents);
                machineComponent.RemoveChild(childMachineComponent);
                Assert.IsFalse(currentComposite.ChildComponents.Any());
            }

        }

        [TestMethod]
        public void BuildComponentTreeFromPositionsList_Success()
        {
            var positions = _dataFixture.GetBillOfMaterialPositions();

            var componentTree = positions.BuildTree();

            Assert.IsNotNull(componentTree);
            Assert.IsTrue(componentTree.Any());
        }
    }
}