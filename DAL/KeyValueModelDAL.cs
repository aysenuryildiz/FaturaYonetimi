using Entities;
using System.Linq;

namespace DAL
{
    public class KeyValueModelDAL
    {
        public KeyValueModel GetValue(string key, FaturaYonetimiDbModel db)
        {
            return db.KeyValueModel.Where(x => x.Key == key).FirstOrDefault();
        }
    }
}
