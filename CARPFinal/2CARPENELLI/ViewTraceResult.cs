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
    public partial class ViewTraceResult : Form
    {
        private TraceResults traceResults;
        public ViewTraceResult(TraceResults traceResults)
        {
            InitializeComponent();
            this.traceResults = traceResults;
            textBox2.ScrollBars = ScrollBars.Vertical;
        }
        private void TraceResultStatements(object sender, EventArgs e)
        {
            textBox2.Text = "Trace Results: " + Environment.NewLine;
            foreach (string statement in traceResults.GetAllStatements())
            {
                textBox2.AppendText(statement + Environment.NewLine);
            }
        }

        private void btnTraceResults_Click(object sender, EventArgs e)
        {
            textBox2.Text = "Trace Results: " + Environment.NewLine;
            foreach (string statement in traceResults.GetAllStatements())
            {
                textBox2.AppendText(statement + Environment.NewLine);
            }
        }
    }
}
