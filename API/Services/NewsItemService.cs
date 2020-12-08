using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DTOS;
using Models;

namespace Services
{
    public class NewsItemService : INewsItemService
    {
        private readonly NewsContext _context;

        public NewsItemService(NewsContext context)
        {
            _context = context;
        }

        public async Task<List<NewsEntity>> GetAllAsync()
        {
            return await _context.NewsItems.ToListAsync();
        }

        public async Task<NewsEntity> GetAsync(long id)
        {
            return await _context.NewsItems.Include(i => i.Responsible).
                            FirstOrDefaultAsync( i => i.Id ==id);
        }

        public async Task UpdateAsync(long id, NewsDTO dto)
        {
            var item = await _context.NewsItems.FindAsync(id);

            if(item is null)
            {
                throw new ArgumentException("item not found");
            }
            
            item.Photo = dto.Photo;
            item.Title = dto.Title;
            item.Subtitle = dto.Subtitle;
            item.Body = dto.Body;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!NewsItemExists(id))
            {
                throw new InvalidOperationException($"item {id} has been deleted");
            }
        }

        public async Task<NewsEntity> CreateAsync(CreateNewsDTO dto, ApplicationUser appUser)
        {
            var newsItem = new NewsEntity
            {
                Photo = dto.Photo,
                Title = dto.Title,
                Subtitle = dto.Subtitle,
                Body = dto.Body,
                Responsible = appUser
            };

            _context.NewsItems.Add(newsItem);
            await _context.SaveChangesAsync();

            return newsItem;
        }
        public async Task DeleteAsync(long id)
        {
            var newsItem = await _context.NewsItems.FindAsync(id);
            if (newsItem == null)
            {
                throw new ArgumentException("item not found");
            }

            _context.NewsItems.Remove(newsItem);
            await _context.SaveChangesAsync();
        }

        private bool NewsItemExists(long id)
        {
            return _context.NewsItems.Any(e => e.Id == id);
        }
    }
}
