using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elight.Entity.ResponseModels
{
    public class Page<T>
    {
        public List<T> Items;

        public long TotalItems;
    }
}
