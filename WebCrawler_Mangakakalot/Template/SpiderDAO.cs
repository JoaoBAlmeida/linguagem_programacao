using System;
using System.Collections.Generic;
using System.Text;
using WebCrawler_Mangakakalot.Models;
using Renci.SshNet.Messages.Connection;
using System.Data;
using System.Data.Odbc;
using MySql.Data.MySqlClient;
using Renci.SshNet.Security.Cryptography;

namespace WebCrawler_Mangakakalot.Template
{
    public abstract class SpiderDAO
    {
        protected abstract string GetConnectionURL();
        protected abstract string GetQuery();

        private bool state;
        private MySqlConnection connection;
        private MySqlCommand cmd;

        //Public function to open the db in question
        public void openDB()
        {
            connection = new MySqlConnection(GetConnectionURL());
            connection.Open();
        }

        //Create a command query to insert values in the database
        public bool SetIntoDB(Popular pop)
        {
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = GetQuery();
                cmd.Parameters.AddWithValue("@Title", pop.Title);
                cmd.Parameters.AddWithValue("@Link", pop.Link);
                cmd.ExecuteNonQuery();
                state = true;
            }catch(Exception e)
            {
                Console.WriteLine("Error on access to database: " + e.Message);
                state = false;
            }
            return state;
        }

        //Public function to close the db in question
        public void CloseBD()
        {
            connection.Close();
        }
    }
}
