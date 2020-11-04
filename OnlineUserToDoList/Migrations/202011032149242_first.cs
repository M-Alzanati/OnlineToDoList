namespace OnlineUserToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToDoModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecordNumber = c.Int(nullable: false),
                        Title = c.String(),
                        DueDate = c.DateTime(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ToDoModels");
        }
    }
}
