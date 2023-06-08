using CookSmart.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;

namespace CookSmart.Models
{
    public class ReceitasSalvas
    {
        private readonly SQLiteConnection _database;

        public ReceitasSalvas()
        {
            try
            {
                var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ReceitasSalvas.db");
                SQLitePCL.Batteries.Init();
                _database = new SQLiteConnection(dbPath);
                _database.CreateTable<ModelCardapios>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<ModelCardapios> List()
        {
            try
            {
                return _database.Table<ModelCardapios>().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public int Create(ModelCardapios entity)
        {
            try
            {
                return _database.Insert(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public int Delete(ModelCardapios entity)
        {
            try
            {
                return _database.Delete(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
    }

    public class ReceitasCriadas
    {
        private readonly SQLiteConnection _database;

        public ReceitasCriadas()
        {
            try
            {
                var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ReceitasCriadas.db");
                SQLitePCL.Batteries.Init();
                _database = new SQLiteConnection(dbPath);
                _database.CreateTable<ModelCardapios>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<ModelCardapios> List()
        {
            try
            {
                return _database.Table<ModelCardapios>().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public int Create(ModelCardapios entity)
        {
            try
            {
                return _database.Insert(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public int Delete(ModelCardapios entity)
        {
            try
            {
                return _database.Delete(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
    }
}
