using System.ComponentModel.DataAnnotations;

namespace OnlineUserToDoList.Models
{
    public class ToDoStatus
    {
        [Key]
        public int Id { set; get; }

        public string Name { set; get; }
    }
}