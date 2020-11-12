using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using DTOS;

namespace Controllers{

[ApiController]
public class NewsController : ControllerBase
  {
    private readonly NewsContext _context;
    
    public NewsController(NewsContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<NewsDTO>>> getNewsList()
    {
        return await _context.NewsItems.Select(item => NewsToDTO(item)).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<NewsDTO>> getNews(long id)
    {
        var news = await _context.NewsItems.FindAsync(id);
        if(news == null)
        {
            return NotFound();
        }

            return NewsToDTO(news);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutNews(long id, NewsEntity newsToCreate)
    {
        if(id != newsToCreate.Id)
        {
            return BadRequest();
        }

        var news = await _context.NewsItems.FindAsync(id);
        if(news == null)
        {
            return NotFound();
        }

        news.Image = newsToCreate.Image;
        news.Title = newsToCreate.Title;
        news.Subtitle = newsToCreate.Subtitle;
        news.Body = newsToCreate.Body;
        news.SignedBy = newsToCreate.SignedBy;
        news.DateCreated = newsToCreate.DateCreated;

        try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!NewsExists(id))
            {
                return NotFound();
            }

            return NoContent();

    }

    [HttpPost]
    public async Task<ActionResult<NewsDTO>> PostNews(CreateNewsDTO CreatedNews)
    {
        var news = new NewsEntity
        {
            Image = CreatedNews.Image,
            Title = CreatedNews.Title,
            Subtitle = CreatedNews.Subtitle,
            Body = CreatedNews.Body,
            SignedBy = CreatedNews.SignedBy,
            DateCreated = CreatedNews.DateCreated,
        };

        _context.NewsItems.Add(news);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
             nameof(getNews),
            new { id = news.Id },
            news
        );

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<NewsEntity>> DeleteForm(long id)
    {
        var news = await _context.NewsItems.FindAsync(id);
        if(news == null)
        {
            return NotFound();
        }
        _context.NewsItems.Remove(news);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    private bool NewsExists(long id)
    {
        return _context.NewsItems.Any(e => e.Id == id);
    }
    public static NewsDTO NewsToDTO(NewsEntity newsItem) =>
                new NewsDTO
                {
                Id = newsItem.Id,
                Image = newsItem.Image,
                Title = newsItem.Title,
                Subtitle = newsItem.Subtitle,
                Body = newsItem.Body
                };
    }

  }

