using LocationTracker.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LocationTracker.API.Controllers
{
    [Controller]
    [Route("Clinics")]
    public class ClinicController : Controller
    {
        private readonly IConfiguration _configuration;
        public ClinicController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Index()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("ClinicViewAll", connection);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.Fill(dataTable);
                connection.Close();
            }

            return Ok(dataTable);
        }

        [HttpPost]
        public  IActionResult AddClinic(int id, [Bind("ClinicId,City,ClinicName")] Clinic clinic)
        {
            using(SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("ClinicAdd", connection);
                command.Parameters.AddWithValue("ClinicId", clinic.ClinicId);
                command.Parameters.AddWithValue("ClinicName", clinic.ClinicName);
                command.Parameters.AddWithValue("City", clinic.City);
                command.ExecuteNonQuery();
                connection.Close();
            }
            return Index();
        }


        [NonAction]
        private Clinic FetchClinic(string clinicName)
        {
            var clinic = new Clinic();

            using(SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                var dataTable = new DataTable();
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("ClinicViewAll", connection);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("ClinicName", clinicName);
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count == 1)
                {
                    clinic.ClinicId = Convert.ToInt32(dataTable.Rows[0]["ClinicId"].ToString());
                    clinic.ClinicName = dataTable.Rows[0]["ClinicName"].ToString();
                    clinic.City = dataTable.Rows[0]["City"].ToString();
                }
                connection.Close();
                return clinic;
            }
        }

    }
}
