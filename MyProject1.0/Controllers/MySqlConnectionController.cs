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
using Newtonsoft.Json;
using System.Net.Http;


namespace MyProject1._0.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MySqlConnectionController : Controller
    {
        [HttpGet("[action]")]
        public List<DBConnectionTesting> NamesList()
        {
            GetData getData = new GetData();
            List<DBConnectionTesting> data = new List<DBConnectionTesting>();

            try
            {
                data = getData.CallDB();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Controller Failed");
                throw e;
            }

            return data;
        }
        
        [HttpPost("[action]")]
        public string SaveNamesList([FromBody] DBConnectionTesting data)
        {
            try
            {
                string Value = null;
                if (data != null)
                {
                    SendData sendData = new SendData();
                    Value = sendData.CallDBToSend(data);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("************Data is null*************");
                }
                return Value;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Controller Failed");
                throw e;
            }
        }
    }
}
