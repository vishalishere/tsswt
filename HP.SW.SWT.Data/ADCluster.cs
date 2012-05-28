using System.Collections.Generic;
using System.Linq;

using ENT = HP.SW.SWT.Entities;

namespace HP.SW.SWT.Data
{
    public class ADCluster : ADBase
    {
        #region Get's
        public static IEnumerable<ENT.Cluster> GetAll()
        {
            return from c in Context.Cluster
                   select new ENT.Cluster
                   {
                       ID = c.IdcLuster,
                       ShortDescription = c.ShortDescription,
                       Description = c.Description
                   };
        }

        public static ENT.Cluster Get(int id)
        {
            return (from c in Context.Cluster
                    where c.IdcLuster == id
                    select new ENT.Cluster
                    {
                        ID = c.IdcLuster,
                        ShortDescription = c.ShortDescription,
                        Description = c.Description
                    }).FirstOrDefault();
        }
        #endregion

        public static void Insert(ENT.Cluster cluster)
        {
            using (SwT ctx = Context)
            {
                Data.Cluster c = new Cluster
                {
                    Description = cluster.Description,
                    IdcLuster = cluster.ID,
                    ShortDescription = cluster.ShortDescription
                };
                ctx.Cluster.InsertOnSubmit(c);
                ctx.SubmitChanges();
            }
        }

        public static void Update(int id, ENT.Cluster cluster)
        {
            using (SwT ctx = Context)
            {
                Cluster dataCluster = (from c in ctx.Cluster
                                       where c.IdcLuster == cluster.ID
                                       select c).FirstOrDefault();
                dataCluster.ShortDescription = cluster.ShortDescription;
                dataCluster.Description = cluster.Description;

                ctx.SubmitChanges();
            }
        }

        public static void Delete(int id, ENT.Cluster cluster)
        {
            using (SwT ctx = Context)
            {
                Cluster dataCluster = (from c in ctx.Cluster
                                       where c.IdcLuster == cluster.ID
                                       select c).FirstOrDefault();
                ctx.Cluster.DeleteOnSubmit(dataCluster);
                ctx.SubmitChanges();
            }
        }
    }
}
