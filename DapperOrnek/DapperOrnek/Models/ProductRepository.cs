using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperOrnek.Models
{
    public class ProductRepository
    {
        private string conn;
        public ProductRepository()
        {
            conn = "Data Source=(localdb)\\MssqlLocalDb;Initial Catalog=NorthwindDapper;Integrated Security=True";
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(conn);
            }
        }
        //GET
        public IList<Product> GetAll()
        {
            List<Product> products;
            using (var sqlConnection = new SqlConnection(conn))
            {

                sqlConnection.Open();
                products = sqlConnection.Query<Product>("SELECT * FROM Products").ToList();

            }
            return products;
        }
        //GET BY ID
        public Product GetById(int id)
        {
            
            using (var sqlConnection = new SqlConnection(conn))
            {
                sqlConnection.Open();
                string sql = @"SELECT * FROM Products WHERE ProductId=@ProductId";
                return sqlConnection.Query<Product>(sql, new { ProductId = id }).FirstOrDefault();
            }
        }
        //INSERT
        public void AddProduct(Product product)
        {
            using (var sqlConnection = new SqlConnection(conn))
            {

                sqlConnection.Open();
                string sql = @"INSERT INTO Products ( ProductName, UnitPrice, UnitsInStock, Discontinued) VALUES ( @ProductName, @UnitPrice, @UnitsInStock, @Discontinued) ";
                sqlConnection.Query(sql, product);

            }
        }
        //UPDATE:
        public void Update(Product product)
        {
            using (var sqlConnection = new SqlConnection(conn))
            {

                sqlConnection.Open();
                string sql = @"UPDATE Products SET ProductName = @ProductName, UnitPrice = @UnitPrice, UnitsInStock  = @UnitsInStock, Discontinued=@Discontinued WHERE ProductId = @ProductId";
                sqlConnection.Query(sql, product);

            }
        }
        //DELETE 
        public void Delete(Product product)
        {
            using (var sqlConnection = new SqlConnection(conn))
            {

                sqlConnection.Open();
                string sql = @"DELETE FROM Products WHERE ProductId = @ProductId";
                sqlConnection.Query(sql, product);

            }
        }
    }
}
