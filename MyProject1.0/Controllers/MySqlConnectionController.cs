using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DBConnection;
using DAO;
using System.Data;
using System.Data.SqlClient;
using Entities;


namespace MyProject1._0.Controllers
{
    [Route("api/[controller]")]
    public class MySqlConnectionController : Controller
    {
        [HttpGet("[action]")]
        public List<DBConnectionTesting> NamesList()
        {
            GetData getData = new GetData();
            List<DBConnectionTesting> data = new List<DBConnectionTesting>();
            int count = 0;
            try
            {
                data = getData.CallDB();
                if (data != null)
                {
                    foreach (DBConnectionTesting person in data)
                    {
                        System.Diagnostics.Debug.WriteLine(count++);
                        System.Diagnostics.Debug.WriteLine(person.FirstName + "," + person.LastName);
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Data is null");
                    return null;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Controller Failed");
                Console.WriteLine(e);
            }

            return data;
        }
    }
}
