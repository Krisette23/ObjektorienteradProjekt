﻿using System.Data.SqlClient;
using System.Data.Entity;
using BookU_ClassLibrary.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BookU_ClassLibrary.Context
{
    public class BookUDBContext : DbContext
    {
        public BookUDBContext() : base("BookUDB"){}
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
       
        /// <summary>
        /// Resets our database
        /// </summary>
        public void Reset()
        {
            string connectionString = Database.Connection.ConnectionString;
            string commandText = "DECLARE @SQL VARCHAR(MAX)='' SELECT @SQL = @SQL + 'ALTER TABLE ' + QUOTENAME(FK.TABLE_SCHEMA) + '.' + QUOTENAME(FK.TABLE_NAME) + ' DROP CONSTRAINT [' + RTRIM(C.CONSTRAINT_NAME) +'];' + CHAR(13) FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME INNER JOIN (SELECT i1.TABLE_NAME, i2.COLUMN_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1 INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME WHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY') PT ON PT.TABLE_NAME = PK.TABLE_NAME EXEC (@SQL);EXEC sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT all'; EXEC sp_msforeachtable 'DROP TABLE ?'";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                conn.Open();
                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (System.Exception)
                    {
                        // throw;
                    }
                }
                conn.Close();
            }
            Database.Initialize(true);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Friend>()
                .HasRequired(a => a.RequestedBy)
                .WithMany(b => b.SentFriendRequests)
                .HasForeignKey(c => c.RequestedById);

            modelBuilder.Entity<Friend>()
                .HasRequired(a => a.RequestedTo)
                .WithMany(b => b.ReceievedFriendRequests)
                .HasForeignKey(c => c.RequestedToId);
        }
    }
}