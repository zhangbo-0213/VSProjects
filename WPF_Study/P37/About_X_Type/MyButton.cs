using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace About_X_Type
{
    class MyButton:Button
    {
        public Type UserWindowType { get; set; }

        protected override void OnClick()
        {
            base.OnClick();//激发Click事件
            UserControl win=Activator.CreateInstance(this.UserWindowType) as UserControl;
            //MessageBox.Show("done");
            if (win != null)
            {
                Window window=new Window();
                window.Width = 300;
                window.Height = 300;
                window.Content = win;
                window.ShowDialog();
            }
        }
    }
}
