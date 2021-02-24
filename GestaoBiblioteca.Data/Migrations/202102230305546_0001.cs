namespace GestaoBiblioteca.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Emprestimos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LivroId = c.Int(nullable: false),
                        FuncionarioId = c.Int(nullable: false),
                        PessoaId = c.Int(nullable: false),
                        DataEmprestimo = c.DateTime(nullable: false),
                        DataMaxEmprestimo = c.DateTime(nullable: false),
                        DataDevolucao = c.DateTime(),
                        EmprestimoSituacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoas", t => t.FuncionarioId, cascadeDelete: false)
                .ForeignKey("dbo.Livros", t => t.LivroId, cascadeDelete: true)
                .ForeignKey("dbo.Pessoas", t => t.PessoaId, cascadeDelete: false)
                .Index(t => t.LivroId)
                .Index(t => t.FuncionarioId)
                .Index(t => t.PessoaId);
            
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cpf = c.String(),
                        Rg = c.String(),
                        Lograroudo = c.String(),
                        Numero = c.String(),
                        Complemento = c.String(),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        Estado = c.String(),
                        Tipo = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Livros",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoriaId = c.Int(nullable: false),
                        AutorId = c.Int(nullable: false),
                        Isbn = c.String(maxLength: 18),
                        Nome = c.String(),
                        Titulo = c.String(),
                        Editora = c.String(),
                        Edicao = c.String(),
                        Ano = c.String(),
                        Situacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoas", t => t.AutorId, cascadeDelete: true)
                .Index(t => t.AutorId)
                .Index(t => t.Isbn, unique: true, name: "IX_ISBN");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Emprestimos", "PessoaId", "dbo.Pessoas");
            DropForeignKey("dbo.Emprestimos", "LivroId", "dbo.Livros");
            DropForeignKey("dbo.Livros", "AutorId", "dbo.Pessoas");
            DropForeignKey("dbo.Emprestimos", "FuncionarioId", "dbo.Pessoas");
            DropIndex("dbo.Livros", "IX_ISBN");
            DropIndex("dbo.Livros", new[] { "AutorId" });
            DropIndex("dbo.Emprestimos", new[] { "PessoaId" });
            DropIndex("dbo.Emprestimos", new[] { "FuncionarioId" });
            DropIndex("dbo.Emprestimos", new[] { "LivroId" });
            DropTable("dbo.Livros");
            DropTable("dbo.Pessoas");
            DropTable("dbo.Emprestimos");
            DropTable("dbo.Categorias");
        }
    }
}
