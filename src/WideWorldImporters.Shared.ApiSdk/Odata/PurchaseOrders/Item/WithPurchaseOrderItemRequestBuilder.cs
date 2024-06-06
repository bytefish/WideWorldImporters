// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
using WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.ODataErrors;
using WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService;
using WideWorldImporters.Shared.ApiSdk.Odata.PurchaseOrders.Item.ContactPerson;
using WideWorldImporters.Shared.ApiSdk.Odata.PurchaseOrders.Item.DeliveryMethod;
using WideWorldImporters.Shared.ApiSdk.Odata.PurchaseOrders.Item.LastEditedByNavigation;
using WideWorldImporters.Shared.ApiSdk.Odata.PurchaseOrders.Item.PurchaseOrderLines;
using WideWorldImporters.Shared.ApiSdk.Odata.PurchaseOrders.Item.StockItemTransactions;
using WideWorldImporters.Shared.ApiSdk.Odata.PurchaseOrders.Item.Supplier;
using WideWorldImporters.Shared.ApiSdk.Odata.PurchaseOrders.Item.SupplierTransactions;
namespace WideWorldImporters.Shared.ApiSdk.Odata.PurchaseOrders.Item {
    /// <summary>
    /// Provides operations to manage the collection of PurchaseOrder entities.
    /// </summary>
    public class WithPurchaseOrderItemRequestBuilder : BaseRequestBuilder 
    {
        /// <summary>Provides operations to manage the contactPerson property of the WideWorldImportersService.PurchaseOrder entity.</summary>
        public ContactPersonRequestBuilder ContactPerson
        {
            get => new ContactPersonRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the deliveryMethod property of the WideWorldImportersService.PurchaseOrder entity.</summary>
        public DeliveryMethodRequestBuilder DeliveryMethod
        {
            get => new DeliveryMethodRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the lastEditedByNavigation property of the WideWorldImportersService.PurchaseOrder entity.</summary>
        public LastEditedByNavigationRequestBuilder LastEditedByNavigation
        {
            get => new LastEditedByNavigationRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the purchaseOrderLines property of the WideWorldImportersService.PurchaseOrder entity.</summary>
        public PurchaseOrderLinesRequestBuilder PurchaseOrderLines
        {
            get => new PurchaseOrderLinesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the stockItemTransactions property of the WideWorldImportersService.PurchaseOrder entity.</summary>
        public StockItemTransactionsRequestBuilder StockItemTransactions
        {
            get => new StockItemTransactionsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the supplier property of the WideWorldImportersService.PurchaseOrder entity.</summary>
        public SupplierRequestBuilder Supplier
        {
            get => new SupplierRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the supplierTransactions property of the WideWorldImportersService.PurchaseOrder entity.</summary>
        public SupplierTransactionsRequestBuilder SupplierTransactions
        {
            get => new SupplierTransactionsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="WithPurchaseOrderItemRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithPurchaseOrderItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/odata/PurchaseOrders/{purchaseOrderId}{?%24expand,%24select}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="WithPurchaseOrderItemRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithPurchaseOrderItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/odata/PurchaseOrders/{purchaseOrderId}{?%24expand,%24select}", rawUrl)
        {
        }
        /// <summary>
        /// Delete entity from PurchaseOrders
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="ODataError">When receiving a 4XX or 5XX status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task DeleteAsync(Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task DeleteAsync(Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToDeleteRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                {"XXX", ODataError.CreateFromDiscriminatorValue},
            };
            await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Get entity from PurchaseOrders by key
        /// </summary>
        /// <returns>A <see cref="WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.PurchaseOrder"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="ODataError">When receiving a 4XX or 5XX status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.PurchaseOrder?> GetAsync(Action<RequestConfiguration<WithPurchaseOrderItemRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.PurchaseOrder> GetAsync(Action<RequestConfiguration<WithPurchaseOrderItemRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                {"XXX", ODataError.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.PurchaseOrder>(requestInfo, WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.PurchaseOrder.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Update entity in PurchaseOrders
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="ODataError">When receiving a 4XX or 5XX status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task PatchAsync(WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.PurchaseOrder body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task PatchAsync(WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.PurchaseOrder body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPatchRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                {"XXX", ODataError.CreateFromDiscriminatorValue},
            };
            await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Delete entity from PurchaseOrders
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToDeleteRequestInformation(Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToDeleteRequestInformation(Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.DELETE, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Get entity from PurchaseOrders by key
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<WithPurchaseOrderItemRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<WithPurchaseOrderItemRequestBuilderGetQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Update entity in PurchaseOrders
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPatchRequestInformation(WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.PurchaseOrder body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToPatchRequestInformation(WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.PurchaseOrder body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation(Method.PATCH, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="WithPurchaseOrderItemRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public WithPurchaseOrderItemRequestBuilder WithUrl(string rawUrl)
        {
            return new WithPurchaseOrderItemRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        public class WithPurchaseOrderItemRequestBuilderDeleteRequestConfiguration : RequestConfiguration<DefaultQueryParameters> 
        {
        }
        /// <summary>
        /// Get entity from PurchaseOrders by key
        /// </summary>
        public class WithPurchaseOrderItemRequestBuilderGetQueryParameters 
        {
            /// <summary>Expand related entities</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("%24expand")]
            public string[]? Expand { get; set; }
#nullable restore
#else
            [QueryParameter("%24expand")]
            public string[] Expand { get; set; }
#endif
            /// <summary>Select properties to be returned</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("%24select")]
            public string[]? Select { get; set; }
#nullable restore
#else
            [QueryParameter("%24select")]
            public string[] Select { get; set; }
#endif
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        public class WithPurchaseOrderItemRequestBuilderGetRequestConfiguration : RequestConfiguration<WithPurchaseOrderItemRequestBuilderGetQueryParameters> 
        {
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        public class WithPurchaseOrderItemRequestBuilderPatchRequestConfiguration : RequestConfiguration<DefaultQueryParameters> 
        {
        }
    }
}
