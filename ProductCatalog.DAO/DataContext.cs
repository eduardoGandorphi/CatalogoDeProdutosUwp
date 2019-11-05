using ProductCatalog.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.DAO
{   
    //DbContext - Classe do EntityFramework
    //que concentra o acesso ao Banco de Dados
    public class DataContext : DbContext
    {
        //Crio um Construtor para o DataContext que 
        // passa a ConnectionString para a classe mãe (DbContext)
        public DataContext () : base(
            ConfigurationManager
                .ConnectionStrings["Conexao"]
                    .ConnectionString )
        {
            //Após Habilitar Migrations (Enable-Migrations) no projeto
            //Defino o Initializer do Banco de Dados para atualizar a versão do 
            //Database para a mais recente
            //Database.
            //    SetInitializer(
            //        new MigrateDatabaseToLatestVersion
            //            <DataContext, Migrations.Configuration>()
            //        );
        }
        //Evento que é disparado quando for criar/alterar o banco de dados
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remoção da Convenção de Pluralização automática dos nomes
            //das Tabelas
            modelBuilder.Conventions
                .Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        //Definir os DbSet's para cada uma das Models
        //Serão criadas Tabelas no Banco para os DbSets/Models 
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
