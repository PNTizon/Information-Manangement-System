using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace InfoRegSystem.Classes
{
    public class ButtonShadow
    {
        private readonly List<Guna2Button> gunaButton;
        private readonly List<System.Windows.Forms.Button> systemButtons;

        public ButtonShadow(List<Guna2Button> gunaButtons)
        {
            this.gunaButton = gunaButtons;
        }
        public ButtonShadow(List<System.Windows.Forms.Button> systemButtons)
        {
            this.systemButtons = systemButtons;
        }
        public void CustomizeGunaButtons()
        {
            foreach (var button in gunaButton)
            {
                CustomizeButton(button);
            }
        }
        public void NormalButton()
        {
            foreach (var button in systemButtons)
            {
                NormalButton(button);
            }
        }
        public void CustomizeButton(Guna.UI2.WinForms.Guna2Button button2)
        {
            button2.HoverState.FillColor = button2.FillColor;
            button2.HoverState.BorderColor = button2.BorderColor;
            button2.HoverState.CustomBorderColor = button2.CustomBorderColor;
            button2.PressedColor = button2.FillColor;
        }
        public void NormalButton(System.Windows.Forms.Button button)
        {
            button.FlatAppearance.MouseOverBackColor = button.BackColor;
            button.FlatAppearance.MouseDownBackColor = button.BackColor;
            button.FlatAppearance.BorderColor = button.FlatAppearance.BorderColor;
        }
    }
}
