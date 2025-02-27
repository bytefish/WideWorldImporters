﻿// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.FluentUI.AspNetCore.Components;
using SortDirectionEnum = WideWorldImporters.Shared.Models.SortDirectionEnum;
using FluentUiSortDirection = Microsoft.FluentUI.AspNetCore.Components.SortDirection;
using WideWorldImporters.Shared.Models;

namespace WideWorldImporters.Web.Client.Infrastructure
{
    /// <summary>
    /// Provides Converters for converting from Fluent UI to Model classes 
    /// and vice versa.
    /// </summary>
    public static class Converters
    {
        public static List<SortColumn> ConvertToSortColumns(IReadOnlyCollection<SortedProperty>? source)
        {
            if (source == null)
            {
                return new();
            }

            return source
                .Select(x => ConvertSortColumn(x))
                .ToList();
        }

        private static SortColumn ConvertSortColumn(SortedProperty source)
        {
            var sortDirection = ConvertSortDirection(source.Direction);

            return new SortColumn
            {
                PropertyName = source.PropertyName.Replace('.', '/'),
                SortDirection = sortDirection
            };
        }

        private static SortDirectionEnum ConvertSortDirection(FluentUiSortDirection source)
        {
            if (source == FluentUiSortDirection.Ascending)
            {
                return SortDirectionEnum.Ascending;
            }

            return SortDirectionEnum.Descending;
        }
    }
}
