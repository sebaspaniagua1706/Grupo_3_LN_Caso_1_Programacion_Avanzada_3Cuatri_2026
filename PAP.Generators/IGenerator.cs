using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAP.Generators
{
    public interface IGenerator
    {
        string EntityName { get; }
        int Count();
        GeneratorResult Generate();
    }
}
