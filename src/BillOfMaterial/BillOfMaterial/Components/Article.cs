namespace BillOfMaterial
{
    public class Article : BaseMachineComponent
    {
        public string LinkToDetailPage { get; set; }

        public override string Display()
        {
            return $"{Name} - {Id} - {LinkToDetailPage}";
        }
    }
}
