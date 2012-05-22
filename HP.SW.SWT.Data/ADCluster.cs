using System.Collections.Generic;
using System.Linq;

using ENT = HP.SW.SWT.Entities;

namespace HP.SW.SWT.Data
{
    public class ADCluster : ADBase
    {
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
    }
}
