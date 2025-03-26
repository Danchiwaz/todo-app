using AutoMapper;
using TodoApi.DTOs;
using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.Services;

public class TaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;

    public TaskService(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TaskDto>> GetAllTasksAsync()
    {
        var tasks = await _taskRepository.GetAllTasksAsync();
        return _mapper.Map<IEnumerable<TaskDto>>(tasks);
    }

    public async Task<TaskDto> GetTaskByIdAsync(int id)
    {
        var task = await _taskRepository.GetTaskByIdAsync(id);
        return _mapper.Map<TaskDto>(task);
    }

    public async Task<TaskDto> AddTaskAsync(TaskDto taskDto)
    {
        var task = _mapper.Map<TaskItem>(taskDto);
        var newTask = await _taskRepository.AddTaskAsync(task);
        return _mapper.Map<TaskDto>(newTask);
    }

    public async Task<TaskDto> UpdateTaskAsync(int id, TaskDto taskDto)
    {
        var existingTask = await _taskRepository.GetTaskByIdAsync(id);
        if (existingTask == null) return null;

        _mapper.Map(taskDto, existingTask);
        var updatedTask = await _taskRepository.UpdateTaskAsync(existingTask);
        return _mapper.Map<TaskDto>(updatedTask);
    }

    public async Task<bool> DeleteTaskAsync(int id)
    {
        return await _taskRepository.DeleteTaskAsync(id);
    }
}