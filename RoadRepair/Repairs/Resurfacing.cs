namespace RoadRepair.Repairs
{
    public class Resurfacing : BaseRepairType
    {
        public Resurfacing(Road road) : base(road)
        {
            UnitCost = 20;
        }

        public double UnitCost { get; }

        public override double GetCost()
        {
            var cost = Width * Length * UnitCost;
            return cost;
        }
        public override string ToString() => "Resurfacing";
    }
}
