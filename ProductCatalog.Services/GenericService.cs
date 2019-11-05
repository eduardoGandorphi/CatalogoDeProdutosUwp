using ProductCatalog.DAO;
using ProductCatalog.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity>
        where TEntity : class, IGenericEntity
    {
        //Contexto / Conexão com o Banco de Dados
        protected virtual DataContext DataContext { get; private set; }
        //Construtor da Service
        public GenericService(DataContext context)
        {
            DataContext = context;
        }
        //Método de Alteração de Dados
        public TEntity Alterar(TEntity model)
        {
            TEntity entity = DataContext
                                .Set<TEntity>()
                                .Attach(model);
            DataContext.Entry(entity).State = 
                System.Data.Entity.EntityState.Modified;

            return entity;
        }
        //Pesquisa por Codigo
        public TEntity BuscarPorCodigo(int codigo)
        {
            TEntity entity = DataContext
                                .Set<TEntity>()
                                .Find(codigo);
            //Isso é equivalente a:
            //Select * From Entidade Where Codigo = xxx
            return entity;
        }
        //Exclusão passando o Objeto
        public bool Excluir(TEntity model)
        {
            DataContext.Set<TEntity>().Remove(model);
            return true;
        }
        //Exclusão passando o Código
        public bool Excluir(int codigo)
        {
            return Excluir(BuscarPorCodigo(codigo));
        }
        //Inserção de Registro
        public TEntity Inserir(TEntity model)
        {
            TEntity entity = DataContext
                                .Set<TEntity>()
                                .Add(model);
            return entity;
        }
        //Listagem de todos Registros
        public IList<TEntity> Listar()
        {
            IList<TEntity> entities = 
                DataContext.Set<TEntity>()
                .Where(e=> e.Ativo == true).ToList();
            return entities;
        }
        //Listagem recebendo Filtro
        public IList<TEntity> Listar(Expression<Func<TEntity, bool>> filtro)
        {
            IList<TEntity> entities =
                DataContext.Set<TEntity>()
                    .Where(e=> e.Ativo==true)
                    .Where(filtro)
                    .ToList();
            return entities;
        }
    }
}
