using System;
using System.IO;
using Microsoft.Data.Sqlite;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tuesday
{
    class Program
    {
        static void Main()
        {

                using (Ge2015Context data = new Ge2015Context()) {


                var query = data.Constituencies
                    .Where(c => c.Name=="Cambridge")
	                .Join(data.Candidates,one => one.OnsId, two => two.OnsId, (one,two) => new { Firstname=two.Firstname, Surname=two.Surname, Party=two.PartyId,Votes=two.Votes })
	                .OrderByDescending(x=>x.Votes)
	                .Take(3);

            foreach ( var t in query) {
                Console.WriteLine($"{t.Firstname} {t.Surname} {t.Party} {t.Votes}");
            }
            
        }
        }
    }
}