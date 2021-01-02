using Online_razmjena.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Online_razmjena.Repository
{
    public interface ISliciceRepository
    {
        Task<int> Create(SliciceModel model);
        Task<SliciceModel> GetSliciceById(int id);
        Task<List<SliciceModel>> Index(string search);
        List<SliciceModel> SearchSlicice(string Naziv);
    }
}