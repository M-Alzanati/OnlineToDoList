namespace OnlineUserToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class linkstatuswithtodos : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE ToDoModels SET Status = 3");
            AddForeignKey("ToDoModels", "Status", "ToDoStatus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("ToDoModels", "Status", "ToDoStatus");
            Sql("UPDATE ToDoModels SET Status = 0");
        }
    }
}
