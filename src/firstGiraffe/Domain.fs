module Domain

open System
open FSharp.Data.Sql

[<CLIMutable>]
type Message = {
        Text : string }

[<CLIMutable>]
type BrandDto = {
    Id: Guid
    Name: string }

let [<Literal>] ConnectionString = "Server=localhost;Database=hub;integrated security=true;"

type Sql = SqlDataProvider< 
              ConnectionString = ConnectionString,
              DatabaseVendor = Common.DatabaseProviderTypes.MSSQLSERVER,
              IndividualsAmount = 1000,
              UseOptionTypes = true >


let createBrand _brand = 
    let ctx = Sql.GetDataContext()
    ctx.Dbo.Brand.``Create(BrandId, CreatedByUserId, CreatedDate, EffectiveDate, IsSystemBrand, ThemeId, UserProfileId)``
    ctx.SubmitUpdates()

