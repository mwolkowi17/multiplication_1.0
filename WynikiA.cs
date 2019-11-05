using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace mnozenie
{
    class WynikiA: DbContext
    {
        public DbSet<Grade> Wyniki { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=wyniki.db");
    }

    /*public class Grade
    {
        public int GradeId { get; set; }
        public string GradeValue { get; set; }
        public string Numberofex { get; set; }

        public string Ocena { get; set; }
        public string Date { get; set; }


    }*/
}
