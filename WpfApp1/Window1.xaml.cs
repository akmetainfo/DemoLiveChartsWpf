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
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            this.DataContext = new GraphData();
        }
    }

    public class GraphData
    {
        public SeriesCollection SeriesCollection { set; get; }

        public GraphData()
        {
            this.LoadData();
        }

        private void LoadData()
        {
            const int reportId = 16;

            var data = LoadDataFromServer(reportId);

            this.SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<double>(data.Take(4)),
                },
                new LineSeries
                {
                    Values = new ChartValues<double>(data.Skip(4).Take(4)),
                },
            };
        }

        // Тут чтение данных из базы, какой-нибудь List<ResultItem>
        private List<double> LoadDataFromServer(int reportId)
        {
            return new List<double> { 1, 3, 5, 7, 8, 6, 2, 4 };
        }
    }
}