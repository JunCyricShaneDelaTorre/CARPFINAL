using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2CARPENELLI
{
    public partial class ViewBreakPoints : Form
    {
        //Breakpoints
        private List<int> breakpointList;
        public ViewBreakPoints()
        {
            InitializeComponent();
            breakpointList = new List<int>();
        }
        //Breakpoints Button
        private void Delete_Breakpoint(object sender, EventArgs e)
        {
            if (breakBox.SelectedItem != null)
            {
                breakpointList.Remove(breakBox.SelectedIndex);
                breakBox.Items.Remove(breakBox.SelectedItem.ToString());
            }
        }

        private void Add_Breakpoint(object sender, EventArgs e)
        {
            int.TryParse(breakLine.Text, out int result);
            if (!string.IsNullOrEmpty(breakLine.Text) && IsDigitsRegex(breakLine.Text) && result < 65536 && result > 0)
            {
                breakpointList.Add(result);
                breakBox.Items.Add("Address: " + breakLine.Text);
                breakLine.Clear();

            }
            else
            {
                breakLine.Clear();
                MessageBox.Show("Please enter a valid breakpoint.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public List<int> GetBreakPoints()
        {
            return breakpointList;
        }
        public bool IsDigitsRegex(string input)
        {
            Regex regex = new Regex(@"^\d+$");
            return regex.IsMatch(input);
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            int.TryParse(breakLine.Text, out int result);
            if (!string.IsNullOrEmpty(breakLine.Text) && IsDigitsRegex(breakLine.Text) && result < 65536 && result > 0)
            {
                breakpointList.Add(result);
                breakBox.Items.Add("Address: " + breakLine.Text);
                breakLine.Clear();

            }
            else
            {
                breakLine.Clear();
                MessageBox.Show("Please enter a valid breakpoint.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (breakBox.SelectedItem != null)
            {
                breakpointList.Remove(breakBox.SelectedIndex);
                breakBox.Items.Remove(breakBox.SelectedItem.ToString());
            }
        }
    }
}
