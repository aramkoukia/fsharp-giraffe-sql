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

    let postBrandHandler : HttpHandler =
        fun (next : HttpFunc) (ctx : HttpContext) ->
            task {
                let! brand       = ctx.BindFormAsync<BrandDto>()
                // let  userManager = ctx.GetService<UserManager<IdentityUser>>()
                let! result      = createBrandAsync(brand)

                match result.Succeeded with
                | false -> return! showErrors result.Errors next ctx
                | true  ->
                    let signInManager = ctx.GetService<SignInManager<IdentityUser>>()
                    do! signInManager.SignInAsync(user, true)
                    return! redirectTo false "/user" next ctx
            }