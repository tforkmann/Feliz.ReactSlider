module Docs.View

open Feliz
open Router
open Elmish
open SharedView
open Feliz.DaisyUI
open Feliz.DaisyUI.Operators

type Msg =
    | UrlChanged of Page
    | SetTheme of string

type State = { Page: Page; Theme: string }

let init () =
    let nextPage = Router.currentUrl () |> Page.parseFromUrlSegments
    { Page = nextPage; Theme = "corporate" }, Cmd.navigatePage nextPage

let update (msg: Msg) (state: State) : State * Cmd<Msg> =
    match msg with
    | UrlChanged page -> { state with Page = page }, Cmd.none
    | SetTheme theme -> { state with Theme = theme }, Cmd.none

let private rightSide state dispatch (title: string) (docLink: string) elm =
    Daisy.drawerContent [
        Daisy.navbar [
            Daisy.navbarStart [
                Html.divClassed
                    "lg:hidden"
                    [ Daisy.button.label [
                          button.square
                          button.ghost
                          prop.htmlFor "main-menu"
                          prop.children [
                              Svg.svg [
                                  svg.viewBox (0, 0, 24, 24)
                                  svg.className "inline-block w-6 h-6 stroke-current"
                                  svg.children [
                                      Svg.path [
                                          svg.d "M4 6h16M4 12h16M4 18h16"
                                          svg.strokeWidth 2
                                      ]
                                  ]
                              ]
                          ]
                      ] ]
            ]
        ]

        Html.divClassed
            "px-5 py-5"
            [ Html.h2 [
                  color.textPrimary
                  ++ prop.className "my-6 text-5xl font-bold"
                  prop.text title
              ]
              elm ]
    ]

let private leftSide (p: Page) =

    let mi (t: string) (mp: Page) =
        Html.li [
            Html.a [
                if p = mp then menuItem.active
                prop.text t
                prop.href mp
                prop.onClick Router.goToUrl
            ]
        ]

    Daisy.drawerSide [
        Daisy.drawerOverlay [
            prop.htmlFor "main-menu"
        ]
        Html.aside [
            prop.className "flex flex-col border-r w-80 bg-base-100 text-base-content"
            prop.children [
                Html.divClassed
                    "inline-block text-3xl font-title px-5 py-5 font-bold"
                    [ Html.span [
                          color.textPrimary
                          prop.text "Feliz.ReactSlider"
                      ]
                      Html.a [
                          prop.href "https://www.nuget.org/packages/Feliz.ReactSlider"
                          prop.children [
                              Html.img [
                                  prop.src "https://img.shields.io/nuget/v/Feliz.ReactSlider.svg?style=flat-square"
                              ]
                          ]
                      ] ]
                Daisy.menu [
                    menu.md
                    prop.className "flex flex-col p-4 pt-0"
                    prop.children [
                        Daisy.menuTitle [ Html.span "Docs" ]
                        mi "Install" Install
                        mi "Use" Use
                        mi "Slider" Slider
                        ]
                ]
            ]
        ]
    ]

let private inLayout state dispatch (title: string) (docLink: string) (p: Page) (elm: ReactElement) =
    Html.div [
        prop.className "bg-base-100 text-base-content h-screen"
        theme.custom state.Theme
        prop.children [
            Daisy.drawer [
                prop.className "lg:drawer-open"
                prop.children [
                    Daisy.drawerToggle [
                        prop.id "main-menu"
                    ]
                    rightSide state dispatch title docLink elm
                    leftSide p
                ]
            ]
        ]
    ]


[<ReactComponent>]
let AppView (state: State) (dispatch: Msg -> unit) =

    let title, docLink, content =
        match state.Page with
        | Install -> "Installation", "/docs/install", Pages.Install.InstallView()
        | Use -> "How to use", "/docs/use", Pages.Use.UseView()
        | Slider -> "Slider", "/docs/slider", Pages.Slider.SliderView()
    React.router [
        router.hashMode
        router.onUrlChanged (
            Page.parseFromUrlSegments
            >> UrlChanged
            >> dispatch
        )
        router.children [
            content
            |> inLayout state dispatch title docLink state.Page
        ]
    ]
