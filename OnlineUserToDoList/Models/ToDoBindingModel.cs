using System;

namespace OnlineUserToDoList.Models
{
    public class ToDoBindingModel
    {
        public int Id { set; get; }

        public string Title { set; get; }

        public DateTime DueDate { set; get; }
    }
}