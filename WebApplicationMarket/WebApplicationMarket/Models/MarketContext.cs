using Microsoft.AspNet.Identity;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebApplicationMarket.Models
{
    public class MarketContext:DbContext
    {
        public MarketContext() : base() { }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Controllers> Controllers { get; set; }
        public virtual DbSet<ControllerType> ControllerType { get; set; }
        public virtual DbSet<Es1> Es1 { get; set; }
        public virtual DbSet<Es2> Es2 { get; set; }
        public virtual DbSet<Es3> Es3 { get; set; }
        public virtual DbSet<Es4> Es4 { get; set; }
        public virtual DbSet<Es5> Es5 { get; set; }
        public virtual DbSet<Es6> Es6 { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }

        public string ValidLogin(string login)
        {
            string message = "";
            try
            {
                using(var dbContext = new MarketContext())
                {
                    var user = dbContext.Users.FirstOrDefault(u => u.Login == login);
                    if(user == null)
                    {
                        message = "";
                    }
                    else
                    {
                        message = "Пользователь с таким логином существует";
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }

        public string EncryptPassword(string pass)
        {
            string message = "";
            using(MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, pass);
                
                if(VerifyMd5Hash(md5Hash, pass, hash))
                {
                    return hash;
                }
            }
            return message;
        }

        private static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        //Verify a hash against a string.
        private static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            string hashOfInput = GetMd5Hash(md5Hash, input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if(0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Roles>().ToTable("Roles", "public");
            //modelBuilder.Entity().ToTable("Album", "public");
            //modelBuilder.Entity().ToTable("Cart", "public");
            //modelBuilder.Entity().ToTable("Order", "public");
            //modelBuilder.Entity().ToTable("OrderDetail", "public");
            //modelBuilder.Entity().ToTable("Genre", "public");
        }
    }
}