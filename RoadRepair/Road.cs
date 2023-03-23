namespace RoadRepair
{
    public class Road
    {
        public double Width { get; set; }
        public double Length { get; set; }
        public int Potholes { get; set; }

        /// <summary>
        /// Returns the density of potholes as a percentage.
        /// </summary>
        /// <returns>Percentage as a double</returns>
        public double GetPotholePercent()
        {
            double percent = 0;
            // could add exceptions for invalid roads (< 1 width/length)
            if (Potholes > 0)
            {
                percent = Potholes / (Width * Length) * 100;
                if (percent > 100)
                {
                    percent = 100;
                }
            }

            return percent;
        }
    }
}
