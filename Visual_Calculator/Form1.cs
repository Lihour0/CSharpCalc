using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CSharpCalc
{
    enum Calculator_Opertaions
    {
        none = -1,
        add = 0,
        subtract = 1,
        multiplicate = 2,
        divide = 3,
    }
    enum Calculator_Current_Number
    {
        leftNumber = 0,
        rightNumber = 1,
    }
    public partial class FrmCalculator : Form
    {
        double dblNum1, dblNum2, dblResult;
        Calculator_Opertaions _operation;
        Calculator_Current_Number ccn;
        bool numlock;
        private bool protectKeys;
        private void btnNumeric_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            apply_key(btn.Text);
        }
        private void apply_key(string t)
        {
            lblDisplay.Text += t;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ccn == Calculator_Current_Number.leftNumber)
            {
                dblNum1 = double.Parse(lblDisplay.Text);
                lblNum1.Text = lblDisplay.Text;
                lblDisplay.Text = "";
                ccn = Calculator_Current_Number.rightNumber;
                _operation = Calculator_Opertaions.add;
                lblOperation.Text = "+";
            }
            else if (ccn == Calculator_Current_Number.rightNumber)
            {

            }
        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (ccn == Calculator_Current_Number.rightNumber)
            {
                dblNum2 = double.Parse(lblDisplay.Text);
                lblNum2.Text = lblDisplay.Text;
                switch (_operation)
                {
                    case Calculator_Opertaions.none:
                        break;
                    case Calculator_Opertaions.add:
                        dblResult = dblNum1 + dblNum2;
                        break;
                    case Calculator_Opertaions.subtract:
                        dblResult = dblNum1 - dblNum2;
                        break;
                    case Calculator_Opertaions.multiplicate:
                        dblResult = dblNum1 * dblNum2;
                        break;
                    case Calculator_Opertaions.divide:
                        dblResult = dblNum1 / dblNum2;
                        break;
                    default:
                        break;
                }
                lblDisplay.Text = dblResult.ToString();
                restartCalculator();
            }
        }

        private void restartCalculator()
        {
            dblNum1 = 0;
            dblNum2 = 0;
            dblResult = 0;
            ccn = Calculator_Current_Number.leftNumber;
            _operation = Calculator_Opertaions.none;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (ccn == Calculator_Current_Number.leftNumber)
            {
                dblNum1 = double.Parse(lblDisplay.Text);
                lblNum1.Text = lblDisplay.Text;
                lblDisplay.Text = "";
                ccn = Calculator_Current_Number.rightNumber;
                _operation = Calculator_Opertaions.subtract;
                lblOperation.Text = "-";
            }
            else if (ccn == Calculator_Current_Number.rightNumber)
            {

            }
        }

        private void btnMultiplicate_Click(object sender, EventArgs e)
        {
            if (ccn == Calculator_Current_Number.leftNumber)
            {
                dblNum1 = double.Parse(lblDisplay.Text);
                lblNum1.Text = lblDisplay.Text;
                lblDisplay.Text = "";
                ccn = Calculator_Current_Number.rightNumber;
                _operation = Calculator_Opertaions.multiplicate;
                lblOperation.Text = "X";
            }
            else if (ccn == Calculator_Current_Number.rightNumber)
            {

            }
        }
        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (ccn == Calculator_Current_Number.leftNumber)
            {
                dblNum1 = double.Parse(lblDisplay.Text);
                lblNum1.Text = lblDisplay.Text;
                lblDisplay.Text = "";
                ccn = Calculator_Current_Number.rightNumber;
                _operation = Calculator_Opertaions.divide;
                lblOperation.Text = "/";
            }
            else if (ccn == Calculator_Current_Number.rightNumber)
            {

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "";
            lblNum1.Text = "";
            lblNum2.Text = "";
            lblOperation.Text = "";
            restartCalculator();
        }

        private void FrmCalculator_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.Back:
                    btnBackSpace_Click(sender, e);
                    break;
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    btnEnter_Click(sender, e);
                    break;
                case Keys.Escape:
                    btnClear_Click(sender, e);
                    break;
                case Keys.D0:
                    apply_key("0");
                    break;
                case Keys.D1:
                    apply_key("1");
                    break;
                case Keys.D2:
                    apply_key("2");
                    break;
                case Keys.D3:
                    apply_key("3");
                    break;
                case Keys.D4:
                    apply_key("4");
                    break;
                case Keys.D5:
                    apply_key("5");
                    break;
                case Keys.D6:
                    apply_key("6");
                    break;
                case Keys.D7:
                    apply_key("7");
                    break;
                case Keys.D8:
                    apply_key("8");
                    break;
                case Keys.D9:
                    apply_key("9");
                    break;
                case Keys.NumPad0:
                    apply_key("0");
                    break;
                case Keys.NumPad1:
                    apply_key("1");
                    break;
                case Keys.NumPad2:
                    apply_key("2");
                    break;
                case Keys.NumPad3:
                    apply_key("3");
                    break;
                case Keys.NumPad4:
                    apply_key("4");
                    break;
                case Keys.NumPad5:
                    apply_key("5");
                    break;
                case Keys.NumPad6:
                    apply_key("6");
                    break;
                case Keys.NumPad7:
                    apply_key("7");
                    break;
                case Keys.NumPad8:
                    apply_key("8");
                    break;
                case Keys.NumPad9:
                    apply_key("0");
                    break;
                case Keys.Multiply:
                    break;
                case Keys.Add:
                    btnAdd_Click(sender, e);
                    break;
                case Keys.Subtract:
                    btnMinus_Click(sender, e);
                    break;
                case Keys.Decimal:
                    break;
                case Keys.Divide:
                    break;
                case Keys.NumLock:
                    if (numlock)
                    {
                        btnNumLock.BackColor = btn0.BackColor;
                        numlock = false;
                    }
                    else
                    {
                        btnNumLock.BackColor = Color.Green;
                        numlock = true;
                    }
                    break;
                case Keys.Oem1:
                    break;
                case Keys.Oem2:
                    break;
                case Keys.Oem3:
                    break;
                case Keys.Oem4:
                    break;
                case Keys.Oem5:
                    break;
                case Keys.Oem6:
                    break;
                case Keys.Oem7:
                    break;
                case Keys.Oem8:
                    break;
                default:
                    break;
            }
        }


        private void btnNumLock_Click(object sender, EventArgs e)
        {
            if (protectKeys)
                return;
            protectKeys = true;
            NativeMethods.SimulateKeyPress(NativeMethods.VK_NUMLOCK);
            protectKeys = false;
        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {

            if (lblDisplay.Text.Length > 0)
            {
                string strTmp = "";
                for (int i = 0; i < lblDisplay.Text.Length - 1; i++)
                {
                    strTmp += lblDisplay.Text[i];
                }
                lblDisplay.Text = strTmp;
            }
        }

        private void FrmCalculator_Enter(object sender, EventArgs e)
        {

        }

        private void FrmCalculator_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void FrmCalculator_Load(object sender, EventArgs e)
        {
            dblNum1 = 0;
            dblNum2 = 0;
            dblResult = 0;
            _operation = Calculator_Opertaions.none;
            ccn = Calculator_Current_Number.leftNumber;
            if (Control.IsKeyLocked(Keys.NumLock))
            {
                btnNumLock.BackColor = Color.Green;
                numlock = true;
            }
            btnEnter.Focus();
        }

        public FrmCalculator()
        {
            InitializeComponent();
        }
    }

    public static class NativeMethods
    {
        public const byte VK_NUMLOCK = 0x90;
        public const uint KEYEVENTF_EXTENDEDKEY = 1;
        public const int KEYEVENTF_KEYUP = 0x2;

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        public static void SimulateKeyPress(byte keyCode)
        {
            keybd_event(VK_NUMLOCK, 0x45, KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event(VK_NUMLOCK, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }
    }


}