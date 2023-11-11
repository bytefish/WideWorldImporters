# Using a FluentUI Data Grid with ASP.NET Core OData  #

[Blazor]: https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor
[Fluent UI Blazor]: https://www.fluentui-blazor.net/

This repository shows how to use Blazor, Fluent UI Blazor and OData to display data 
in the Fluent UI Data Grid. It uses the WideWorldImporters Backend to provide the 
data, see:

* [https://www.bytefish.de/blog/blazor_fluentui_and_odata.html](https://www.bytefish.de/blog/blazor_fluentui_and_odata.html)

The idea is to use an ASP.NET Core OData Backend and a Frontend using Blazor with FluentUI Components. We 
are going to its a DataGrid to display data. The final DataGrid is going to look like this:

<a href="https://raw.githubusercontent.com/bytefish/WideWorldImporters/main/Frontend/Blazor/Screenshots/Customer_Grid.jpg">
    <img src="https://raw.githubusercontent.com/bytefish/WideWorldImporters/main/Frontend/Blazor/Screenshots/Customer_Grid.jpg" alt="The Blazor Frontend with the FluentUI DataGrid" width="50%" />
</a>

And it's possible to provide filters for each column, for example a filter on text:

<a href="https://raw.githubusercontent.com/bytefish/WideWorldImporters/main/Frontend/Blazor/Screenshots/Customer_Grid_ColumnFilter_String.jpg">
    <img src="https://raw.githubusercontent.com/bytefish/WideWorldImporters/main/Frontend/Blazor/Screenshots/Customer_Grid_ColumnFilter_String.jpg" alt="FluentUI DataGrid with a String Filter" width="50%" />
</a>

The Razor Page uses the `BooleanFilter`, `DateFiler`, `StringFilter` and a `NumericFilter` to filter the 
dataset. You can also filter nested properties by using an OData syntax like 
`LastEditedByNavigation/PreferredName`:

```razor
@page "/Customers"
@using BlazorDataGridExample.Components
@using BlazorDataGridExample.Shared.Models;
@using BlazorDataGridExample.Shared.Extensions;
@using Microsoft.OData.Client;
@using WideWorldImportersService;

@inject WideWorldImportersService.Container Container

<PageTitle>Customers</PageTitle>

<h1>Customers</h1>

@if (CustomerProvider == null)
{
    <p><em>Loading...</em></p>
}
else
{
    <FluentDataGrid @ref="DataGrid" ItemsProvider="@CustomerProvider" Pagination="@Pagination" TGridItem=Customer>
        <PropertyColumn Title="Customer ID" Property="@(c => c!.CustomerId)" Sortable="true" Align=Align.Start>
            <ColumnOptions>
                <NumericFilter TItem="int" PropertyName="CustomerId" FilterState="FilterState"></NumericFilter>
            </ColumnOptions>
        </PropertyColumn>
        <PropertyColumn Title="Name" Property="@(c => c!.CustomerName)" Sortable="true" Align=Align.Start>
            <ColumnOptions>
                <StringFilter PropertyName="CustomerName" FilterState="FilterState"></StringFilter>
            </ColumnOptions>
        </PropertyColumn>
        <PropertyColumn Title="Account Opened" Property="@(c => c!.AccountOpenedDate)" Format="yyyy-MM-dd" Sortable="true" Align=Align.Start>
            <ColumnOptions>
                <DateFilter PropertyName="AccountOpenedDate" FilterState="FilterState"></DateFilter>
            </ColumnOptions>
        </PropertyColumn>
        <PropertyColumn Title="Is On Credit Hold" Property="@(c => c!.IsOnCreditHold)" Sortable="true" Align=Align.Start>
            <ColumnOptions>
                <BooleanFilter PropertyName="IsOnCreditHold" FilterState="FilterState"></BooleanFilter>
            </ColumnOptions>
        </PropertyColumn>
        <PropertyColumn Title="Last Edited By" Property="@(c => c!.LastEditedByNavigation!.PreferredName)" Sortable="true" Align=Align.Start>
            <ColumnOptions>
                <StringFilter PropertyName="LastEditedByNavigation/PreferredName" FilterState="FilterState"></StringFilter>
            </ColumnOptions>
        </PropertyColumn>
    </FluentDataGrid>

    <FluentPaginator State="@Pagination" />
}
```

This is an Open Source project, feel free to contribute!

## License ##

The code in this repository is licensed under MIT License.