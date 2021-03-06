﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leave_Management.Contracts;
using Leave_Management.Data;

namespace Leave_Management.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        private readonly ApplicationDbContext _db;
        public LeaveHistoryRepository(ApplicationDbContext db) 
        {
            _db = db;
        }
        public bool Create(LeaveHistory entity)
        {
            _db.Add(entity);
            return Save();
        }

        public bool Delete(LeaveHistory entity)
        {
            _db.Remove(entity);
            return Save();
        }

        public ICollection<LeaveHistory> FindAll()
        {
            return _db.LeaveHistories.ToList();
        }

        public LeaveHistory FindById(int Id)
        {
            return _db.LeaveHistories.Find(Id);
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool Update(LeaveHistory entity)
        {
            _db.Update(entity);
            return Save();
        }
    }
}
