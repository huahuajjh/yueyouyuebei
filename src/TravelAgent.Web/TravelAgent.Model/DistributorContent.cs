namespace TravelAgent.Model
{
    public class DistributorContent
    {
        public string Content4BeADistributor { get; set; }
        public int Id { get; set; }
        public string DistributorUrl { get; set; }

        public override string ToString()
        {
            return string.Format("Content4BeADistributor={0},Id={1},DistributorUrl={2}", Content4BeADistributor,Id, DistributorUrl);
        }
    }
}
