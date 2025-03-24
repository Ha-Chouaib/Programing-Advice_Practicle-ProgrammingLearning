using System;
using System.Windows.Forms;
using System.Drawing;


namespace MyCustomControls
{
     public class MyHoverButton:Button
    {


        protected Color OriginalBackColor = new Color();
        protected Color OriginalForeColor = new Color();

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            OriginalBackColor = this.BackColor;
            OriginalForeColor = this.ForeColor;

            this.BackColor = Color.Black;
            this.ForeColor = Color.Beige;

        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = OriginalBackColor;
            this.ForeColor = OriginalForeColor;
        }

    }
}
