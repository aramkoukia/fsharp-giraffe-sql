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

    let handlePostBrand : HttpHandler =
        fun (next : HttpFunc) (ctx : HttpContext) ->
            task {
                let! brand       = ctx.BindFormAsync<BrandDto>()
                // let  userManager = ctx.GetService<UserManager<IdentityUser>>()
                createBrand(brand)

                return! json brand next ctx
            }