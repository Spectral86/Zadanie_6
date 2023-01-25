using Zadanie_6.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Zadanie_6.Services
{
    public interface IDatabaseService
    {
        IEnumerable<Animal> GetAnimals();
        public Animal GetAnimal(int id);

        public void DeleteAnimal(int Id_Animal);
        public void AddAnimal(Animal animal);
        public void UpdateAnimal(Animal animal);

    }

    public class DatabaseService : IDatabaseService
    {
        public IEnumerable<Animal> GetAnimals()
        {
            using var con = new SqlConnection("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=pd3415;Integrated Security=True;TrustServerCertificate=True");
            using var com = new SqlCommand("select * from animal", con);
            con.Open();
            var dr = com.ExecuteReader();
            var result = new List<Animal>();
            while (dr.Read())
            {
                Thread.Sleep(300);
                result.Add(new Animal
                {
                    IdAnimal = (int)dr["IdAnimal"],
                    Name = dr["Name"].ToString(),
                    Category = dr["Category"].ToString(),
                    Description = dr["Description"].ToString(),
                    Area = dr["Area"].ToString()
                });
            }
            return result;
        }

        public Animal GetAnimal(int id)
        {
            using var con = new SqlConnection("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=pd3415;Integrated Security=True;TrustServerCertificate=True");
            using var com = new SqlCommand("select * from animal WHERE IdAnimal = '" + id + "'", con);
            con.Open();
            var dr = com.ExecuteReader();
            Animal result = null;
            while (dr.Read())
            {
                Thread.Sleep(300);
                result = new Animal
                {
                    IdAnimal = (int)dr["IdAnimal"],
                    Name = dr["Name"].ToString(),
                    Category = dr["Category"].ToString(),
                    Description = dr["Description"].ToString(),
                    Area = dr["Area"].ToString()
                };
            }
            return result;
        }

        public void DeleteAnimal(int Id_Animal)
        {
            using var con = new SqlConnection("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=pd3415;Integrated Security=True;TrustServerCertificate=True");
            using var com = new SqlCommand("DELETE FROM animal WHERE IdAnimal = '" + Id_Animal + "'", con);
            con.Open();
            var dr = com.ExecuteNonQuery();
            con.Close();
        }

        public void AddAnimal(Animal animal)
        {
            using var con = new SqlConnection("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=pd3415;Integrated Security=True;TrustServerCertificate=True");
            using var com = new SqlCommand(
                "INSERT INTO " +
                "animal " +
                "(" +
               "[Name]" +
               ",[Description]" +
               ",[Category]" +
               ",[Area]" +
               ") VALUES (" +
                "'" + animal.Name + "'," +
                "'" + animal.Description + "'," +
                "'" + animal.Category + "'," +
                "'" + animal.Area + "'" +
                ")", con);
            con.Open();
            var dr = com.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateAnimal(Animal animal)
        {
            using var con = new SqlConnection("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=pd3415;Integrated Security=True;TrustServerCertificate=True");
            using var com = new SqlCommand(
                "UPDATE animal SET " +
                "(" +
               "[Name]" +
               ",[Description]" +
               ",[Category]" +
               ",[Area]" +
               ") VALUES (" +
                "'" + animal.Name + "'," +
                "'" + animal.Description + "'," +
                "'" + animal.Category + "'," +
                "'" + animal.Area + "'" +
                ")", con);
            con.Open();
            var dr = com.ExecuteNonQuery();
            con.Close();
        }


    }

}
