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
            GridControl gridcontrol = new GridControl();
            
            gridcontrol.Width = 820;
            gridcontrol.Height = 470;

            gridcontrol.Model.RowCount = 20;
            gridcontrol.Model.ColumnCount = 10;
            gridcontrol.QueryCellInfo += Gridcontrol_QueryCellInfo;

            //Enable the show tooltip
            GridTooltipService.SetShowTooltips(gridcontrol, true);
            
            grid.Children.Add(gridcontrol);
        }
               
        private void Gridcontrol_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            e.Style.CellValue = string.Format("{0},{1}", e.Cell.RowIndex, e.Cell.ColumnIndex);
            e.Style.ShowTooltip = true;

            //Show tooltip for a specific index
            if (e.Cell.RowIndex == 1 && e.Cell.ColumnIndex == 1)
                e.Style.ToolTip = " Grid (" + e.Cell.RowIndex + "," + e.Cell.ColumnIndex + ") ";
            else
                e.Style.ToolTip = e.Style.CellValue;

            //Show tooltip for row.
            if (e.Cell.ColumnIndex > 0 && e.Cell.RowIndex == 5)
                e.Style.ToolTip = " Row " + "(" + e.Cell.RowIndex + "," + e.Cell.ColumnIndex + ") ";

            // Show tooltip for column.
            if (e.Cell.RowIndex > 0 && e.Cell.ColumnIndex == 4)
                e.Style.ToolTip = " Col " + "(" + e.Cell.RowIndex + "," + e.Cell.ColumnIndex + ") ";
        }
    }
}
