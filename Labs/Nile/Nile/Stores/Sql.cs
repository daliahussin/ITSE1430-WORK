/* ITSE 1430
 * Dalia Hussin
 * 11/28/218
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Nile.Stores
{
    public class Sql
        : ProductDatabase
    {
        private SqlConnection connection;

        /// <summary>
        /// Open a connection to the database
        /// </summary>
        public Sql(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        /// <summary>
        /// Add new product to the database
        /// </summary>
        /// <param name="product">Product to add</param>
        /// <returns>Created producd or null if failed to add</returns>
        protected override Product AddCore(Product product)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Products VALUES(@Name, @Description, @Price, @IsDiscontinued)", connection);
            command.Parameters.Add("@Name", SqlDbType.VarChar).Value = product.Name;
            command.Parameters.Add("@Description", SqlDbType.VarChar).Value = product.Description;
            command.Parameters.Add("@Price", SqlDbType.Money).Value = product.Price;
            command.Parameters.Add("@IsDiscontinued", SqlDbType.Bit).Value = product.IsDiscontinued;
            command.ExecuteNonQuery();

            return product;
        }

        /// <summary>
        /// Return all the products from the database
        /// </summary>
        /// <returns>List of products</returns>
        protected override IEnumerable<Product> GetAllCore()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Products", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);

            List<Product> products = new List<Product>();

            foreach(DataRow row in table.Rows)
            {
                Product product = new Product();
                product.Id = int.Parse(row["Id"].ToString());
                product.Name = row["Name"].ToString();
                product.Description = row["Description"].ToString();
                product.Price = decimal.Parse(row["Price"].ToString());
                product.IsDiscontinued = row["IsDiscontinued"].ToString() == "1";

                products.Add(product);
            }

            return products;
        }

        /// <summary>
        /// Get a product from the database
        /// </summary>
        /// <param name="id">ID of product to retrieve</param>
        /// <returns>Product</returns>
        protected override Product GetCore(int id)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Products WHERE Id = @Id", connection);
            adapter.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count == 0)
                return null;

            DataRow row = table.Rows[0];

            Product product = new Product();
            product.Id = int.Parse(row["Id"].ToString());
            product.Name = row["Name"].ToString();
            product.Description = row["Description"].ToString();
            product.Price = decimal.Parse(row["Price"].ToString());
            product.IsDiscontinued = row["IsDiscontinued"].ToString() == "1";

            return product;
        }

        /// <summary>
        /// Get a product by name
        /// </summary>
        protected override Product GetCore(string name)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Products WHERE Name = @Name", connection);
            adapter.SelectCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;

            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count == 0)
                return null;

            DataRow row = table.Rows[0];

            Product product = new Product();
            product.Id = int.Parse(row["Id"].ToString());
            product.Name = row["Name"].ToString();
            product.Description = row["Description"].ToString();
            product.Price = decimal.Parse(row["Price"].ToString());
            product.IsDiscontinued = row["IsDiscontinued"].ToString() == "1";

            return product;
        }

        /// <summary>
        /// Delete a product from the database
        /// </summary>
        /// <param name="id">ID of the product to delete</param>
        protected override void RemoveCore(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Products WHERE Id = @Id", connection);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Udate a product's data
        /// </summary>
        /// <param name="existing">Old product data</param>
        /// <param name="newItem">New product data</param>
        /// <returns>New product data</returns>
        protected override Product UpdateCore(Product existing, Product newItem)
        {
            SqlCommand command = new SqlCommand("UPDATE Products SET Name = @Name, Description = @Description, Price = @Price, IsDiscontinued = @IsDiscontinued WHERE Id = @Id", connection);
            command.Parameters.Add("@Name", SqlDbType.VarChar).Value = newItem.Name;
            command.Parameters.Add("@Description", SqlDbType.VarChar).Value = newItem.Description;
            command.Parameters.Add("@Price", SqlDbType.Money).Value = newItem.Price;
            command.Parameters.Add("@IsDiscontinued", SqlDbType.Bit).Value = newItem.IsDiscontinued;
            command.Parameters.Add("@Id", SqlDbType.Int).Value = existing.Id;
            command.ExecuteNonQuery();

            return newItem;
        }
    }
}
