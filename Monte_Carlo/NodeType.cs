using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monte_Carlo
{
    public enum NodeType
    {
        /// <summary>
        /// Узел пустой.
        /// </summary>
        Empty,
        /// <summary>
        /// Узел c атомом
        /// </summary>
        Full,
        /// <summary>
        /// Узлы которые послужат окном и не будут использоваться в дальнейшем
        /// </summary>
        Window
    }
}
