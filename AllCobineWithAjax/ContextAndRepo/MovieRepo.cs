using AllCobineWithAjax.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AllCobineWithAjax.ContextAndRepo
{
    public class MovieRepo
    { 
        public List<Movie> Display()
        {
            List<Movie> mov = new List<Movie>();
            using(SqlConnection conn=new SqlConnection("Data Source=AMANFDEV316\\SQLEXPRESS;Initial Catalog=AllCobineWithAjax;Integrated Security=True"))
            {
                using(SqlCommand cmd=new SqlCommand("Select * from Moviedata",conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        Movie mm = new Movie();
                        mm.MovieId = Convert.ToInt32(reader["MovieId"]);
                        mm.MovieName = reader["MovieName"].ToString();
                        mm.MovieBudget = Convert.ToInt32(reader["MovieBudget"]);
                        mov.Add(mm);

                    }
                }
            }
            return mov;
        }

        public void InsertData(Movie mm)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=AMANFDEV316\\SQLEXPRESS;Initial Catalog=AllCobineWithAjax;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("Insert into MovieData values(@MovieName,@MovieBudget)", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@MovieName", mm.MovieName);
                    cmd.Parameters.AddWithValue("@MovieBudget", mm.MovieBudget);
                    cmd.ExecuteNonQuery();
                }
            }


        }

        public void Delete(int movieId)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=AMANFDEV316\\SQLEXPRESS;Initial Catalog=AllCobineWithAjax;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("Delete from Moviedata where MovieId=@MovieId", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@MovieId", movieId);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Edit(Movie mm)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=AMANFDEV316\\SQLEXPRESS;Initial Catalog=AllCobineWithAjax;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("Update Moviedata set MovieName=@MovieName,MovieBudget=@MovieBudget where MovieId=@MovieId", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@MovieId", mm.MovieId);
                    cmd.Parameters.AddWithValue("@MovieName",mm.MovieName);
                    cmd.Parameters.AddWithValue("@MovieBudget", mm.MovieBudget);
                    cmd.ExecuteNonQuery();


                }
            }

        }
    }
}
