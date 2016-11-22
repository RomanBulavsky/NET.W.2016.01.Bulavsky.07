using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public interface IComparer<in T>
    //TODO: Read http://stackoverflow.com/questions/28687446/why-does-reshaper-suggest-me-to-make-type-parameter-t-contravariant
    {
        int Compare(T a, T b);
    }
}
