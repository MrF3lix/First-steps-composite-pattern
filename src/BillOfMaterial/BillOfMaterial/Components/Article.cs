namespace MachinePartsList.Components
{
    public class Article : BaseMachineComponent
    {
        public string LinkToDetailPage { private get; set; }

        public override string Display()
        {
            return $"{Name} - {Id} - {LinkToDetailPage}";
        }
    }
}
