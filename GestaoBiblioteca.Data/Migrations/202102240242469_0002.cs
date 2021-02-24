namespace GestaoBiblioteca.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0002 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pessoas", "Logradouro", c => c.String());
            DropColumn("dbo.Pessoas", "Lograroudo");
            DropColumn("dbo.Livros", "Nome");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Livros", "Nome", c => c.String());
            AddColumn("dbo.Pessoas", "Lograroudo", c => c.String());
            DropColumn("dbo.Pessoas", "Logradouro");
        }
    }
}
