﻿using System;
using System.Collections.Generic;
using System.Linq;
using RoadRepair.Repairs;

namespace RoadRepair
{
    public class Planner
    {
        /// <summary>
        /// The total number of hours needed to complete the work.
        /// </summary>
        public int HoursOfWork { get; set; }

        /// <summary>
        /// The number of people available to do the work
        /// </summary>
        public int Workers { get; set; }

        /// <summary>
        /// The time to complete the work, using all the workers.
        /// </summary>
        /// <returns>The number of hours to complete the work.</returns>
        public double GetTime()
        {
            var time = (double)HoursOfWork / Workers;
            return time;
        }

        /// <summary>
        /// Return the correct type of repair (either a filling, a patch or a resurface)
        /// depending on the density of potholes.
        /// </summary>
        /// <param name="road">A road needing repair</param>
        /// <returns>Either a Filling, a Patching or a Resurfacing</returns>
        public BaseRepairType SelectRepairType(Road road)
        {
            // Use the road.Width, road.Length and road.Potholes properties to calculate the density of potholes. 

            // If the density of potholes is 40% or more the road should be resurfaced.
            // If the density of potholes is 20% or more, but less than 40%, the road should be patched.
            // Otherwise it should be filled.

            var percent = road.GetPotholePercent();

            if (percent >= 40)
            {
                return new Resurfacing(road);
            }

            if (percent >= 20 && percent < 40)
            {
                return new Patching(road);
            }

            return new Filling(road);
        }

        /// <summary>
        /// Calculate the total cost of all the repairs for a list of roads that need repairs.
        /// </summary>
        /// <param name="roads">A list of roads needing repairs</param>
        /// <returns>The total cost of all the repairs</returns>
        public double GetCostOfRepairs(List<Road> roads)
        {
            var totalCost = roads.Sum(x => SelectRepairType(x).GetCost());
            return totalCost;
        }

        /// <summary>
        /// When there is not enough money available to repair all the roads,
        /// select a subset of the roads so that the cost of repairs is less than or equal to the money available.
        /// </summary>
        /// <param name="roads">A list of roads needing repairs</param>
        /// <param name="availableMoney">The money available for repairs</param>
        /// <returns>A subset of roads that can be repaired with the available money</returns>
        public List<Road> SelectRoadsToRepair(List<Road> roads, double availableMoney)
        {
            var roadsWithCosts = roads.Select(road => new
            {
                Road = road,
                Cost = SelectRepairType(road).GetCost()
            }).OrderByDescending(x => x.Road.Potholes).ToList();

            var selectedRoads = new List<Road>();
            double remainingMoney = availableMoney;

            foreach (var roadWithCost in roadsWithCosts)
            {
                if (roadWithCost.Cost <= remainingMoney)
                {
                    selectedRoads.Add(roadWithCost.Road);
                    remainingMoney -= roadWithCost.Cost;
                }
            }

            return selectedRoads;
        }
    }
}
