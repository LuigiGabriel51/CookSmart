using SQLite;


namespace CookSmart.Models
{
    public class ReceitasProgramadas
    {
        private readonly SQLiteConnection _database;

        public ReceitasProgramadas()
        {
            try
            {
                SQLitePCL.Batteries.Init();
                var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RceitaProgramada.db");
                _database = new SQLiteConnection(dbPath);
                _database.CreateTable<ModelScheduleCook>(CreateFlags.ImplicitPK | CreateFlags.AllImplicit);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<ModelScheduleCook> List()
        {
            try
            {
                return _database.Table<ModelScheduleCook>().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public int Create(ModelScheduleCook entity)
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

        public int Delete(ModelScheduleCook entity)
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
        public int Update(ModelScheduleCook entity)
        {
            try
            {
                return _database.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
    }
    public class ModelScheduleCook
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string image { get; set; }
        public DateTime date { get; set; }
    }
}
