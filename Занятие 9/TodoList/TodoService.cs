using Microsoft.EntityFrameworkCore;

namespace TodoList
{
	public class TodoService
	{
		private readonly AppDbContext _context;

		public TodoService(AppDbContext context)
		{
			_context = context;
		}

		public async Task<TodoItem> AddTodo(TodoItem item)
		{
			_context.Todos.Add(item);
			await _context.SaveChangesAsync();
			return item;
		}

		public async Task<TodoItem?> UpdateTodo(TodoItem item)
		{
			var existingTodo = await _context.Todos.FindAsync(item.Id);
			if (existingTodo == null)
			{
				return null;
			}

			existingTodo.Text = item.Text;
			existingTodo.IsCompleted = item.IsCompleted;
			existingTodo.EndTime = item.IsCompleted ? DateTime.Now : null;

			await _context.SaveChangesAsync();
			return existingTodo;
		}

		public async Task DeleteTodo(Guid id)
		{
			var todoToDelete = await _context.Todos.FindAsync(id);
			if (todoToDelete != null)
			{
				_context.Todos.Remove(todoToDelete);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<List<TodoItem>> GetAllTodos()
		{
			return await _context.Todos.ToListAsync();
		}

		public async Task<TodoItem?> GetByIdTodos(Guid id)
		{
			return await _context.Todos.FindAsync(id);
		}
	}
}
