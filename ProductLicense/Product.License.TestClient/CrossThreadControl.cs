using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product.License.TestClient
{
    public class CrossThreadControl
    {
        public static string GetPropText(Control control)
        {
            if (control.InvokeRequired)
            {
                object result = control.Invoke(new Func<Control, string>(GetPropText), control);
                return (string)result;
            }

            return control.Text;
        }

        public static void SetPropText(Control control, string text)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action<Control, string>(SetPropText), control, text);
                return;
            }

            control.Text = text;
        }
    }
}
