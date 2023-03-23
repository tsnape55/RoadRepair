using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadRepair.Repairs
{
    public abstract class BaseRepairType
    {
        public BaseRepairType(Road road)
        {
            Width = road.Width;
            Length = road.Length;
            Potholes = road.Potholes;
        }

        public double Width { get; }
        public double Length { get; }
        public int Potholes { get; }
        public abstract double GetCost();
    }
}
