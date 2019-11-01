using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAAA.Models
{
    public class Logger : ILogger
    {
        private readonly PersonDbContext dbContext;

        public Logger(PersonDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void AddLog(string LogText)
        {
            dbContext.Logs.Add(new Log { LogText = LogText });
            dbContext.SaveChanges();
        }
    }
}
