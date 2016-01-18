using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookList.Core.Tests
{
    public class TestBase
    {
        protected static string CreateStringWithLength(int length)
        {
            return new string('q', length);
        }
    }
}
