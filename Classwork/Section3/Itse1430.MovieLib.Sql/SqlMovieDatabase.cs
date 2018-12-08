/*
 * ITSE1430
 * Sample implementation
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Itse1430.MovieLib.Sql
{
    /// <summary>Provides an implementation of <see cref="IMovieDatabase"/> using SQL Server.</summary>
    public class SqlMovieDatabase : MovieDatabase
    {
        /// <summary>Initializes an instance of the <see cref="SqlMovieDatabase"/> class.</summary>
        /// <param name="connectionString">The connection string.</param>
        public SqlMovieDatabase ( string connectionString )
        {
            //Validate
            if (connectionString == null)
                throw new ArgumentNullException(nameof(connectionString));
            if (connectionString == "")
                throw new ArgumentException("Connection string cannot be empty."
                            , nameof(connectionString));

            _connectionString = connectionString;
        }
        private readonly string _connectionString;

        protected override void AddCore( Movie movie )
        {
            //var conn = new SqlConnection(_connectionString);

            #region Approaches to adding parameters

            //Approach 1
            //var param = new SqlParameter("@title", System.Data.SqlDbType.VarChar);
            //param.Value = movie.Name;
            //cmd.Parameters.Add(param);

            //Approach 2
            //var param = cmd.Parameters.Add("@title", System.Data.SqlDbType.VarChar);
            //param.Value = movie.Name;

            //Approach 3            
            //cmd.Parameters.AddWithValue("@title", movie.Name);

            #endregion

            //Run command
            //try
            using (var conn = CreateConnection())
            {
                var cmd = new SqlCommand("AddMovie", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@title", movie.Name);
                cmd.Parameters.AddWithValue("@length", movie.RunLength);
                cmd.Parameters.AddWithValue("@isOwned", movie.IsOwned);
                cmd.Parameters.AddWithValue("@description", movie.Description);

                conn.Open();
                var result = cmd.ExecuteScalar();
                var id = Convert.ToInt32(result);
            };
            /*} finally
            {
                conn.Close();
            };*/
        }

        protected override void EditCore( Movie oldMovie, Movie newMovie )
        {
            using (var conn = CreateConnection())
            {
                //var cmd = new SqlCommand("AddMovie", conn);
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UpdateMovie";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var id = GetMovieId(oldMovie);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@title", newMovie.Name);
                cmd.Parameters.AddWithValue("@length", newMovie.RunLength);
                cmd.Parameters.AddWithValue("@isOwned", newMovie.IsOwned);
                cmd.Parameters.AddWithValue("@description", newMovie.Description);

                conn.Open();
                cmd.ExecuteNonQuery();
            };
        }
                
        protected override Movie FindByName( string name )
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<Movie> GetAllCore()
        {
            //Using a data set
            var ds = new DataSet();
            
            //Create connection
            using (var conn = CreateConnection())
            {
                var da = new SqlDataAdapter();
                var cmd = new SqlCommand("GetAllMovies", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Use data adapter to fill dataset
                da.SelectCommand = cmd;
                da.Fill(ds);
            };

            //Must have at least one table
            //if (!ds.Tables.OfType<DataTable>().Any())
            //    return Enumerable.Empty<Movie>();
            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if (table == null)
                return Enumerable.Empty<Movie>();

            //Enumerate the rows
            var movies = new List<Movie>();
            foreach (var row in table.Rows.OfType<DataRow>())
            {
                //Use ordinal or column names
                var movie = new SqlMovie() {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row.Field<string>("Title"),
                    Description = Convert.ToString(row[2]),
                    ReleaseYear = 1900,
                    RunLength = row.Field<int>(3),
                    IsOwned = Convert.ToBoolean(row[4]),
                };
                movies.Add(movie);
            };

            return movies;
        }

        protected override void RemoveCore( string name )
        {
            var movie = FindByName(name);
            if (movie == null)
                return;

            using (var conn = CreateConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "RemoveMovie";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var id = GetMovieId(movie);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            };
        }

        #region Private Members

        //Creates a connection to the DB
        private SqlConnection CreateConnection()
                => new SqlConnection(_connectionString);

        //Gets the ID if this is a SQL movie
        private object GetMovieId ( Movie movie )
        {
            var sql = movie as SqlMovie;

            return sql?.Id ?? 0;
        }

        #endregion
    }
}
