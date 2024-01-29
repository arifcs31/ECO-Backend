using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Shopex.Domain.Feed
{
    public abstract class BaseFeedTransformer
    {
        public virtual bool CheckIfHeaderOfFile(string row)
        {
            if (row.Contains("@"))
                return true;
            if (row.ToLower().Contains("category_id") || row.ToLower().Contains("upc"))
                return true;
            return false;
        }
    }
}
