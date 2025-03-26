using TodoApi.Models;

namespace TodoApi.Repositories;

public interface ITaskRepository
{
    Task<IEnumerable<TaskItem>> GetAllTasksAsync();
    Task<TaskItem> GetTaskByIdAsync(int id);
    Task<TaskItem> AddTaskAsync(TaskItem task);
    Task<TaskItem> UpdateTaskAsync(TaskItem task);
    Task<bool> DeleteTaskAsync(int id);
}