using Bank_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BankSystem
{
    public class clsUtil_PL
    {
       
        public static class TextBoxHelper
        {
            private static KeyPressEventHandler _numericHandler;

            public static void AllowOnlyNumbers(TextBox textBox, bool allowDecimal = false)
            {
                if (_numericHandler != null)
                    textBox.KeyPress -= _numericHandler;

                _numericHandler = (s, e) =>
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        if (!(allowDecimal && e.KeyChar == '.'))
                            e.Handled = true;
                    }

                    if (allowDecimal && e.KeyChar == '.' && ((TextBox)s).Text.Contains('.'))
                        e.Handled = true;
                };

                textBox.KeyPress += _numericHandler;
            }

            public static void RemoveNumericFilter(TextBox textBox)
            {
                if (_numericHandler != null)
                    textBox.KeyPress -= _numericHandler;
            }
        }
        public static class FormHelper
        {
           
            public static Form CreateFormInstance(string formName)
            {
                if (string.IsNullOrWhiteSpace(formName))
                    return null;

                var assembly = Assembly.GetExecutingAssembly();

                var formType = assembly.GetTypes()
                    .FirstOrDefault(t => t.Name.Equals(formName, StringComparison.OrdinalIgnoreCase)
                                         && t.IsSubclassOf(typeof(Form)));

                if (formType == null)
                {
                    return null;
                }

                return (Form)Activator.CreateInstance(formType);
            }

        }

    }
}
