namespace OnlineUserToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removestatuscolumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("ToDoModels", "Status");
        }
        
        public override void Down()
        {
            AddColumn("ToDoModels", "Status", builder => builder.Int());
        }
    }
}
