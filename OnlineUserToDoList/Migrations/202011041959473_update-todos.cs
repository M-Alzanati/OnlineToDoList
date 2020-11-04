namespace OnlineUserToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetodos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDoModels", "ToDoStatus_Id", c => c.Int());
            CreateIndex("dbo.ToDoModels", "ToDoStatus_Id");
            AddForeignKey("dbo.ToDoModels", "ToDoStatus_Id", "dbo.ToDoStatus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDoModels", "ToDoStatus_Id", "dbo.ToDoStatus");
            DropIndex("dbo.ToDoModels", new[] { "ToDoStatus_Id" });
            DropColumn("dbo.ToDoModels", "ToDoStatus_Id");
        }
    }
}
