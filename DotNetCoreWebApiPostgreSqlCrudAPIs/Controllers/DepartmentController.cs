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
    public class DepartmentController : ControllerBase
    {
        string sqlQuery;
        string sqlDataSource;
        private readonly IConfiguration _configuration;




        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;

        }



        [HttpGet]
        public JsonResult Get()
        {
            sqlQuery = @"SELECT departmentid, departmentname 	FROM public.department";
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
            sqlQuery = @"SELECT departmentid, departmentname 	FROM public.department where departmentid="+ Id;
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
        public JsonResult Post(Department department)
        {
            sqlQuery = @"insert into  public.department (departmentname)";
            sqlQuery = sqlQuery + "values ('"+ department.DepartmentName +"')   ";
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

            return new JsonResult("Added new department");

        }







        [HttpPut]
        public JsonResult Put(Department department)
        {
            sqlQuery = @"update  public.department set departmentname";
            sqlQuery = sqlQuery + "  = '" + department.DepartmentName + "'   ";
            sqlQuery = sqlQuery + " where departmentid="+ department.DepartmentID ;
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

            return new JsonResult("The department"+ department.DepartmentName + " updated");

        }








        [HttpDelete("{Id}")]
        public JsonResult Delete(int Id)
        {
            sqlQuery = @" delete from   public.department ";
            sqlQuery = sqlQuery + " where departmentid=" + Id;
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

            return new JsonResult("The department " + Id+ "  deleted");

        }


    }


}
