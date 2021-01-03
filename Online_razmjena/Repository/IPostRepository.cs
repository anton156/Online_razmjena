using Online_razmjena.Data;
using Online_razmjena.Models.Comments;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Online_razmjena.Repository
{
    public interface IPostRepository
    {
        void AddPost(Post post);
        List<Post> GetAllPosts();
        Post GetPost(int id);
        void RemovePost(int id);
        Task<bool> SaveChangesAsync();
        void UpdatePost(Post post);
        void AddSubComment(SubComment comment);
    }
}