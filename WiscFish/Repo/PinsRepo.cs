using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WiscFish.Models;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
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
            var constring = _config.GetConnectionString("DefaultConnectionString");
            List<Pins> pins = new List<Pins>();
            using (var con = new SqlConnection(constring))
            {
                const string query = "SELECT * FROM PINS";
                con.Open();
                var data = await con.QueryAsync<Pins>(query);
                pins = data.ToList();
            }
            return pins;
        }

        public async Task<List<Pins>> GetPins(string year)
        {
            var constring = _config.GetConnectionString("DefaultConnectionString");
            List<Pins> pins = new List<Pins>();
            if(year == "All")
            {
                try
                {
                    using (var con = new SqlConnection(constring))
                    {
                        const string query = "SELECT * FROM PINS";
                        con.Open();
                        var data = await con.QueryAsync<Pins>(query);
                        pins = data.ToList();
                    }
                }
                catch (Exception ex)
                {
                    var t = ex;
                }
            }
            else
            {
                try
                {
                    using (var con = new SqlConnection(constring))
                    {
                        const string query = "SELECT * FROM PINS WHERE DATE LIKE @year";
                        con.Open();
                        var data = await con.QueryAsync<Pins>(query, new { @year = "%" + year + "%" });
                        pins = data.ToList();
                    }
                }
                catch (Exception ex)
                {
                    var t = ex;
                }
            }

            return pins;
        }

        public async Task<int> PostPins(Pins pins)
        {
            var constring = _config.GetConnectionString("DefaultConnectionString");
            int id;
            try
            {
                using (var con = new SqlConnection(constring))
                {
                    //const string query = "SELECT * FROM PINS";
                    con.Open();
                    id = await con.InsertAsync(new Pins { Name = pins.Name, FishType = pins.FishType, Latitude = pins.Latitude, Longitude = pins.Longitude, Date = pins.Date });
                }
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return id;
        }
    }
}
