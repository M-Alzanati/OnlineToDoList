using System;

namespace OnlineUserToDoList.Models
{
    public class ToDoBindingModel
    {
        public int Id { set; get; }

        public string Title { set; get; }

        public string DueDate { set; get; }

        public int RecordNumber { set; get; }

        public int Status { set; get; }
    }
}