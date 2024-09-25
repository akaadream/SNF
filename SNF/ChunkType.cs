using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNF
{
    internal class ChunkType(params Type[] types)
    {
        public Type[] Types { get; private set; } = types;
    }
}
