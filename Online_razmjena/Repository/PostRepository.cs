using Microsoft.EntityFrameworkCore;
using Online_razmjena.Data;
using Online_razmjena.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_razmjena.Repository
{
    public class PostRepository : IPostRepository
    {
        private ApplicationDbContext _contex;
        public PostRepository(ApplicationDbContext context)
        {
            _contex = context;
        }

        public void AddPost(Post post)
        {
            _contex.Posts.Add(post);

        }
        public List<Post> GetAllPosts(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                return _contex.Posts.Where(x => x.Naziv.Contains(search)).ToList();
            }
            else
            {
                return _contex.Posts.ToList();

            }

        }

        public Post GetPost(int id)
        {
            return _contex.Posts
                .Include(p => p.MainComments)
                    .ThenInclude(mc => mc.SubComments)
                .FirstOrDefault(p => p.Id == id);

        }

        public void RemovePost(int id)
        {
            _contex.Posts.Remove(GetPost(id));

        }

        public void UpdatePost(Post post)
        {
            _contex.Posts.Update(post);
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _contex.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public void AddSubComment(SubComment comment)
        {
            _contex.SubComments.Add(comment);
        }
    }
}
