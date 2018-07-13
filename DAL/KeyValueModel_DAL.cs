using DataEntities;
using System.Linq;

namespace DAL
{
    public class KeyValueModel_DAL
    {
        public KeyValueModel GetValue(string key, FaturaYonetimiDbModel db)
        {
            return db.KeyValueModel.Where(x => x.Key == key).FirstOrDefault();
        }
    }
}
