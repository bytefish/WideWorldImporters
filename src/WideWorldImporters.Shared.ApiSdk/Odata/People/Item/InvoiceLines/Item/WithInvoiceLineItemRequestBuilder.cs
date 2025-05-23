// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
using WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.ODataErrors;
using WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService;
namespace WideWorldImporters.Shared.ApiSdk.Odata.People.Item.InvoiceLines.Item
{
    /// <summary>
    /// Provides operations to manage the invoiceLines property of the WideWorldImportersService.Person entity.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class WithInvoiceLineItemRequestBuilder : BaseRequestBuilder
    {
        /// <summary>
        /// Instantiates a new <see cref="global::WideWorldImporters.Shared.ApiSdk.Odata.People.Item.InvoiceLines.Item.WithInvoiceLineItemRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithInvoiceLineItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/odata/People/{personId}/invoiceLines/{invoiceLineId}{?%24expand,%24select}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::WideWorldImporters.Shared.ApiSdk.Odata.People.Item.InvoiceLines.Item.WithInvoiceLineItemRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithInvoiceLineItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/odata/People/{personId}/invoiceLines/{invoiceLineId}{?%24expand,%24select}", rawUrl)
        {
        }
        /// <summary>
        /// Get invoiceLines from People
        /// </summary>
        /// <returns>A <see cref="global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.InvoiceLine"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.ODataErrors.ODataError">When receiving a 4XX or 5XX status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.InvoiceLine?> GetAsync(Action<RequestConfiguration<global::WideWorldImporters.Shared.ApiSdk.Odata.People.Item.InvoiceLines.Item.WithInvoiceLineItemRequestBuilder.WithInvoiceLineItemRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.InvoiceLine> GetAsync(Action<RequestConfiguration<global::WideWorldImporters.Shared.ApiSdk.Odata.People.Item.InvoiceLines.Item.WithInvoiceLineItemRequestBuilder.WithInvoiceLineItemRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "XXX", global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.ODataErrors.ODataError.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.InvoiceLine>(requestInfo, global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.InvoiceLine.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Get invoiceLines from People
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::WideWorldImporters.Shared.ApiSdk.Odata.People.Item.InvoiceLines.Item.WithInvoiceLineItemRequestBuilder.WithInvoiceLineItemRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::WideWorldImporters.Shared.ApiSdk.Odata.People.Item.InvoiceLines.Item.WithInvoiceLineItemRequestBuilder.WithInvoiceLineItemRequestBuilderGetQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="global::WideWorldImporters.Shared.ApiSdk.Odata.People.Item.InvoiceLines.Item.WithInvoiceLineItemRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::WideWorldImporters.Shared.ApiSdk.Odata.People.Item.InvoiceLines.Item.WithInvoiceLineItemRequestBuilder WithUrl(string rawUrl)
        {
            return new global::WideWorldImporters.Shared.ApiSdk.Odata.People.Item.InvoiceLines.Item.WithInvoiceLineItemRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Get invoiceLines from People
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class WithInvoiceLineItemRequestBuilderGetQueryParameters 
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
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class WithInvoiceLineItemRequestBuilderGetRequestConfiguration : RequestConfiguration<global::WideWorldImporters.Shared.ApiSdk.Odata.People.Item.InvoiceLines.Item.WithInvoiceLineItemRequestBuilder.WithInvoiceLineItemRequestBuilderGetQueryParameters>
        {
        }
    }
}
#pragma warning restore CS0618
