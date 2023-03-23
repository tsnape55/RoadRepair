namespace RoadRepair.Repairs
{
    /// <summary>
    /// Filling is where you fix only the individual potholes.
    /// </summary>
    public class Filling : BaseRepairType
    {
        public Filling(Road road) : base(road)
        {
            CostPerHole = 10;
        }

        public double CostPerHole { get; }

        public override double GetCost()
        {
            var cost = Potholes * CostPerHole;
            return cost;
        }

        public override string ToString() => "Filling";
    }
}
