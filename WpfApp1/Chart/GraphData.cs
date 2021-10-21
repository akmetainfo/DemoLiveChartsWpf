using System.Collections.Generic;
using System.Linq;
using LiveCharts;
using LiveCharts.Wpf;

namespace WpfApp1.Chart
{
    public class GraphData
    {
        public SeriesCollection SeriesCollection => this.LoadData();

        private SeriesCollection LoadData()
        {
            const int reportId = 16;

            var data = this.LoadDataFromServer(reportId);

            return new SeriesCollection
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