module Brands

open System
open FSharp.Data.Sql

type Brand = {
    Id: Guid
    Name: string
}


let [<Literal>] ResolutionPath = __SOURCE_DIRECTORY__ + @"..\..\files\sqlite" 
let [<Literal>] ConnectionString = "Data Source=" + __SOURCE_DIRECTORY__ + @"\northwindEF.db;Version=3"

// create a type alias with the connection string and database vendor settings
type Sql = SqlDataProvider< 
              ConnectionString = connectionString,
              DatabaseVendor = Common.DatabaseProviderTypes.SQLITE,
              ResolutionPath = resolutionPath,
              IndividualsAmount = 1000,
              UseOptionTypes = true >
let CreateBrand brand = {
    let ctx = Sql.GetDataContext()
    let brands = ctx.Main.Brands

    let row = brands.Create()
    row.BrandId <- brand.BrandId
    row.BrandName <- brand.BrandName

    ctx.SubmitUpdates()
}
