using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SampleAPIServer.Models;

namespace SampleAPIServer.Controllers
{
    public class BookmarksController : ApiController
    {
        public SampleAPIDBContext DB { get; set; }

        public BookmarksController()
        {
            this.DB = new SampleAPIDBContext();
        }

        // GET api/bookmarks
        public IEnumerable<Bookmark> Get()
        {
            return this.DB.Bookmarks;
        }

        // GET api/bookmarks/5
        public Bookmark Get(int id)
        {
            return this.DB.Bookmarks.Find(id);
        }

        // POST api/bookmarks
        public void Post([FromBody]Bookmark value)
        {
            this.DB.Bookmarks.Add(value);
            this.DB.SaveChanges();
        }

        // PUT api/bookmarks/5
        public void Put(int id, [FromBody]Bookmark value)
        {
            var bookmark = Get(id);
            bookmark.Title = value.Title;
            bookmark.URL = value.URL;
            bookmark.Rating = value.Rating;
            this.DB.SaveChanges();
        }

        // DELETE api/bookmarks/5
        public void Delete(int id)
        {
            var bookmark = Get(id);
            this.DB.Bookmarks.Remove(bookmark);
            this.DB.SaveChanges();
        }
    }
}
