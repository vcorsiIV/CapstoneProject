using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ErieHack_TeamEdgwater.Models.Graph
{
    public class LakeErie : DbContext
    {
        public DbSet<LakeData> Lake { get; set; }


    }
}