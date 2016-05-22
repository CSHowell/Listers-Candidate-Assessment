using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.IO;
using System.Web.Caching;
using Listers_Candidate_Assessment_BusinessLayer;

namespace Listers_Candidate_Assessment_Data
{
    public static class Cars
    {
        /// <summary>
        /// Gets cars and creates cache if one doesn't exist for them
        /// </summary>
        /// <returns></returns>
        public static List<Vehicle> GetCars()
        {
            if (HttpContext.Current.Cache["cars"] == null)
            {
                string file = HttpContext.Current.Server.MapPath("Vehicles.json");

                VehicleObject cars = LoadJSON(file);

                HttpContext.Current.Cache.Insert("cars", cars.Vehicles, null, Cache.NoAbsoluteExpiration, TimeSpan.FromHours(1), CacheItemPriority.High, null);
            }

            List<Vehicle> cachedCars = HttpContext.Current.Cache["cars"] as List<Vehicle>;

            return cachedCars;
        }

        /// <summary>
        /// Loads JSON Data
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static VehicleObject LoadJSON(string file)
        {
            string Json = File.ReadAllText(file);
            JavaScriptSerializer ser = new JavaScriptSerializer();

            VehicleObject cars = ser.Deserialize<VehicleObject>(Json);

            return cars;
        }
    }
}
