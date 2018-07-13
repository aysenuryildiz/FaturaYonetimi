using DataEntities;

namespace BLL
{
    public class KeyValueModelHelper
    {
        public string GetValue(string key)
        {
            var db = new FaturaYonetimiDbModel();
            var value = new DAL.KeyValueModel_DAL().GetValue(key, db);
            return value == null ? string.Empty : value.Value;
        }
    }
}
