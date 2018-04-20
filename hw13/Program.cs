using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw13
{
    class Program
    {
        static void Main(string[] args)
        {
            using(UserModelContainer context = new UserModelContainer())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.UserSet.Add(new User() { Id = 1, Name = "AAA", OSId = 1 });
                        context.OSSet.Add(new OS() { Id = 1, NameOS = "Windows" });
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
                    
            }
        }
    }
}
