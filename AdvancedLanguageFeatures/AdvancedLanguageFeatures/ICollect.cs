using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedLanguageFeatures
{
    interface ICollect
    {
        Object this[int index] { get; set; }
    }
}
