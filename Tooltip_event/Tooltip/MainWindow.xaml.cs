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
            gridcontrol.CellToolTipOpening += Gridcontrol_CellToolTipOpening;

            //Enable the show tooltip
            GridTooltipService.SetShowTooltips(gridcontrol, true);                       
        }
        
        private void Gridcontrol_CellToolTipOpening(object sender, GridCellToolTipOpeningEventArgs e)
        {
            gridcontrol.Model[1, 4].ToolTip = "Hello";
        }

        private void Gridcontrol_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            e.Style.CellValue = string.Format("{0},{1}", e.Cell.RowIndex, e.Cell.ColumnIndex);
            e.Style.ShowTooltip = true;

            //Hide tooltip for a disabled cell
            if (e.Cell.RowIndex == 1 && e.Cell.ColumnIndex == 1)
            {
                e.Style.Enabled = false;
                e.Style.ToolTip = " Grid (" + e.Cell.RowIndex + "," + e.Cell.ColumnIndex + ") ";
                e.Style.ShowTooltip = false;
            }
        }
    }
}
