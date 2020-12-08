using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DTOS;
using Models;

namespace Controllers
{
    //[Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/newslists")]
    [ApiController]
    public class NewsListController : ControllerBase
    {
        private readonly NewsContext _context;

        public NewsListController(NewsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsList>>> GetNewsLists()
        {
            return await _context.NewsLists.Include(x => x.NewsItem).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NewsList>> GetNewsList(long id)
        {
            var newsItemList = await _context.NewsLists.FindAsync(id);

            if (newsItemList == null)
            {
                return NotFound();
            }

            await _context.Entry(newsItemList).Collection(x => x.NewsItem).LoadAsync();

            return newsItemList;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewsItemList(long id, NewNewsListDTO newsItemListDTO)
        {

            var newsItemList = await _context.NewsLists.FindAsync(id);
            if (newsItemList == null)
            {
                return NotFound();
            }

            newsItemList.Category = newsItemListDTO.Category;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!NewsItemListExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<NewsList>> PostTodoItemList(NewNewsListDTO newNewsListDTO)
        {
            var newsItemList = new NewsList {
                Category = newNewsListDTO.Category
            };
            _context.NewsLists.Add(newsItemList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNewsList", new { id = newsItemList.Id }, newsItemList);
        }

    
        [HttpDelete("{id}")]
        public async Task<ActionResult<NewsList>> DeleteNewsItemList(long id)
        {
            var newsItemList = await _context.NewsLists.FindAsync(id);
            if (newsItemList == null)
            {
                return NotFound();
            }

            await _context.Entry(newsItemList).Collection(x => x.NewsItem).LoadAsync();
            if(newsItemList.NewsItem.Count !=0)
            {
                return BadRequest("Cannot delete a non empty list");
            }

            _context.NewsLists.Remove(newsItemList);
            await _context.SaveChangesAsync();

            return newsItemList;
        }

        [HttpPost("{id}/news")]
        public async Task<ActionResult<NewsList>> PostNewsItemIntoList(long id, NewsDTO newsItemDTO)
        {
            var newsItemList = await _context.NewsLists.FindAsync(id);
            if (newsItemList == null)
            {
                return NotFound();
            }
            await _context.Entry(newsItemList).Collection(x => x.NewsItem).LoadAsync();

            var newsItem = new NewsEntity
            {
                Photo= newsItemDTO.Photo,
                Title= newsItemDTO.Title,
                Subtitle= newsItemDTO.Subtitle,
                Body= newsItemDTO.Body
            };

            newsItemList.NewsItem.Add(newsItem);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!NewsItemListExists(id))
            {
                return NotFound();
            }

            return CreatedAtAction("PostNewsItemIntoList", new { id = newsItem.Id }, NewsController.NewsToDTO(newsItem));
        }

        [HttpPost("{id}/news/{newsId}")]
        public async Task<IActionResult> AddNewsItemIntoList(long id, long newsId)
        {

            var newsItemList = await _context.NewsLists.FindAsync(id);
            if (newsItemList == null)
            {
                return NotFound("list not found");
            }

            var newsItem = await _context.NewsItems.FindAsync(newsId);
            if (newsItem == null)
            {
                return NotFound("news item not found");
            }

            await _context.Entry(newsItemList).Collection(x => x.NewsItem).LoadAsync();
            newsItemList.NewsItem.Add(newsItem);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsItemListExists(id))
                {
                    return NotFound("list not found");
                }

                if (!NewsItemExists(newsId))
                {
                    return NotFound("news item not found");
                }

            }

            return NoContent();
        }

        [HttpDelete("{id}/news/{newsId}")]
        public async Task<IActionResult> RemoveNewsItemFromList(long id, long newsId)
        {
            
            var newsItemList = await _context.NewsLists.FindAsync(id);
            if (newsItemList == null)
            {
                return NotFound("list not found");
            }

            var newsItem = await _context.NewsItems.FindAsync(newsId);
            if (newsItem == null)
            {
                return NotFound("todo item not found");
            }

            await _context.Entry(newsItemList).Collection(x => x.NewsItem).LoadAsync();
            newsItemList.NewsItem.Remove(newsItem);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsItemListExists(id))
                {
                    return NotFound("list not found");
                }

                if (!NewsItemExists(newsId))
                {
                    return NotFound("todo item not found");
                }

            }

            return NoContent();
        }

        private bool NewsItemListExists(long id)
        {
            return _context.NewsLists.Any(e => e.Id == id);
        }

        private bool NewsItemExists(long id)
        {
            return _context.NewsLists.Any(e => e.Id == id);
        }
    }
}
