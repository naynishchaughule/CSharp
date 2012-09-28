using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppHooks;
using System.Windows.Forms;

namespace PlugIn
{
    [MyCustomAttributes(Url="naynish p. chaughule")]
    public class DisplayPlugIn : MyApplicationInterface
    {
        void MyApplicationInterface.DisplayMessage()
        {
            MessageBox.Show("Plug-in called!");
        }
    }
}
