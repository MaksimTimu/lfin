using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lfin
{
    interface Id_
    {
        int id { get; }
    }
    class core
    {

        public static LichnFinEntities1 db = new LichnFinEntities1();
        public static int get_new_id<T>(System.Data.Entity.DbSet<T> x) where T: class, Id_
        {
            var a = x.OrderByDescending(y => y.id);
            if (a.Count() == 0)
                return 0;
            return a.First().id + 1;
        }
        public static int create_account(string name_)
        {
            var id_ = 0;
            var a = db.accounts.OrderByDescending(y => y.id);
            if (a.Count() != 0)
                id_ = a.First().id + 1;
            db.accounts.Add(new accounts { balance = 0, currency = "RUB", name = name_, id = id_ });
            db.SaveChanges();
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
            var id_ = 0;
            var a = db.categories.OrderByDescending(y => y.id);
            if (a.Count() != 0)
                id_ = a.First().id + 1;
            db.categories.Add(new categories { id = id_, name = name_, type = "" });
            db.SaveChanges();
            return id_;
        }
        public static int get_cat_id_by_name(string name_)
        {
            var a = db.categories.Where(x => x.name.ToLower() == name_.ToLower());
            if (a.Count() >= 1)
                return a.First().id;
            else
                return create_cat(name_);
        }
        public static List<int> explode_cats(string names)
        {
            var list = new List<int>();
            foreach (var a in names.Split(','))
            {
                var na = a.Trim();
                if (na.Length == 0)
                    continue;
                list.Add(get_cat_id_by_name(na));
            }
            return list;
        }
        public static void assign_cats(List<int> cats, int tx_id)
        {
            foreach (var a in cats)
            {
                var id_ = 0;
                var b = db.transaction_categories.OrderByDescending(y => y.id);
                if (b.Count() != 0)
                    id_ = b.First().id + 1;
                db.transaction_categories.Add(new transaction_categories { id = id_, category_id = a, transaction_id = tx_id });
                db.SaveChanges();
            }
        }
        public static void create_tx(string acc_name, double amount_, DateTime date_, string desc_, string cats)
        {
            var id_ = 0;
            var a = db.transactions.OrderByDescending(y => y.id);
            if (a.Count() != 0)
                id_ = a.First().id + 1;
            var tx = new transactions { account_id = get_account_id_by_name(acc_name), amount = amount_, date = date_, description = desc_, id = id_ };
            db.transactions.Add(tx);
            db.accounts.Where(x => x.id == tx.account_id).First().balance += amount_;
            db.SaveChanges();
            assign_cats(explode_cats(cats), id_);
        }
        public static string get_cats(int tx_id)
        {
            var a = db.transaction_categories.Where(x => x.transaction_id == tx_id);
            if (a.Count() == 0)
                return "";
            string ret = "";
            foreach (var c in a)
            {
                ret += db.categories.Where(x => x.id == c.category_id).First().name + ", ";
            }
            if (ret.Length > 2)
                ret = ret.Remove(ret.Length - 2, 2);
            return ret;
        }
    }
}