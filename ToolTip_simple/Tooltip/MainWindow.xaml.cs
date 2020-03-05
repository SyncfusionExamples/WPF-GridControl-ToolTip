using Microsoft.Win32;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tooltip
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            gridcontrol.Width = 820;
            gridcontrol.Height = 470;
            gridcontrol.Model.RowCount = 20;
            gridcontrol.Model.ColumnCount = 10;
            gridcontrol.QueryCellInfo += Gridcontrol_QueryCellInfo;

            //Enable the show tooltip
            GridTooltipService.SetShowTooltips(gridcontrol, true);

            //Set tooltip for specific cell
            gridcontrol.Model[1, 1].ToolTip = " Grid (" + gridcontrol.Model[1, 1].CellValue + ") ";
            gridcontrol.Model[1, 1].ShowTooltip = true;
            gridcontrol.Model[1, 1].Enabled = false;

            //Set tooltip for specific row
            gridcontrol.Model.RowStyles[1].ToolTip = " First row ";
            gridcontrol.Model.RowStyles[1].ShowTooltip = true;

            //Set tooltip for specific column
            gridcontrol.Model.ColStyles[1].ToolTip = " First column ";
            gridcontrol.Model.ColStyles[1].ShowTooltip = true;
        }

        private void Gridcontrol_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            e.Style.CellValue = string.Format("{0},{1}", e.Cell.RowIndex, e.Cell.ColumnIndex);           
        }
    }
}
