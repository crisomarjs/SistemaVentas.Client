using ChartJs.Blazor;
using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.BarChart.Axes;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Util;
using Microsoft.AspNetCore.Components;
using SistemaVentas.Client.DTOs;
using SistemaVentas.Client.Services;

namespace SistemaVentas.Client.Pages
{
    public partial class DashBoard
    {
        DashBoardDTO dashboard = new DashBoardDTO();

        private BarConfig barconfig;
        private Chart _chart = null!;

        //private PieConfig _config;

        protected override async Task OnInitializedAsync()
        {

            barconfig = new BarConfig
            {
                Options = new BarOptions
                {

                    MaintainAspectRatio = false,
                    Responsive = true,
                    Title = new OptionsTitle
                    {
                        Display = true
                    },
                    Scales = new BarScales
                    {
                        YAxes = new List<CartesianAxis>
                    {
                        new BarLinearCartesianAxis
                        {
                            Stacked = true,
                            MinBarLength = 0
                        }
                    }
                    }
                }
            };

            foreach (string lb in new[] { "temp" })
                barconfig.Data.Labels.Add(lb);

            IDataset<int> dataSet = new BarDataset<int>(new[] { 1 })
            {
                BackgroundColor = ColorUtil.ColorHexString(54, 162, 235),
                BorderColor = ColorUtil.ColorHexString(54, 162, 235),
                BorderWidth = 1
            };

            barconfig.Data.Datasets.Add(dataSet);


            var response = await _dashboardServicio.Resumen();
            if (response.status)
            {
                dashboard = (DashBoardDTO)response.value!;
                var labels = dashboard.VentasUltimaSemana.Select(v => v.Fecha).ToArray();
                var values = dashboard.VentasUltimaSemana.Select(v => v.Total).ToArray();
                ConfigureChart(labels, values);
            }

        }

        private void ConfigureChart(string[] labels, int[] values)
        {
            barconfig.Data.Labels.Clear();

            barconfig.Data.Datasets.Clear();

            foreach (string lb in labels)
                barconfig.Data.Labels.Add(lb);

            IDataset<int> dataSet = new BarDataset<int>(values)
            {
                Label = "Numero de ventas por día",
                BackgroundColor = ColorUtil.ColorHexString(54, 162, 235),
                BorderColor = ColorUtil.ColorHexString(54, 162, 235),
                BorderWidth = 1
            };
            barconfig.Data.Datasets.Add(dataSet);

            _chart.Update();
        }
    }
}
