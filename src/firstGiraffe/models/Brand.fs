module Brands

open System
open FSharp.Data.Sql

type Brand = {
    Id: Guid
    Name: string
}

let [<Literal>] ConnectionString = "Server=localhost;Database=hub;integrated security=true;"

type Sql = SqlDataProvider< 
              ConnectionString = ConnectionString,
              DatabaseVendor = Common.DatabaseProviderTypes.MSSQLSERVER,
              IndividualsAmount = 1000,
              UseOptionTypes = true >


    let CreateBrand brand = {
        let ctx = Sql.GetDataContext()
        ctx.Dbo.Brand.Create(brand)

        ctx.SubmitUpdates()
}
