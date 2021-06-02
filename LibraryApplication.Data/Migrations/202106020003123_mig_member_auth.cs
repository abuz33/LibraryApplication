namespace LibraryApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_member_auth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "Authorization", c => c.String(maxLength: 1, fixedLength: true, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "Authorization");
        }
    }
}
