using System.Collections.Generic;
using MachinePartsList.Components;
using MachinePartsList.InfoObjects;

namespace MachinePartsList.Fixtures
{
    public class DataFixture
    {
        public BaseMachineComponent GetMachineComponentWithoutChildComponents()
        {
            return new Module
            {
                Name = "Component 1",
                Id = 1
            };
        }

        public IEnumerable<MachinePartInfo> GetMachineParts()
        {
            var machineParts = new List<MachinePartInfo>
            {
                new MachinePartInfo {Id = 1, Name = "Module 1"},
                new MachinePartInfo {Id = 2, Name = "Module 2", ParentId = 1},
                new MachinePartInfo {Id = 3, Name = "Module 3", ParentId = 2},
                new MachinePartInfo {Id = 4, Name = "Module 4", ParentId = 3},
                new MachinePartInfo {Id = 5, Name = "Module 5", ParentId = 4},
                new MachinePartInfo
                {
                    Id = 7,
                    Name = "Article 1",
                    ParentId = 1,
                    AdditionalInformations = "article/8"
                },
                new MachinePartInfo
                {
                    Id = 8,
                    Name = "Article 2",
                    ParentId = 2,
                    AdditionalInformations = "article/2"
                },
                new MachinePartInfo
                {
                    Id = 9,
                    Name = "Article 3",
                    ParentId = 3,
                    AdditionalInformations = "article/5"
                },
                new MachinePartInfo
                {
                    Id = 10,
                    Name = "Article 4",
                    ParentId = 4,
                    AdditionalInformations = "article/5"
                },
                new MachinePartInfo
                {
                    Id = 11,
                    Name = "Article 5",
                    ParentId = 5,
                    AdditionalInformations = "article/5"
                }
            };

            return machineParts;
        }
    }
}