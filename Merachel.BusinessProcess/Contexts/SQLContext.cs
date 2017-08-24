using Merachel.Libraries;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merachel.BusinessProcess
{
    public class SQLContext : DbContext
    {
        public SQLContext() : base(DataAccessBase.GetConnectionString())
        {
            this.Database.Connection.ConnectionString = DataAccessBase.GetConnectionString();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ///creating table
            base.OnModelCreating(modelBuilder);
        }
    }
}
