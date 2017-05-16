using System.Collections.Generic;
using BillOfMaterial.InfoObjects;

namespace BillOfMaterial.Fixtures
{
    public class DataFixture
    {
        public BaseMachineComponent GetMachineComponentWithoutChildComponents()
        {
            return new MachineComponent
            {
                Name = "Component 1",
                Id = 1
            };
        }

        public IEnumerable<BillOfMaterialPositionInfo> GetBillOfMaterialPositions()
        {
            var billOfMaterialPositions = new List<BillOfMaterialPositionInfo>()
            {
                new BillOfMaterialPositionInfo {Id = 1, Name = "Component 1"},
                new BillOfMaterialPositionInfo
                {
                    Id = 2,
                    Name = "Article 1",
                    ParentId = 1,
                    AdditionalInformations = "article/2",
                    IsArticle = true
                },
                new BillOfMaterialPositionInfo
                {
                    Id = 3,
                    Name = "Module 1",
                    ParentId = 1,
                    AdditionalInformations = "123-456"
                },
                new BillOfMaterialPositionInfo {Id = 4, Name = "Component 2", ParentId = 1},
                new BillOfMaterialPositionInfo
                {
                    Id = 5,
                    Name = "Article 2",
                    ParentId = 4,
                    AdditionalInformations = "article/5",
                    IsArticle = true
                },
                new BillOfMaterialPositionInfo
                {
                    Id = 6,
                    Name = "Module 2",
                    ParentId = 4,
                    AdditionalInformations = "789-456"
                },
                new BillOfMaterialPositionInfo {Id = 7, Name = "Component 3", ParentId = 4},
                new BillOfMaterialPositionInfo
                {
                    Id = 8,
                    Name = "Article 3",
                    ParentId = 7,
                    AdditionalInformations = "article/8",
                    IsArticle = true
                },
                new BillOfMaterialPositionInfo
                {
                    Id = 9,
                    Name = "Module 3",
                    ParentId = 7,
                    AdditionalInformations = "789-321"
                },
            };

            return billOfMaterialPositions;
        }

        public IEnumerable<BaseMachineComponent> GetMachineComponentTree()
        {
            return new List<BaseMachineComponent>
            {
                new MachineComponent
                {
                    Name = "Component 1",
                    Id = 1,
                    ChildComponents = new List<BaseMachineComponent>
                    {
                        new Article
                        {
                            Id = 2,
                            Name = "Article 1",
                            LinkToDetailPage = "article/2"
                        },
                        new Module
                        {
                            Id = 3,
                            Name = "Module 1",
                            ModuleNumber = "123-456"
                        },
                        new MachineComponent
                        {
                            Id = 4,
                            Name = "Component 2",
                            ChildComponents = new List<BaseMachineComponent>
                            {
                                new Article
                                {
                                    Id = 5,
                                    Name = "Article 2",
                                    LinkToDetailPage = "article/5"
                                },
                                new Module
                                {
                                    Id = 6,
                                    Name = "Module 2",
                                    ModuleNumber = "789-456"
                                },
                                new MachineComponent
                                {
                                    Id = 7,
                                    Name = "Component 3"
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}