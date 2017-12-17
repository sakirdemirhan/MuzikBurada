using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitiy.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BLL
{
    public class BaseRepo<T> where T : class
    {
        
        public BaseRepo()
        {
            if (MyContext.db == null) MyContext.db = new MyContext();
        }

        public List<T> GetAll()
        {
            
            List<T> liste = MyContext.db.Set<T>().ToList();
            return liste;
        }

        public IEnumerable<Kullanici> GetAllUser()
        {
            var liste = MyContext.db.Users.ToList();
            return liste;
        }
        public void DeleteUser(string id)
        {
            var user = MyContext.db.Users.Find(id);
            MyContext.db.Users.Remove(user);
            MyContext.db.SaveChanges();
            
        }
        //public List<T> Search(string value)
        //{
        //    if (MyContext.db == null) MyContext.db = new MyContext();
        //    List<T> liste = db.Set<T>().ToList();
        //    return liste;
        //}

        public void DetachList(List<T> liste)
        {
            liste.ForEach(group => MyContext.db.Entry(group).State = System.Data.Entity.EntityState.Detached);
        }

        public T GetById(int id)
        {
            return MyContext.db.Set<T>().Find(id);
        }
        public void Insert(T obj)
        {
            MyContext.db.Set<T>().Add(obj);
            MyContext.db.SaveChanges();
        }
        public void Delete(int id)
        {
            //var obj = MyContext.db.Set<T>().Find(id);
            //MyContext.db.Set<T>().Remove(obj);
            //MyContext.db.SaveChanges();
        }
        public void Update(T obj)
        {
            MyContext.db.Set<T>().AddOrUpdate(obj);
            //MyContext.db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            MyContext.db.SaveChanges();
        }
    }
}
