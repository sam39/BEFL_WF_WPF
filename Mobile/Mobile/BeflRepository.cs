using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;


namespace Mobile
{
    public class BeflRepository
    {
        SQLiteConnection database;
        public BeflRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
            database.CreateTable<BL.Pos>();
            database.CreateTable<BL.Dep>();
            database.CreateTable<BL.Emp>();
        }
        public IEnumerable<BL.Emp> GetItems()
        {
            return (from i in database.Table<BL.Emp>() select i).ToList();

        }
        public BL.Emp GetItem(int id)
        {
            return database.Get<BL.Emp>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<BL.Emp>(id);
        }
        public int SaveItem(BL.Emp item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }




}
