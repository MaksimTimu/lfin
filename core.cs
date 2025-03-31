using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lfin
{
    class core
    {
  
        public static LichnFinEntities db = new LichnFinEntities();
        public static int create_account(string name_)
        {
            int id_ = db.accounts.OrderByDescending(x => x.id).FirstOrDefault().id + 1;
            db.accounts.Add(new accounts { balance = 0, currency = "RUB", name = name_, id = id_ });
            return id_;
        }
        public static int get_account_id_by_name(string name_)
        {
            var a = db.accounts.Where(x => x.name.ToLower() == name_.ToLower());
            if (a.Count() >= 1)
                return a.First().id;
            else
                return create_account(name_);
        }
        public static int create_cat(string name_)
        {
            int id_ = db.categories.OrderByDescending(x => x.id).FirstOrDefault().id + 1;
            db.categories.Add(new accounts { balance = 0, currency = "RUB", name = name_, id = id_ });
            return id_;
        }
        public static int get_account_id_by_name(string name_)
        {
            var a = db.accounts.Where(x => x.name.ToLower() == name_.ToLower());
            if (a.Count() >= 1)
                return a.First().id;
            else
                return create_account(name_);
        }
        public static bool create_tx(string acc_name, float amount, DateTime date, string desc, string cats)
        {

        }
}
