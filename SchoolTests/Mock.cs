using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SchoolDemo.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolTests
{
    public abstract class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly SchoolDbContext _db;

    }

    public Mock()
    {
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();
        _db = new SchoolDbContext(
            new DbContextOptionsBuilder<SchoolDbContext>()
            .UseSqlite(_connection)
            .Options);
        _db.Database.EnsureCreated();
        
    }
}
