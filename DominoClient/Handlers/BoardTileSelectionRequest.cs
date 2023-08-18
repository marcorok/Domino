using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoClient.Handlers
{
    internal enum SELECTION_ACTIONS { SELECT, UNSELECT}

    internal class BoardTileSelectionRequest
    {
        internal FormBoard FormBoard { get; set; }
        internal SELECTION_ACTIONS Action { get; set; }
    }
}
