using Microsoft.EntityFrameworkCore;
using StationayShop.DbContexts;
using StationayShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StationayShop.Repository
{
    public class StationaryRepo : IStationaryRepo
    {
        private readonly StationaryDbContext _stationaryDbContext;
        public StationaryRepo(StationaryDbContext stationaryDbContext)
        {
            _stationaryDbContext = stationaryDbContext;
        }
        public void DeleteStationary(int stationaryId)
        {
            var product = _stationaryDbContext.Stationaries.Find(stationaryId);
            _stationaryDbContext.Stationaries.Remove(product);
            Save();
        }

        public IEnumerable<Stationary> GetStationaries()
        {
            return _stationaryDbContext.Stationaries.Include(s => s.StationaryCategory).ToList();
        }

        public Stationary GetStationaryById(int id)
        {
            var prod = _stationaryDbContext.Stationaries.Find(id);
            _stationaryDbContext.Entry(prod).Reference(s => s.StationaryCategory).Load();
            return prod;
        }

        public void InsertStationary(Stationary stationary)
        {
            _stationaryDbContext.Add(stationary);
            Save();
        }

        public void UpdateStationary(Stationary stationary)
        {
            _stationaryDbContext.Entry(stationary).State =
           Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
        public void Save()
        {
            _stationaryDbContext.SaveChanges();
        }
    }
}
