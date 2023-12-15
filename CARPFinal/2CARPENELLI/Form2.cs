using RSCSS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2CARPENELLI
{
    public partial class Form2 : Form
    {
        private Assembler assembler;
        private CPU cpu;
        private Memory memory;
        private TraceResults results;
        private List<int> breakpoints;
        public Form2()
        {
            InitializeComponent();
            breakpoints = new List<int>();
            assembler = new Assembler();
            memory = new Memory();
            results = new TraceResults();
            cpu = new CPU(results, status_txt, rtl_txt, datamove_txt);
        }

        private Form activeForm2 = null;
        private void openChildForm2(Form childForm2)
        {
            if (activeForm2 != null)
                activeForm2.Close();
            activeForm2 = childForm2;
            childForm2.TopLevel = false;
            childForm2.FormBorderStyle = FormBorderStyle.None;
            childForm2.Dock = DockStyle.Fill;
            panelShowBody.Controls.Add(childForm2);
            panelShowBody.Tag = childForm2;
            childForm2.BringToFront();
            childForm2.Show();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelShowBody.Controls.Add(childForm);
            panelShowBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void View_System(object sender, EventArgs e)
        {
            ViewSystem viewSystem = new ViewSystem(memoryLoc_txt, cpu, memory, breakpoints);
            viewSystem.Show();

            /*openChildForm(new ViewSystem(memoryLoc_txt, cpu, memory, breakpoints));*/
        }

        private void View_MemoryAndIO(object sender, EventArgs e)
        {
            /*ViewMemoryAndIO memoryIO = new ViewMemoryAndIO(memory);
            memoryIO.Show();*/
            openChildForm(new ViewMemoryAndIO(memory));
        }

        private void View_Breakpoints(object sender, EventArgs e)
        {
            /* ViewBreakPoints breakpoint = new ViewBreakPoints();
             breakpoint.Show();
             breakpoints = breakpoint.GetBreakPoints();*/
            openChildForm(new ViewBreakPoints());
        }

        private void View_TraceResults(object sender, EventArgs e)
        {
            /*ViewTraceResult trace = new ViewTraceResult(results);
            trace.Show();*/
            openChildForm(new ViewTraceResult(results));
        }

        private void btnAssemble_Click(object sender, EventArgs e)
        {
            string text = instructionCode.Text;
            int location = int.Parse(memLocation.Text);
            AssemblyResults results = assembler.Assemble(text, location, cpu, memory);
            AssemblyError[] errors = results.GetErrors();
            int i = 0;
            while (i < errors.Length)
            {
                MessageBox.Show(errors[i].GetString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                i++;
            }
            if (errors.Length <= 0)
            {
                MessageBox.Show("Assembly Successful.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
