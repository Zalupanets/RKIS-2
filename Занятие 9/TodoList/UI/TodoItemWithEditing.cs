using TodoList;

namespace TodoList.UI
{
    public class TodoItemWithEditing
    {
        public TodoItem Todo { get; set; } = new TodoItem();
        public bool IsEditing { get; set; }
    }
}
