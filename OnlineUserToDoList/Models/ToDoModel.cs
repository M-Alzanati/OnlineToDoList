using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineUserToDoList.Models
{
    public class ToDoModel
    {
        [Key]
        public int Id { set; get; }

        public int RecordNumber { set; get; }

        public string Title { set; get; }

        public DateTime DueDate { set; get; }

        public string UserId { set; get; }

        public ToDoStatus ToDoStatus { set; get; }
    }
}