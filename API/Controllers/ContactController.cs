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
public class ContactController : ControllerBase
  {
    private readonly NewsContext _context;
    
    public ContactController(NewsContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContactDTO>>> getContactFormList()
    {
        return await _context.ContactItems.Select(item => ContactToDTO(item)).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ContactDTO>> getContactForm(long id)
    {
        var contact = await _context.ContactItems.FindAsync(id);
        if(contact == null)
        {
            return NotFound();
        }

            
        return ContactToDTO(contact);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutContactForm(long id, ContactEntity contactForm)
    {
        if(id != contactForm.Id)
        {
            return BadRequest();
        }

        var contact = await _context.ContactItems.FindAsync(id);
        if(contact == null)
        {
            return NotFound();
        }

        contact.CompleteName = contactForm.CompleteName;
        contact.Mail = contactForm.Mail;
        contact.Phone = contactForm.Phone;
        contact.Message = contact.Message;

        try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ContactFormExists(id))
            {
                return NotFound();
            }

            return NoContent();

    }

    [HttpPost]
    public async Task<ActionResult<NewContactDTO>> PostContactForm(NewContactDTO newContactDTO)
    {
        var contact = new ContactEntity
        {
            CompleteName = newContactDTO.CompleteName,
            Mail = newContactDTO.Mail,
            Phone = newContactDTO.Phone,
            Message = newContactDTO.Message
        };

        _context.ContactItems.Add(contact);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
             nameof(getContactForm),
            new { id = contact.Id },
            contact
        );

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ContactEntity>> DeleteForm(long id)
    {
        var contact = await _context.ContactItems.FindAsync(id);
        if(contact == null)
        {
            return NotFound();
        }
        _context.ContactItems.Remove(contact);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    private bool ContactFormExists(long id)
    {
        return _context.ContactItems.Any(e => e.Id == id);
    }
    public static ContactDTO ContactToDTO(ContactEntity contact) =>
                new ContactDTO
                {
                    Id = contact.Id,
                    CompleteName = contact.CompleteName,
                    Mail = contact.Mail, 
                    Message = contact.Message
                };
    }

  }

