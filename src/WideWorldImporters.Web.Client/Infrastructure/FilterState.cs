﻿// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Concurrent;
using WideWorldImporters.Shared.Infrastructure;
using WideWorldImporters.Web.Client.Shared.Infrastructure;

namespace WideWorldImporters.Shared.Models
{
    /// <summary>
    /// Holds state to represent filters in a <see cref="FluentDataGrid{TGridItem}"/>.
    /// </summary>
    public class FilterState
    {
        /// <summary>
        /// Read-Only View of Column Filters.
        /// </summary>
        public IReadOnlyDictionary<string, FilterDescriptor> Filters => _filters;

        /// <summary>
        /// Column Filters.
        /// </summary>
        private readonly ConcurrentDictionary<string, FilterDescriptor> _filters = new();

        /// <summary>
        /// Invoked, when the list of filters change.
        /// </summary>
        public EventCallbackSubscribable<FilterState> CurrentFiltersChanged { get; } = new();

        /// <summary>
        /// Applies a Filter.
        /// </summary>
        /// <param name="filter"></param>
        public Task AddFilterAsync(FilterDescriptor filter)
        {
            _filters[filter.PropertyName] = filter;

            return CurrentFiltersChanged.InvokeCallbacksAsync(this);
        }

        /// <summary>
        /// Removes a Filter.
        /// </summary>
        /// <param name="propertyName"></param>
        public Task RemoveFilterAsync(string propertyName)
        {
            _filters.Remove(propertyName, out var _);

            return CurrentFiltersChanged.InvokeCallbacksAsync(this);
        }
    }
}