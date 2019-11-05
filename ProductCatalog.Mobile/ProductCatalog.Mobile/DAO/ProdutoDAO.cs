using ProductCatalog.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductCatalog.Mobile.DAO
{
    public class ProdutoDAO
    {
        public void Inserir(ProdutoModel produto)
        {
            var conn = Connection.GetConn();
            conn.Insert(produto);
            conn.Close();
        }
        public IEnumerable<ProdutoModel> Read(Func<ProdutoModel, bool> query)
        {
            var conn = Connection.GetConn();
            return conn.Table<ProdutoModel>().Where(query).ToList();
        }
        public IEnumerable<ProdutoModel> ReadAll()
        {
            var conn = Connection.GetConn();
            return conn.Table<ProdutoModel>().ToList();
        }

        public void Update(ProdutoModel newProd)
        {
            var conn = Connection.GetConn();
            conn.Update(newProd);
            conn.Close();
        }

        public void Delete(ProdutoModel produto)
        {
            var conn = Connection.GetConn();
            conn.Delete(produto);
            conn.Close();
        }
    }
}
