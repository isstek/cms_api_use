using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMS_interaction
{
    public partial class InfoPreviewForm : Form
    {
        public InfoPreviewForm()
        {
            InitializeComponent();
        }

        public void AddInfo(DataGridViewRow[] rows)
        {
            dataTable.Rows.AddRange(rows);
        }

        public void AddColumns(string[,] columns)
        {
            dataTable.Rows.Clear();
            dataTable.Columns.Clear();
            for (int i = 0; i < columns.GetLength(0); ++i)
            {
                int j = dataTable.Columns.Add(columns[i, 0], columns[i, 1]);
                dataTable.Columns[j].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataTable.Columns[j].Frozen = true;
                dataTable.Columns[j].ReadOnly = true;
            }
        }
    }
}
