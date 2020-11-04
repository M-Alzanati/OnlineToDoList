namespace OnlineUserToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class filltodostatuses : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ToDoStatus (Name) VALUES ('Done')");
            Sql("INSERT INTO ToDoStatus (Name) VALUES ('Pending')");
           
        }

        public override void Down()
        {
            Sql("DELETE FROM ToDoStatus");
        }
    }
}
