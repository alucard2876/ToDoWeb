using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoWebPart.Models
{
    public static class Hash
    {
        public static int GetHash(string str)
        {
            var result = 0;
            foreach (var item in str)
            {
                result += item * 3 + str.GetHashCode();
            }
            return result;
        }
    }
}
