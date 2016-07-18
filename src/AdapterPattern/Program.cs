using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdapterPattern
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var form = new Form1())
            using (var graphics = form.CreateGraphics())
            {
                var presenter = new MainPresenter(new Win32ShapeDrawService(graphics));

                form.OnDrawShapes += (sender, e) => presenter.DrawShapes();

                Application.Run(form);
            }
        }
    }
}
