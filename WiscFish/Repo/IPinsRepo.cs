using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiscFish.Models;

namespace WiscFish.Repo
{
    public interface IPinsRepo
    {
        Task<List<Pins>> GetPins();
        Task<List<Pins>> GetPins(string year);
        Task<int> PostPins(Pins pins);
    }
}
