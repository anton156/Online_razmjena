using Online_razmjena.Data;
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
        public List<Post> GetAllPosts()
        {
            return _contex.Posts.ToList();

        }

        public Post GetPost(int id)
        {
            return _contex.Posts.FirstOrDefault(p => p.Id == id);

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
    }
}
