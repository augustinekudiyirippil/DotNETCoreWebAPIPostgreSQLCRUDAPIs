using DotNetCoreWebApiPostgreSqlCrudAPIs.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace DotNetCoreWebApiPostgreSqlCrudAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        string sqlQuery;
        string sqlDataSource;
        private readonly IConfiguration _configuration;


        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;

        }




        [HttpGet]
        public JsonResult Get()
        {
            sqlQuery = @"SELECT employeeid, employeename, department, dateofjoining, photofilename 	FROM public.employee";
            DataTable dataTable = new DataTable();

            sqlDataSource = _configuration.GetConnectionString("postgresqlconnection");

            NpgsqlDataReader dataReader;

            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlDataSource))
            {

                npgsqlConnection.Open();
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(sqlQuery, npgsqlConnection))
                {
                    dataReader = npgsqlCommand.ExecuteReader();
                    dataTable.Load(dataReader);

                    dataReader.Close();
                    npgsqlConnection.Close();

                }

            }

            return new JsonResult(dataTable);



        }









        [HttpGet("{Id}")]
        public JsonResult Get(int Id)
        {
            sqlQuery = @"SELECT employeeid, employeename, department, dateofjoining, photofilename 	FROM public.employee where employeeid=" + Id;
            DataTable dataTable = new DataTable();

            sqlDataSource = _configuration.GetConnectionString("postgresqlconnection");

            NpgsqlDataReader dataReader;

            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlDataSource))
            {

                npgsqlConnection.Open();
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(sqlQuery, npgsqlConnection))
                {
                    dataReader = npgsqlCommand.ExecuteReader();
                    dataTable.Load(dataReader);

                    dataReader.Close();
                    npgsqlConnection.Close();

                }

            }

            return new JsonResult(dataTable);



        }






        [HttpPost]
        public JsonResult Post(Employee employee)
        {
            sqlQuery = @"insert into  public.employee  ( employeename, department, dateofjoining, photofilename)";
            sqlQuery = sqlQuery + "values ('" +  employee.EmployeeName + "',   ";
            sqlQuery = sqlQuery + " '" + employee.Department + "',   ";
            sqlQuery = sqlQuery + " '" + employee.DateOfJoining + "',   ";
            sqlQuery = sqlQuery + " '" + employee.PhotoFileName+ "')   ";

            DataTable dataTable = new DataTable();

            sqlDataSource = _configuration.GetConnectionString("postgresqlconnection");


            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlDataSource))
            {

                npgsqlConnection.Open();
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(sqlQuery, npgsqlConnection))
                {

                    npgsqlCommand.ExecuteNonQuery();
                    npgsqlConnection.Close();

                }

            }

            return new JsonResult("Added new Employee");

        }







        [HttpPut]
        public JsonResult Put(Employee employee)
        {
            sqlQuery = @"update  public.employee set ";
            sqlQuery = sqlQuery + "    employeename= '"+ employee.EmployeeName +"' , " ;
            sqlQuery = sqlQuery + "    department = '" + employee.Department + "' , ";
            sqlQuery = sqlQuery + "    dateofjoining = '" + employee.DateOfJoining + "' , ";
            sqlQuery = sqlQuery + "    photofilename = '" + employee.PhotoFileName + "' , ";
            sqlQuery = sqlQuery + " where employeeid=" + employee.EmployeeID;
            DataTable dataTable = new DataTable();

            sqlDataSource = _configuration.GetConnectionString("postgresqlconnection");


            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlDataSource))
            {

                npgsqlConnection.Open();
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(sqlQuery, npgsqlConnection))
                {

                    npgsqlCommand.ExecuteNonQuery();
                    npgsqlConnection.Close();

                }

            }

            return new JsonResult("The employee " + employee.EmployeeName+ " updated");

        }








        [HttpDelete("{Id}")]
        public JsonResult Delete(int Id)
        {
            sqlQuery = @" delete from   public.employee ";
            sqlQuery = sqlQuery + " where employeeid=" + Id;
            DataTable dataTable = new DataTable();

            sqlDataSource = _configuration.GetConnectionString("postgresqlconnection");


            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlDataSource))
            {

                npgsqlConnection.Open();
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(sqlQuery, npgsqlConnection))
                {

                    npgsqlCommand.ExecuteNonQuery();
                    npgsqlConnection.Close();

                }

            }

            return new JsonResult("The employee  " + Id + "  deleted");

        }




    }
}
