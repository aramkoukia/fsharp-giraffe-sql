module Domain

open System
//open FSharp.Data.SqlClient
//open FSharp.Data

[<CLIMutable>]
type Message = {
        Text : string }

[<CLIMutable>]
type BrandDto = {
    Id: string
    Name: string }

[<CLIMutable>]
type Brand = {
    Test: string }

let [<Literal>] ConnectionString = "Server=localhost;Database=hub;integrated security=true;"


let createBrand brand =
    brand
    //do
    //use cmd = new SqlCommandProvider<"
    //INSERT INTO Brand (BrandId, BrandName)
    //Values(@brandId, @brandName )" 
    //, ConnectionString>(ConnectionString)

    //cmd.Execute(brandId = brand.BrandId, brandName = brand.BrandName)