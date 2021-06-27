using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe
{
    public enum Players
    { 
        None,
        [Description("X")]
        Player1,
        [Description("O")]
        Player2,
        [Description("D")]
        Draw
    }
}
