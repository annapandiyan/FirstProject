using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Services
{
    public class NameService : INameService
    {
        private readonly NameContext _context;
        public NameService(NameContext context)
        {
            _context = context;
        }

        public void Deleted(int ID)
        {
            NameItem ti = GetByID(ID);
            _context.Remove(ti);
            //throw new NotImplementedException();
        }

        public List<NameItem> GetAll()
        {
            return _context.Plans.ToList();
            //throw new NotImplementedException();
        }

        public NameItem GetByID(int id)
        {
            return _context.Plans.Where(a => a.Id == id).SingleOrDefault();
            //throw new NotImplementedException();
        }

        public void insert(NameItem plan)
        {
            _context.Add(plan);
            //throw new NotImplementedException();
        }

        public void save()
        {
            _context.SaveChanges();
            //throw new NotImplementedException();
        }

        public void update(NameItem plan)
        {
            _context.Plans.Update(plan);
            //throw new NotImplementedException();
        }
    }
}
