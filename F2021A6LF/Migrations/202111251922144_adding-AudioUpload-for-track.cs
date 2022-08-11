namespace F2021A6LF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingAudioUploadfortrack : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tracks", "AudioContentType", c => c.String());
            AddColumn("dbo.Tracks", "Audio", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tracks", "Audio");
            DropColumn("dbo.Tracks", "AudioContentType");
        }
    }
}
