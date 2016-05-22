using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.IO;
using System.Web.Caching;
using Listers_Candidate_Assessment_BusinessLayer;
using Listers_Candidate_Assessment_Data;


namespace Listers_Candidate_Assessment
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                ViewState["sortOrder"] = "ASC";
                Session["numCarsToDisplay"] = 3;

                DataBindGridView();
                DataBindManufacturerMenu();
            }
            else
            {
                if (Convert.ToByte(Session["numCarsToDisplay"]) == 9)
                    btnLoadMoreCars.Enabled = false;
            }
        }

        /// <summary>
        /// Loads 3 more cars 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLoadMoreCars_Click(object sender, EventArgs e)
        {
            if (Convert.ToByte(Session["numCarsToDisplay"]) <= 9)
            {
                Session["numCarsToDisplay"] = Convert.ToByte(Session["numCarsToDisplay"]) + 3;
                DataBindGridView();

                if (Convert.ToByte(Session["numCarsToDisplay"]) == 9)
                    btnLoadMoreCars.Enabled = false;
            }
            else
                btnLoadMoreCars.Enabled = false;

            dlManufacturers.SelectedValue = "";
        }

        /// <summary>
        /// Binds GridView with current number of unfiltered cars to display
        /// </summary>
        public void DataBindGridView()
        {
            List<Vehicle> carsOnDisplay = Listers_Candidate_Assessment_Data.Cars.GetCars();

            gvCars.DataSource = carsOnDisplay.Take(Convert.ToByte(Session["numCarsToDisplay"]));
            gvCars.DataBind();
        }

        /// <summary>
        /// Gets distinct Manufacturers and bind them to menu
        /// </summary>
        public void DataBindManufacturerMenu()
        {
            List<Vehicle> cars = Listers_Candidate_Assessment_Data.Cars.GetCars();            
            List<string> manufacturers = cars.Select(x => x.Manufacturer).Distinct().ToList();

            dlManufacturers.DataSource = manufacturers;
            dlManufacturers.DataBind();

            dlManufacturers.Items.Insert(0, (new ListItem("All", "")));

        }


        /// <summary>
        /// Make sure that the sort is applied to the cars just on display (otherwise new cars may appear in on-screen display which weren't there previously)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvCars_Sorting(object sender, GridViewSortEventArgs e)
        {
            List<Vehicle> cars = Listers_Candidate_Assessment_Data.Cars.GetCars();
            List<Vehicle> carsOnDisplay = cars.Take(Convert.ToByte(Session["numCarsToDisplay"])).ToList();

            switch (e.SortExpression)
            {
                case "Manufacturer":
                    if (ViewState["sortOrder"].ToString() == "ASC")
                        carsOnDisplay = carsOnDisplay.OrderByDescending(x => x.Manufacturer).ToList();
                    else
                        carsOnDisplay = carsOnDisplay.OrderBy(x => x.Manufacturer).ToList();
                    break;


                case "Range":
                    if (ViewState["sortOrder"].ToString() == "ASC")
                        carsOnDisplay = carsOnDisplay.OrderByDescending(x => x.Range).ToList();
                    else
                        carsOnDisplay = carsOnDisplay.OrderBy(x => x.Range).ToList();
                    break;
                    
              
                case "Derivative":
                    if (ViewState["sortOrder"].ToString() == "ASC")
                        carsOnDisplay = carsOnDisplay.OrderByDescending(x => x.Derivative).ToList();
                    else
                        carsOnDisplay = carsOnDisplay.OrderBy(x => x.Derivative).ToList();
                    break;

                
                case "Colour":
                    if (ViewState["sortOrder"].ToString() == "ASC")
                        carsOnDisplay = carsOnDisplay.OrderByDescending(x => x.Colour).ToList();
                    else
                        carsOnDisplay = carsOnDisplay.OrderBy(x => x.Colour).ToList();
                    break;

                
                case "Mileage":
                    if (ViewState["sortOrder"].ToString() == "ASC")
                        carsOnDisplay = carsOnDisplay.OrderByDescending(x => x.Mileage).ToList();
                    else
                        carsOnDisplay = carsOnDisplay.OrderBy(x => x.Mileage).ToList();
                    break;

                case "Transmission":
                    if (ViewState["sortOrder"].ToString() == "ASC")
                        carsOnDisplay = carsOnDisplay.OrderByDescending(x => x.Transmission).ToList();
                    else
                        carsOnDisplay = carsOnDisplay.OrderBy(x => x.Transmission).ToList();

                    break;

                    
                case "Fuel":
                    if (ViewState["sortOrder"].ToString() == "ASC")
                        carsOnDisplay = carsOnDisplay.OrderByDescending(x => x.Fuel).ToList();
                    else
                        carsOnDisplay = carsOnDisplay.OrderBy(x => x.Fuel).ToList();
                    break;


                case "Registered":
                    if (ViewState["sortOrder"].ToString() == "ASC")
                        carsOnDisplay = carsOnDisplay.OrderByDescending(x => x.Registered).ToList();
                    else
                        carsOnDisplay = carsOnDisplay.OrderBy(x => x.Registered).ToList();

                    break;


                case "Price":
                    if (ViewState["sortOrder"].ToString() == "ASC")
                        carsOnDisplay = carsOnDisplay.OrderByDescending(x => x.Price).ToList();
                    else
                        carsOnDisplay = carsOnDisplay.OrderBy(x => x.Price).ToList();

                    break;
            }
            
            //Sort flip logic
            ViewState["sortOrder"] = (ViewState["sortOrder"].ToString() == "ASC") ? "DESC" : "ASC";

            gvCars.DataSource = carsOnDisplay;
            gvCars.DataBind();
        }

        /// <summary>
        /// On change event for Manufacturers menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dlManufacturers_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Vehicle> cars = Listers_Candidate_Assessment_Data.Cars.GetCars();
            List<Vehicle> carsOnDisplay;

            //Show all cars for selected Manufacturer, if 'all' then overside number of cars to show back to 3
            if (!String.IsNullOrEmpty(dlManufacturers.SelectedValue))
                carsOnDisplay = cars.Where(x => x.Manufacturer == dlManufacturers.SelectedValue).ToList();
            else
            {
                Session["numCarsToDisplay"] = 3;
                carsOnDisplay = cars.Take(3).ToList();
                btnLoadMoreCars.Enabled = true;
            }

            gvCars.DataSource = carsOnDisplay;
            gvCars.DataBind();

        }

    }
}
