namespace OnlineUserToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeoldforigenkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("ToDoModels", "Status", "ToDoStatus");
        }

        public override void Down()
        {
            AddForeignKey("ToDoModels", "Status", "ToDoStatus", "Id");
        }
    }
}
