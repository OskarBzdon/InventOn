using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using InverntOn.Models;

namespace InverntOn.Data
{
    public class DbContext
    {
        private readonly IDbConnection _conn;

        public DbContext(IDbConnection conn)
        {
            _conn = conn;
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }

    public class DbSet<T> where T : new()
    {
        private readonly IDbConnection _conn;

        public DbSet(IDbConnection conn)
        {
            _conn = conn;
        }

        public async Task<IEnumerable<T>> ToList()
        {
            using (_conn)
            {
                try
                {
                    _conn.Open();
                    DbCommand command = (DbCommand)_conn.CreateCommand();
                    command.CommandText = $"SELECT * FROM {nameof(T)}";
                    Task<DbDataReader> reader = Task.FromResult(await command.ExecuteReaderAsync());
                    return new List<T>();
                }
                catch(DbException dbException)
                {
                    Console.WriteLine($"DbException.Message: {dbException.Message}");
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Exception.Message: {exception.Message}");
                }
            }
            return new List<T>();
        }
        public async Task<T> FirstOrDefault(Predicate<T> func)
        {
            using (_conn)
            {
                try
                {
                    _conn.Open();
                    DbCommand command = (DbCommand) _conn.CreateCommand();
                    command.CommandText = $"SELECT * FROM {nameof(T)} WHERE";
                    Task<DbDataReader> reader = Task.FromResult(await command.ExecuteReaderAsync());
                    return new T();
                }
                catch (DbException dbException)
                {
                    Console.WriteLine($"DbException.Message: {dbException.Message}");
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Exception.Message: {exception.Message}");
                }
            }

            return new T();
        }
        public async void Add(T model)
        {
            using (_conn)
            {
                try
                {
                    _conn.Open();
                    DbCommand command = (DbCommand)_conn.CreateCommand();
                    command.CommandText = $"INSERT INTO {nameof(T)} VALUES()";
                    Task<DbDataReader> reader = Task.FromResult(await command.ExecuteReaderAsync());
                }
                catch (DbException dbException)
                {
                    Console.WriteLine($"DbException.Message: {dbException.Message}");
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Exception.Message: {exception.Message}");
                }
            }
        }
        public async void Update(int index, T model)
        {
            using (_conn)
            {
                try
                {
                    _conn.Open();
                    DbCommand command = (DbCommand)_conn.CreateCommand();
                    command.CommandText = $"UPDATE {nameof(T)} SET WHERE";
                    Task<DbDataReader> reader = Task.FromResult(await command.ExecuteReaderAsync());
                }
                catch (DbException dbException)
                {
                    Console.WriteLine($"DbException.Message: {dbException.Message}");
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Exception.Message: {exception.Message}");
                }
            }
        }
        public async void Remove(int index)
        {
            using (_conn)
            {
                try
                {
                    _conn.Open();
                    DbCommand command = (DbCommand)_conn.CreateCommand();
                    command.CommandText = $"DELETE FROPM {nameof(T)} WHERE";
                    Task<DbDataReader> reader = Task.FromResult(await command.ExecuteReaderAsync());
                }
                catch (DbException dbException)
                {
                    Console.WriteLine($"DbException.Message: {dbException.Message}");
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Exception.Message: {exception.Message}");
                }
            }
        }
    }
}
