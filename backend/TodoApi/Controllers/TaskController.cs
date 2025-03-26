using Microsoft.AspNetCore.Mvc;
using TodoApi.DTOs;
using TodoApi.Services;

namespace TodoApi.Controllers;

[Route("api/tasks")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly TaskService _taskService;

    public TaskController(TaskService taskService)
    {
        _taskService = taskService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllTasks()
    {
        var tasks = await _taskService.GetAllTasksAsync();
        return Ok(tasks);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTask(int id)
    {
        var task = await _taskService.GetTaskByIdAsync(id);
        if (task == null) return NotFound();
        return Ok(task);
    }
    [HttpPost]
    public async Task<IActionResult> CreateTask(TaskDto taskDto)
    {
        var newTask = await _taskService.AddTaskAsync(taskDto);
        return CreatedAtAction(nameof(GetTask), new { id = newTask.Id }, newTask);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(int id, TaskDto taskDto)
    {
        var updatedTask = await _taskService.UpdateTaskAsync(id, taskDto);
        if (updatedTask == null) return NotFound();
        return Ok(updatedTask);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var deleted = await _taskService.DeleteTaskAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}