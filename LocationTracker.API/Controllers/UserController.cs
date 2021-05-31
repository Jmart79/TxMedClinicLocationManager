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
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
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
                SqlDataAdapter adapter = new SqlDataAdapter("PersonViewAll", connection);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.Fill(dataTable);
                connection.Close();
            }

            return Ok(dataTable);
        }

        public IActionResult UpdateDoctorLocation(int id, [Bind("PersonId,Role,Location")] Person person)
        {
            using(SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("PersonAdd", connection);
                command.Parameters.AddWithValue("PersonId", person.PersonId);
                command.Parameters.AddWithValue("Role", person.Role);
                command.Parameters.AddWithValue("Location", person.Location);
                command.ExecuteNonQuery();
                connection.Close();
            }
            return Index();
        }
    }
}
