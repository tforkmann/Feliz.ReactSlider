# Feliz Binding for [RC-Slider](https://github.com/react-component/slider)

[![Feliz.ReactSlider on Nuget](https://buildstats.info/nuget/Feliz.ReactSlider)](https://www.nuget.org/packages/Feliz.ReactSlider/)
[![Docs](https://github.com/tforkmann/Feliz.ReactSlider/actions/workflows/Docs.yml/badge.svg)](https://github.com/tforkmann/Feliz.ReactSlider/actions/workflows/Docs.yml)

## Installation
Install the nuget package
```
dotnet paket add Feliz.ReactSlider
```

and install the npm package

```
npm install --save rc-slider
```

or use Femto:
```
femto install Feliz.ReactSlider
```

## Start test app

- Start your test app by cloning this repository and then execute:
```
dotnet run
```

## Example ReactSlider

```fs
Here is an example ReactSlider
```fs
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

```

You can find more examples [here](https://tforkmann.github.io/Feliz.ReactSlider/)
