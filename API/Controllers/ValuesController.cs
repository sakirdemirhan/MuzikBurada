using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;
using API.Models;
using BLL;
using Entitiy.Models;

namespace API.Controllers
{
    
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        public List<Blog> GetAllBlogs()
        {
            BlogRep rep = new BlogRep();
            return rep.GetAll();
        }
        public Blog GetBlogById(int id)
        {
            BlogRep rep = new BlogRep();
            return rep.GetById(id);
        }
        
        public List<GrupModel> GetAllUsers()
        {
            BlogRep rep = new BlogRep();
            return rep.GetAllUser().Where(x=>x.GrupAdi!="Admin").Select(x=> new GrupModel
            {
                GrupAdi = x.GrupAdi,
                GrupUyeleri = x.GrupUyeleri,
                GrupAciklama = x.Aciklama,
                KurulusTarihi = x.KurulusTarihi
            }).ToList();
        }
        public GrupModel GetUserById(string id)
        {
            BlogRep rep = new BlogRep();
            var user = rep.GetAllUser().FirstOrDefault(x => x.Id == id);
            GrupModel model = new GrupModel();
            model.GrupAdi = user.GrupAdi;
            model.GrupUyeleri = user.GrupUyeleri;
            model.GrupAciklama = user.Aciklama;
            model.KurulusTarihi = user.KurulusTarihi;
            return model;
        }


    }
}
