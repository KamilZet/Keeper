using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqKeeper
{
    public class Program
    {
        public static void  Main()
        {
            KeeperContext keep = new KeeperContext();
            var ret = from e in keep.GetEmployees() select e.FirstName;

            { ISingleResult<Employee> e = keep.GetEmployees(); }

            Console.Read();
            //var ret = from e in keep.Employee select e.LastName;
        }
    }
}
