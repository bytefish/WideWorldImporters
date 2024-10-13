# WideWorldImporters #

"I just want to show some data in a table and filter it. Why is all this so, so complicated?", 
said everyone trying to quickly expose a dataset with an Angular application. It doesn't have 
to be this way.

In this repository I will show you how to use ASP.NET Core OData and EF Core to quickly build Backends 
and how to use Angular, Blazor and WPF to display, filter and paginate datasets. 

## About the Project ##

We will build a Backend and Frontends for the "Wide World Importers" database, which is a Microsoft SQL Server 
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

## Getting Started ##

Create a set of Development Certificates:

```
dotnet dev-certs https --clean
dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p SuperStrongPassword --trust
```

Getting started is as simple as cloning this repository and running the following command:

```
docker compose --profile dev up
```

You can then navigate to https://localhost:5001 and enjoy the Blazor application.

## Related Articles ##

[An ASP.NET Core OData Example using the Wide WorldImporters database and Entity Framework Core]: https://www.bytefish.de/blog/aspnet_core_odata_example.html
[Building an Angular Frontend for an ASP.NET Core OData Application]: https://www.bytefish.de/blog/aspnet_core_odata_frontend.html
[Extending a Fluent UI Blazor DataGrid for Filtering and Sorting with OData]: https://www.bytefish.de/blog/blazor_fluentui_and_odata.html

Various articles have been written explaining the implementation and the ideas behind. You can find the articles 
on my website for the various components:

* ASP.NET Core Backend
    * [An ASP.NET Core OData Example using the Wide WorldImporters database and Entity Framework Core]
* Angular Frontend
    * [Building an Angular Frontend for an ASP.NET Core OData Application]
* Blazor Frontend
    * [Extending a Fluent UI Blazor DataGrid for Filtering and Sorting with OData]

