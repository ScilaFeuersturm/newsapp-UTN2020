using System.Collections.Generic;
using System.Threading.Tasks;
using DTOS;
using Models;

namespace Services
{
    public interface INewsItemService
    {
         Task<List<NewsEntity>> GetAllAsync();
         Task<NewsEntity> GetAsync(long id);

         Task UpdateAsync(long id, NewsDTO dto);
         Task<NewsEntity> CreateAsync(CreateNewsDTO dto, ApplicationUser appUser);

         Task DeleteAsync(long id);
    }
}