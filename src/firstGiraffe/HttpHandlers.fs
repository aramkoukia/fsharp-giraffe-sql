namespace firstGiraffe

module HttpHandlers =

    open Microsoft.AspNetCore.Http
    open Giraffe
    open Domain

    let handleGetHello =
        fun (next : HttpFunc) (ctx : HttpContext) ->
            task {
                let response = {
                    Text = "Hello world, from Giraffe!"
                }
                return! json response next ctx
            }

    let handlePostBrands : HttpHandler =
        fun (next : HttpFunc) (ctx : HttpContext) ->
            task {
                let! brand = ctx.TryBindFormAsync<BrandDto>()
                return! json "" next ctx
                // let  userManager = ctx.GetService<UserManager<IdentityUser>>()
                //createBrand(brand) |> ignore

                //let response = {
                //    Text = "Brand Created!"
                //}
                //return! json response next ctx
            }

    let handlePostBrand : HttpHandler =
        fun (next : HttpFunc) (ctx : HttpContext) ->
            task {
                let! brand = ctx.TryBindFormAsync<Brand>()
                
                let response = {
                    Text = "Hello world, from Giraffe!"
                }

                return! json response next ctx
            }