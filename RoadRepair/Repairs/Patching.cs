namespace RoadRepair.Repairs
{
    /// <summary>
    /// Patching is where you repair parts of the road, but not the whole road.
    /// </summary>
    public class Patching : BaseRepairType
    {
        public Patching(Road road) : base(road)
        {
            UnitCost = 1;
        }

        public double UnitCost { get; }

        public override double GetCost()
        {
            var cost = Potholes * Width * Length * UnitCost;
            return cost;
        }
        public override string ToString() => "Patching";
    }
}