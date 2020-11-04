namespace OnlineUserToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class linkToDoWithUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("ToDoModels", "UserId", builder => builder.String(maxLength: 128) );
            AddForeignKey("ToDoModels", "UserId", "AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("ToDoModels", "UserId", "AspNetUsers");
        }
    }
}
