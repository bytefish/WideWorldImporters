# WideWorldImporters #

"I just want to show some data in a table and filter it. Why is all this so, so complicated?", 
said everyone trying to quickly expose a dataset with an Angular application. It doesn't have 
to be this way.

In this repository I will show you how to use ASP.NET Core OData and EF Core to quickly build Backends 
and how to use Angular, Blazor or WPF to display, filter and paginate datasets.

[An ASP.NET Core OData Example using the Wide WorldImporters database and Entity Framework Core]: https://www.bytefish.de/blog/aspnet_core_odata_example.html
[Building an Angular Frontend for an ASP.NET Core OData Application]: https://www.bytefish.de/blog/aspnet_core_odata_frontend.html
[Extending a Fluent UI Blazor DataGrid for Filtering and Sorting with OData]: https://www.bytefish.de/blog/blazor_fluentui_and_odata.html

* ASP.NET Core Backend
    * [An ASP.NET Core OData Example using the Wide WorldImporters database and Entity Framework Core]
* Angular Frontend
    * [Building an Angular Frontend for an ASP.NET Core OData Application]
* Blazor Frontend
    * [Extending a Fluent UI Blazor DataGrid for Filtering and Sorting with OData]

## Repository Structure ##

* `Backend`
    * Contains the Backend Solution, that you can start with your .NET Runtime.
* `Frontend`
    * `Angular`
        * Contains the Angular 15 Frontend, that uses Clarity Design for its Components.
    * `Blazor`
        * Contains the Blazor WASM Frontend, that uses Fluent UI Blazor for its Components.
    * `WPF`
        * Contains a WPF application, that shows how to display and edit data in a `DataGrid`.
        
## About the Project ##

We will build a Backend and Frontend for the "Wide World Importers" database, which is a Microsoft SQL Server 
sample database for a fictional company:

* https://docs.microsoft.com/en-us/sql/samples/wide-world-importers-what-is?view=sql-server-ver15

The Microsoft documentation describes the fictionous "Wide World Importers" as ...

> [...] a wholesale novelty goods importer and distributor operating from the San Francisco bay area.
> 
> As a wholesaler, WWI's customers are mostly companies who resell to individuals. WWI sells to retail customers 
> across the United States including specialty stores, supermarkets, computing stores, tourist attraction shops, 
> and some individuals. WWI also sells to other wholesalers via a network of agents who promote the products on 
> WWI's behalf. While all of WWI's customers are currently based in the United States, the company is intending to 
> push for expansion into other countries.
>
> WWI buys goods from suppliers including novelty and toy manufacturers, and other novelty wholesalers. They stock 
> the goods in their WWI warehouse and reorder from suppliers as needed to fulfil customer orders. They also purchase 
> large volumes of packaging materials, and sell these in smaller quantities as a convenience for the customers.
>
> Recently WWI started to sell a variety of edible novelties such as chilli chocolates. The company previously did 
> not have to handle chilled items. Now, to meet food handling requirements, they must monitor the temperature in their 
> chiller room and any of their trucks that have chiller sections.

I think it's a perfect non-trivial database to work with!

We are building a Backend, that scaffolds the WWI database and exposes the data with Microsoft ASP.NET Core OData 8. We will 
learn how to extend Microsoft ASP.NET Core OData 8 for spatial types, see how to generate the OData endpoints using T4 Text 
Templates and provide OpenAPI 3.0 documents for Frontend code generation goodies.