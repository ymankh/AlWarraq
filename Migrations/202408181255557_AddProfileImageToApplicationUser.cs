﻿namespace AlWarraq.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProfileImageToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ProfileImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ProfileImage");
        }
    }
}
