namespace F2021A6LF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingnewpropertyforartistandalbum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "Background", c => c.String());
            AddColumn("dbo.Artists", "Career", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artists", "Career");
            DropColumn("dbo.Albums", "Background");
        }
    }
}
