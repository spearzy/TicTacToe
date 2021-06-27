using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe
{
   public static class Helpers
    {
        public static string GetDescription(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var description = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return description.Length > 0 ? description[0].Description : value.ToString();
        }
    }
}
