module Docs.Pages.LineChart

open Feliz
open Feliz.Bulma
open Feliz.ReactSlider
open Docs.SharedView

[<ReactComponent>]
let ChartJSLineChart () =
    ChartJS.line [
        line.options [
            option.responsive true
            option.plugins [
                plugin.dataLabels [
                    dataLabels.display true
                    dataLabels.align Position.Bottom
                    dataLabels.borderRadius 3
                    dataLabels.color "red"
                    dataLabels.backgroundColor "green"
                    ]]
        ]
        line.data [
            lineData.labels [|
                "Red"
                "Blue"
                "Yellow"
                "Green"
                "Purple"
                "Orange"
            |]
            lineData.datasets [|
                lineData.dataset [
                    lineDataSet.label "My First Dataset"
                    lineDataSet.borderColor "rgb(53, 162, 235)"
                    lineDataSet.backgroundColor "rgba(53, 162, 235, 0.5)"
                    lineDataSet.data [|
                        "1"
                        "2"
                        "3"
                        "4"
                        "5"
                        "6"
                    |]
                ]
                lineData.dataset [
                    lineDataSet.label "My Second Dataset"
                    lineDataSet.borderColor "yellow"
                    lineDataSet.backgroundColor "rgba(53, 162, 235, 0.5)"
                    lineDataSet.data [|
                        "1"
                        "2"
                        "3"
                        "4"
                        "4"
                        "6"
                    |]
                ]
            |]
        ]
    ]

let ChartJSChart =
    Html.div [
        prop.style [ style.height 800 ]
        prop.children [
            ChartJSLineChart()
        ]
    ]


let code =
    """
    ChartJS.line [
        line.options [
            option.responsive true
            option.plugins[plugin.dataLabels [
                               dataLabels.display true
                               dataLabels.align Bottom
                               dataLabels.borderRadius 3
                               dataLabels.color "red"
                               dataLabels.backgroundColor "green"
                               ]]
        ]
        line.data [
            lineData.labels [|
                "Red"
                "Blue"
                "Yellow"
                "Green"
                "Purple"
                "Orange"
            |]
            lineData.datasets [|
                lineData.dataset [
                    lineDataSet.label "My First Dataset"
                    lineDataSet.borderColor "rgb(53, 162, 235)"
                    lineDataSet.backgroundColor "rgba(53, 162, 235, 0.5)"
                    lineDataSet.data [|
                        "1"
                        "2"
                        "3"
                        "4"
                        "5"
                        "6"
                    |]
                ]
                lineData.dataset [
                    lineDataSet.label "My Second Dataset"
                    lineDataSet.borderColor "yellow"
                    lineDataSet.backgroundColor "rgba(53, 162, 235, 0.5)"
                    lineDataSet.data [|
                        "1"
                        "2"
                        "3"
                        "4"
                        "4"
                        "6"
                    |]
                ]
            |]
        ]
    ]
    """

let title = Html.text "Line Chart"

[<ReactComponent>]
let LineChartView () =
    Html.div [
        Bulma.content [
            codedView title code ChartJSChart
        ]
        fixDocsView "LineChart" false
    ]
