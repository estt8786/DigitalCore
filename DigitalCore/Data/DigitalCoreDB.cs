using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCore.Data
{
    public class DigitalCoreDB : DbContext
    {
        public DigitalCoreDB(DbContextOptions<DigitalCoreDB> options) : base(options) { }
    }
}
