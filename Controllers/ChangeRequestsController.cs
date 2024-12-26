﻿using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ChangeRequestsController : ControllerBase
{
    private readonly ChangeRequestService _changeRequestService;
    private readonly ChangeRequestMapper _changeRequestMapper;

    public ChangeRequestsController(ChangeRequestService changeRequestService, ChangeRequestMapper changeRequestMapper)
    {
        _changeRequestService = changeRequestService;
        _changeRequestMapper = changeRequestMapper;
    }

    [HttpGet]
    public IActionResult GetAllChangeRequests()
    {
        var changeRequests = _changeRequestService.GetAllChangeRequests();
        var changeRequestDtos = changeRequests.Select(cr => _changeRequestMapper.MapToDto(cr));
        return Ok(changeRequestDtos);
    }

    [HttpGet("{id}")]
    public IActionResult GetChangeRequestById(int id)
    {
        var changeRequest = _changeRequestService.GetChangeRequestById(id);
        if (changeRequest == null)
        {
            return NotFound();
        }
        var changeRequestDto = _changeRequestMapper.MapToDto(changeRequest);
        return Ok(changeRequestDto);
    }

    [HttpPost]
    public IActionResult AddChangeRequest(ChangeRequestDto changeRequestDto)
    {
        var changeRequest = _changeRequestMapper.MapToEntity(changeRequestDto);
        _changeRequestService.AddChangeRequest(changeRequest);
        return CreatedAtAction(nameof(GetChangeRequestById), new { id = changeRequest.ChangeRequestId }, changeRequestDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateChangeRequest(int id, ChangeRequestDto updatedChangeRequestDto)
    {
        var updatedChangeRequest = _changeRequestMapper.MapToEntity(updatedChangeRequestDto);
        _changeRequestService.UpdateChangeRequest(id, updatedChangeRequest);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteChangeRequest(int id)
    {
        _changeRequestService.DeleteChangeRequest(id);
        return NoContent();
    }
}
