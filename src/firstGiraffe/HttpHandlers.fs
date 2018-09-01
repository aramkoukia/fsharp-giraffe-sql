namespace firstGiraffe

module HttpHandlers =

    open Microsoft.AspNetCore.Http
    open Giraffe
    open firstGiraffe.Models

    let handleGetHello =
        fun (next : HttpFunc) (ctx : HttpContext) ->
            task {
                let response = {
                    Text = "Hello world, from Giraffe!"
                }
                return! json response next ctx
            }

    let handleGetBrands =
        fun (next : HttpFunc) (ctx : HttpContext) ->
            task {
                return! json getBrands
            }

    fun (next : HttpFunc) (ctx : HttpContext) ->
        task {
            let userManager = ctx.GetService<UserManager<IdentityUser>>()
            let! user = userManager.GetUserAsync ctx.User
            return! (user |> userPage |> htmlView) next ctx
        }        

    let getBrands = {
        Brand
    }