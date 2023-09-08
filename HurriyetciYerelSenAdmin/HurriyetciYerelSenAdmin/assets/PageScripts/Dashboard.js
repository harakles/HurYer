(function () {
    let cardColor, labelColor, headingColor, borderColor, legendColor;

    if (isDarkStyle) {
        cardColor = config.colors_dark.cardColor;
        labelColor = config.colors_dark.textMuted;
        legendColor = config.colors_dark.bodyColor;
        headingColor = config.colors_dark.headingColor;
        borderColor = config.colors_dark.borderColor;
    } else {
        cardColor = config.colors.cardColor;
        labelColor = config.colors.textMuted;
        legendColor = config.colors.bodyColor;
        headingColor = config.colors.headingColor;
        borderColor = config.colors.borderColor;
    }

    // Donut Chart Colors
    const chartColors = {
        donut: {
            series1: config.colors.primary,
            series2: '#28c76fb3',
            series3: '#28c76f80',
            series4: config.colors_label.danger
        }
    };

    const generatedLeadsChartEl = document.querySelector('#generatedLeadsChart'),
        generatedLeadsChartConfig = {
            chart: {
                height: 200,
                width: 200,
                parentHeightOffset: 0,
                type: 'donut'
            },
            labels: ['Onaylandı', 'Beklemede', 'Reddedildi'],
            series: [oran1, oran2, oran3],
            colors: [
                chartColors.donut.series1,
                chartColors.donut.series2,
                chartColors.donut.series4,
            ],
            stroke: {
                width: 0
            },
            dataLabels: {
                enabled: true,
                formatter: function (val, opt) {
                    return parseInt(val) + '%';
                }
            },
            legend: {
                show: true  
            },
            tooltip: {
                theme: false
            },
            grid: {
                padding: {
                    top: 15,
                    right: -20,
                    left: 0
                }
            },
            states: {
                hover: {
                    filter: {
                        type: 'none'
                    }
                }
            },
            plotOptions: {
                pie: {
                    donut: {
                        size: '70%',
                        labels: {
                            show: true,
                            value: {
                                fontSize: '1.375rem',
                                fontFamily: 'Public Sans',
                                color: headingColor,
                                fontWeight: 600,
                                offsetY: -15,
                                formatter: function (val) {
                                    return parseInt(val) + '%';
                                }
                            },
                            name: {
                                offsetY: 20,
                                fontFamily: 'Public Sans'
                            },
                        }
                    }
                }
            },
            responsive: [
                {
                    breakpoint: 1025,
                    options: {
                        chart: {
                            height: 185,
                            width: 185
                        }
                    }
                },
                {
                    breakpoint: 769,
                    options: {
                        chart: {
                            height: 178
                        }
                    }
                },
                {
                    breakpoint: 426,
                    options: {
                        chart: {
                            height: 147
                        }
                    }
                }
            ]
        };
    if (typeof generatedLeadsChartEl !== undefined && generatedLeadsChartEl !== null) {
        const generatedLeadsChart = new ApexCharts(generatedLeadsChartEl, generatedLeadsChartConfig);
        generatedLeadsChart.render();
    }
})();