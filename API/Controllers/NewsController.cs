using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Models;
using DTOS;
using Services;

namespace Controllers{

[ApiController]
[Route("api/news")]
public class NewsController : ControllerBase
  {
    private readonly UserManager<ApplicationUser> _userManager;

    private readonly INewsItemService _newsItemService;

    
    public NewsController(UserManager<ApplicationUser> userManager,
                                INewsItemService newsItemService)
    {
            _userManager = userManager;
            _newsItemService = newsItemService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<NewsDTO>>> getNewsList()
    {
        var todoItems = await _newsItemService.GetAllAsync();
            return todoItems.Select(item => NewsToDTO(item)).ToList();
   
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<NewsDTO>> getNewsItem(long id)
    {
            var todoItem = await _newsItemService.GetAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return NewsToDTO(todoItem);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutNews(long id, NewsDTO newsToCreate)
    {
             if (id != newsToCreate.Id)
            {
                return BadRequest();
            }

            try
            {
                await _newsItemService.UpdateAsync(id, newsToCreate);            
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (InvalidOperationException e)
            {
                return NotFound(e.Message);
            }

            return NoContent();

    }

    [HttpPost]
    public async Task<ActionResult<NewsDTO>> PostNews(CreateNewsDTO newsItemDTO)
    {
       ApplicationUser appUser = null;
            
            if(newsItemDTO.UserId !=null)
            {
                appUser = await _userManager.FindByIdAsync(newsItemDTO.UserId);

                if(appUser is null)
                {
                    return BadRequest("Invalid userId");
                }

            }

            var newsItem = await _newsItemService.CreateAsync(newsItemDTO, appUser);

            return CreatedAtAction("GetNewsItem", new { id = newsItem.Id }, NewsToDTO(newsItem));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<NewsEntity>> DeleteForm(long id)
    {
        try
            {
                await _newsItemService.DeleteAsync(id);            
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }

            return NoContent();
    }
    public static NewsDTO NewsToDTO(NewsEntity newsItem) =>
                new NewsDTO
                {
                Id= newsItem.Id,
                Photo = newsItem.Photo,
                Title = newsItem.Title,
                Subtitle = newsItem.Subtitle,
                Body = newsItem.Body
                };
    }

  }

