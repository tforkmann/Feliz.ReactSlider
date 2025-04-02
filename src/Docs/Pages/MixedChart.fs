module Docs.Pages.MixedChart

open Feliz
open Feliz.Bulma
open Feliz.ReactSlider
open Docs.SharedView

[<ReactComponent>]
let ChartJSMixedChart () =
    ChartJS.bar [
        bar.options [
            option.responsive true
            option.scales [
                scale.xWithAxes [ axes.stacked true ]
                scale.yWithAxes [ axes.stacked true ]
            ]
            option.plugins [
                plugin.legend [ legend.position Position.Top ]
                plugin.title [
                    title.display true
                    title.text "Chart.js Bar Chart"
                ]
                plugin.dataLabels [
                    dataLabels.display true
                    dataLabels.align Position.Bottom
                    dataLabels.borderRadius 3
                    dataLabels.color "red"
                    dataLabels.backgroundColor "green"
                    ]
            ]
        ]
        bar.data [
            barData.labels [|
                "January"
                "Feburary"
            |]
            barData.datasets [|
                barData.dataset [
                    barDataSet.label "My First Dataset"
                    barDataSet.borderColor "blue"
                    barDataSet.backgroundColor "rgba(53, 162, 235, 0.5)"
                    barDataSet.borderSkipped false
                    barDataSet.borderWidth 2
                    barDataSet.borderRadius 50
                    barDataSet.data [| "1"; "2" |]
                ]
                barData.dataset [
                    barDataSet.label "My Second Dataset"
                    barDataSet.mixedType "line"
                    barDataSet.borderColor "green"
                    barDataSet.backgroundColor "rgba(53, 162, 235, 0.5)"
                    barDataSet.borderSkipped false
                    barDataSet.borderWidth 2
                    barDataSet.borderRadius 50
                    barDataSet.data [| "1"; "2" |]
                ]
            |]
        ]
    ]

let ChartJSChart =
    Html.div [
        prop.style [ style.height 800 ]
        prop.children [
            ChartJSMixedChart()
        ]
    ]


let code =
    """
    ChartJS.bar [
        bar.options [
            option.responsive true
            option.scales [
                scale.x [ axes.stacked true ]
                scale.y [ axes.stacked true ]
            ]
            option.plugins [
                plugin.legend [ legend.position Top ]
                plugin.title [
                    title.display true
                    title.text "Chart.js Bar Chart"
                ]
                plugin.dataLabels [
                    dataLabels.display true
                    dataLabels.align Bottom
                    dataLabels.borderRadius 3
                    dataLabels.color "red"
                    dataLabels.backgroundColor "green"
                    ]
            ]
        ]
        bar.data [
            barData.labels [|
                "January"
                "Feburary"
            |]
            barData.datasets [|
                barData.dataset [
                    barDataSet.label "My First Dataset"
                    barDataSet.borderColor "blue"
                    barDataSet.backgroundColor "rgba(53, 162, 235, 0.5)"
                    barDataSet.borderSkipped false
                    barDataSet.borderWidth 2
                    barDataSet.borderRadius 50
                    barDataSet.data [| "1"; "2" |]
                ]
                barData.dataset [
                    barDataSet.label "My Second Dataset"
                    barDataSet.mixedType "line"
                    barDataSet.borderColor "green"
                    barDataSet.backgroundColor "rgba(53, 162, 235, 0.5)"
                    barDataSet.borderSkipped false
                    barDataSet.borderWidth 2
                    barDataSet.borderRadius 50
                    barDataSet.data [| "1"; "2" |]
                ]
            |]
        ]
    ]
    """

let title = Html.text "Mixed Chart"


[<ReactComponent>]
let MixedChartView () =
    Html.div [
        Bulma.content [
            codedView title code ChartJSChart
        ]
        fixDocsView "MixedChart" false
    ]
