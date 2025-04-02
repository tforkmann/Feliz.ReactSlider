namespace Feliz.ReactSlider

open Fable.Core.JsInterop
open Fable.Core
open Feliz

type Event = Browser.Types.Event

// The !! below is used to "unsafely" expose a prop into an ISliderProp.
[<Erase>]
type ReactSlider =
    /// Creates a new Slider component.

    static member inline slider(props: ISliderProp seq) =
        Interop.reactApi.createElement (Interop.slider, createObj !!props)
    static member inline children(children: ReactElement list) =
        unbox<ISliderProp> (prop.children children)

[<Erase>]
type slider =
    static member inline min (value: int) =
        Interop.mkSliderProp "min" value
    static member inline max (value: int) =
        Interop.mkSliderProp "max" value

    static member inline step (value: int) =
        Interop.mkSliderProp "step" value
    static member inline stepNull  =
     Interop.mkSliderProp "step" (JsInterop.isNullOrUndefined)
    static member inline value (value: int) =
        Interop.mkSliderProp "value" value
    static member inline defaultValue (value: int) =
        Interop.mkSliderProp "defaultValue" value
    static member inline dots (value: bool) =
        Interop.mkSliderProp "dots" value
    static member inline disabled (value: bool) =
        Interop.mkSliderProp "disabled" value
    static member inline marks (marks: (int * ReactElement) seq) =
        Interop.mkSliderProp "marks" marks
    static member inline marksWithStyle (values: (int * (string * ReactElement)) list) =
        let marksObj =
            createObj [
                for k, (color, label) in values ->
                    k.ToString(), createObj [
                        "style", createObj [ "color", color ]
                        "label", label
                    ]
            ]
        Interop.mkSliderProp "marks" marksObj
