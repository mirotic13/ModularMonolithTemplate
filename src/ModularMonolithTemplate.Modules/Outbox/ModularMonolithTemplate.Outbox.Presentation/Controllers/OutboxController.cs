using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModularMonolithTemplate.Outbox.Domain;
using ModularMonolithTemplate.Outbox.Presentation.Contracts;

namespace ModularMonolithTemplate.Outbox.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OutboxController(DbContext db) : ControllerBase
{
    [HttpGet("failed")]
    public async Task<ActionResult<List<OutboxFailedEventResponse>>> GetFailed()
    {
        var failed = await db.Set<OutboxMessage>()
            .Where(m => m.Failed && !m.Processed)
            .OrderByDescending(m => m.Created)
            .Select(m => new OutboxFailedEventResponse(
                m.Id,
                m.EventType,
                GetEventName(m.EventType),
                m.LastError,
                m.AttemptCount,
                m.LastAttemptAt,
                m.Created
            ))
            .ToListAsync();

        return Ok(failed);
    }

    [HttpPost("retry/{id:guid}")]
    public async Task<IActionResult> Retry(Guid id)
    {
        var msg = await db.Set<OutboxMessage>().FindAsync(id);
        if (msg is null || !msg.Failed)
            return NotFound();

        msg.Failed = false;
        msg.Processed = false;
        msg.Alerted = false;

        await db.SaveChangesAsync();
        return NoContent();
    }

    [HttpPost("dismiss/{id:guid}")]
    public async Task<IActionResult> Dismiss(Guid id)
    {
        var msg = await db.Set<OutboxMessage>().FindAsync(id);
        if (msg is null || !msg.Failed)
            return NotFound();

        msg.Alerted = true;

        await db.SaveChangesAsync();
        return NoContent();
    }

    private static string GetEventName(string eventType)
    {
        try
        {
            return Type.GetType(eventType)?.Name ?? "Unknown";
        }
        catch
        {
            return "Unknown";
        }
    }
}
