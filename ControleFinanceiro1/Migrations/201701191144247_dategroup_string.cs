namespace ControleFinanceiro1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dategroup_string : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GastosMes", "DateGroup", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GastosMes", "DateGroup", c => c.DateTime());
        }
    }
}
