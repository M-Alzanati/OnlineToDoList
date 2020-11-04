namespace OnlineUserToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtodostatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToDoStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ToDoModels", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ToDoModels", "Status");
            DropTable("dbo.ToDoStatus");
        }
    }
}
