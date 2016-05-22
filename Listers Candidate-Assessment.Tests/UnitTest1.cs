using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Listers_Candidate_Assessment_Data;
using Listers_Candidate_Assessment_BusinessLayer;
using System.Web;

namespace Listers_Candidate_Assessment.Tests
{
    [TestClass]
    public class UnitTest1
    {

        /// <summary>
        /// Was attempting to run unit test on my JSON data here but this will fail since there's no HTTPContext within the test. But I hope you see what I'm attempting to do here
        /// Written another way I would have more tests and perhaps less methods returning void results
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            string file = HttpContext.Current.Server.MapPath("Vehicles.json");

            VehicleObject obj = Listers_Candidate_Assessment_Data.Cars.LoadJSON(file);
            Assert.IsNotNull(obj);
        }
    }
}
