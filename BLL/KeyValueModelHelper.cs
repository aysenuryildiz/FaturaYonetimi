using Entities;

namespace BLL
{
    public class KeyValueModelHelper
    {
        public string GetValue(string key)
        {
            var db = new FaturaYonetimiDbModel();
            var value = new DAL.KeyValueModelDAL().GetValue(key, db);
            return value == null ? string.Empty : value.Value;
        }
    }
}
