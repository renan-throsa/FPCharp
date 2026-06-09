using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface Option<T> { }

    public record None<T> : Option<T>;
    public record Some<T>(T Value) : Option<T>;

}
