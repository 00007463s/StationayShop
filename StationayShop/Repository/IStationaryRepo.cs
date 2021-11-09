using StationayShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StationayShop.Repository
{
    public interface IStationaryRepo
    {
        void InsertStationary(Stationary stationary);
        void UpdateStationary(Stationary stationary);
        void DeleteStationary(int stationaryId);
        Stationary GetStationaryById(int id);
        IEnumerable<Stationary> GetStationaries();
    }
}
