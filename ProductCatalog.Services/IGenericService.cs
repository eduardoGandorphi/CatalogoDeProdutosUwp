using ProductCatalog.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProductCatalog.Services
{
    public interface IGenericService<TEntity>
        where TEntity : class, IGenericEntity
    {
        TEntity BuscarPorCodigo(int codigo);
        TEntity Inserir(TEntity model);
        TEntity Alterar(TEntity model);
        bool Excluir(TEntity model);
        bool Excluir(int codigo);
        IList<TEntity> Listar();
        IList<TEntity> Listar(Expression<Func<TEntity,bool>> filtro);
    }
}