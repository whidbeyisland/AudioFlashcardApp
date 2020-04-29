using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace WindowsFormsXUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void ReturnsFive()
        {
            Form2 form2 = new Form2();
            Assert.Equal(5, form2.returnFive());
        }
    }
}
