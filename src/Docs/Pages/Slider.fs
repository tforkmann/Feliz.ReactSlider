module Docs.Pages.Slider

open Feliz
open Feliz.Bulma
open Feliz.ReactSlider
open Docs.SharedView
[<ReactComponent>]
let ReactSlider () =
    ReactSlider.slider [
        slider.min 20
        slider.defaultValue 20
        slider.stepNull
        slider.marksWithStyle [
            20, ("red", Html.text "20")
            40, ("blue", Html.text "40")
            100, ("green", Html.text "100")
        ]
    ]


let Slider =
    Html.div [
        prop.style [ style.height 800 ]
        prop.children [
            ReactSlider()
        ]
    ]

let code =
    """
    ReactSlider.slider [
        slider.min 20
        slider.defaultValue 20
        slider.stepNull
        slider.marksWithStyle [
            20, ("red", Html.text "20")
            40, ("blue", Html.text "40")
            100, ("green", Html.text "100")
        ]
    ]
    """

let title = Html.text "Slider"

[<ReactComponent>]
let SliderView () =
    Html.div [
        Bulma.content [
            codedView title code Slider
        ]
        fixDocsView "Slider" false
    ]
