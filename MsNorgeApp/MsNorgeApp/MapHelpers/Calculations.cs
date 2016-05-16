using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsNorgeApp.MapHelpers
{
    public class Calculations
    {

        public double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        public double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
    }
}
