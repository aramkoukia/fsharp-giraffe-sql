open FSharp.Data.Sql

let ctx = Sql.GetDataContext()

// To use dynamic runtime connectionString, you could use:
// let ctx = sql.GetDataContext connectionString2

// pick individual entities from the database 
let Brands = ctx.Main.Brands |> Seq.toArray

// directly enumerate an entity's relationships, 
// this creates and triggers the relevant query in the background
//let Brands = christina.``main.Orders by CustomerID`` |> Seq.toArray

// let mattisOrderDetails =
//     query { for c in ctx.Main.Customers do
//             // you can directly enumerate relationships with no join information
//             for o in c.``main.Orders by CustomerID`` do
//             // or you can explicitly join on the fields you choose
//             join od in ctx.Main.OrderDetails on (o.OrderId = od.OrderId)
//             //  the (!!) operator will perform an outer join on a relationship
//             for prod in (!!) od.``main.Products by ProductID`` do 
//             // nullable columns can be represented as option types; the following generates IS NOT NULL
//             where o.ShipCountry.IsSome                
//             // standard operators will work as expected; the following shows the like operator and IN operator
//             where (c.ContactName =% ("Matti%") && c.CompanyName |=| [|"Squirrelcomapny";"DaveCompant"|] )
//             sortBy o.ShipName
//             // arbitrarily complex projections are supported
//             select (c.ContactName,o.ShipAddress,o.ShipCountry,prod.ProductName,prod.UnitPrice) } 
//     |> Seq.toArray