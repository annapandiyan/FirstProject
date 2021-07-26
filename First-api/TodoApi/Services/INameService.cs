using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Services
{
    public interface INameService 
    {
        List<NameItem> GetAll();
        void save();
        void insert(NameItem plan);
        void Deleted(int ID);
        void update(NameItem plan);
        NameItem GetByID(int id);
    }
}
