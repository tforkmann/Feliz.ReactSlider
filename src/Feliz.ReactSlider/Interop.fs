namespace Feliz.ReactSlider

open Fable.Core
open Fable.Core.JsInterop

[<Erase; RequireQualifiedAccess>]
module Interop =
    importSideEffects "rc-slider/assets/index.css"
    let slider: obj = importDefault "rc-slider"

    // let range: obj = import "Range" "rc-slider"

    let inline mkSliderProp (key: string) (value: obj) : ISliderProp = unbox (key, value)
