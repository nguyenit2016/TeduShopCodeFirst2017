namespace NUI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 256),
                        Phone = c.String(maxLength: 15),
                        Email = c.String(maxLength: 256),
                        Website = c.String(maxLength: 256),
                        Address = c.String(maxLength: 500),
                        Other = c.String(),
                        Lat = c.Double(),
                        Lng = c.Double(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactDetails");
        }
    }
}
