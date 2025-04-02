module Index

open Elmish
open Feliz
open Feliz.ReactSlider

type Model = { Txt: string }

type Msg = UpdateTxt of string

let init () = { Txt = "" }, Cmd.none

let update msg (model: Model) =
    match msg with
    | UpdateTxt txt -> { model with Txt = txt }, Cmd.none

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

let view (model: Model) (dispatch: Msg -> unit) =
    Html.div [
        prop.style [ style.height 600; style.width 600; style.marginLeft 100 ]
        prop.children [
            Html.h1 "Hello from ReactSlider"
            ReactSlider()
        ]

    ]
