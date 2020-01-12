using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WiscFish.Models;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace WiscFish.Repo
{
    public class PinsRepo : IPinsRepo
    {
        private readonly IConfiguration _config;

        public PinsRepo(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<Pins>> GetPins()
        {
            string connString = _config.GetConnectionString("DefaultConnectionString");
            List<Pins> pins = new List<Pins>();
            try
            {
                using (var con = new SqlConnection(connString))
                {
                    const string query = "SELECT * FROM PINS";
                    con.Open();
                    var data = await con.QueryAsync<Pins>(query);
                    pins = data.ToList();
                }
            }
            catch (SqlException ex)
            {

            }

            return pins;
        }

        public async Task<List<Pins>> GetPins(int year)
        {
            string connString = _config.GetConnectionString("DefaultConnectionString");
            List<Pins> pins = new List<Pins>();
            try
            {
                using (var con = new SqlConnection(connString))
                {
                    const string query = "SELECT * FROM PINS WHERE DATE LIKE @year";
                    con.Open();
                    var data = await con.QueryAsync<Pins>(query, new { @year = "%" + year.ToString() + "%" });
                    pins = data.ToList();
                }                
            }
            catch(SqlException ex)
            {
                var t = ex;
            }

            return pins;
        }
    }
}
