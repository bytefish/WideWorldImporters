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
namespace WideWorldImporters.Shared.ApiSdk.Odata.People.Item.BuyingGroups.Item {
    /// <summary>
    /// Provides operations to manage the buyingGroups property of the WideWorldImportersService.Person entity.
    /// </summary>
    public class WithBuyingGroupItemRequestBuilder : BaseRequestBuilder {
        /// <summary>
        /// Instantiates a new WithBuyingGroupItemRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithBuyingGroupItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/odata/People/{personId}/buyingGroups/{buyingGroupId}{?%24select,%24expand}", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new WithBuyingGroupItemRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithBuyingGroupItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/odata/People/{personId}/buyingGroups/{buyingGroupId}{?%24select,%24expand}", rawUrl) {
        }
        /// <summary>
        /// Get buyingGroups from People
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.BuyingGroup?> GetAsync(Action<WithBuyingGroupItemRequestBuilderGetRequestConfiguration>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.BuyingGroup> GetAsync(Action<WithBuyingGroupItemRequestBuilderGetRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"4XX", ODataError.CreateFromDiscriminatorValue},
                {"5XX", ODataError.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.BuyingGroup>(requestInfo, WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.BuyingGroup.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Get buyingGroups from People
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<WithBuyingGroupItemRequestBuilderGetRequestConfiguration>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<WithBuyingGroupItemRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            if (requestConfiguration != null) {
                var requestConfig = new WithBuyingGroupItemRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            requestInfo.Headers.TryAdd("Accept", "application/json;q=1");
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public WithBuyingGroupItemRequestBuilder WithUrl(string rawUrl) {
            return new WithBuyingGroupItemRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Get buyingGroups from People
        /// </summary>
        public class WithBuyingGroupItemRequestBuilderGetQueryParameters {
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
        public class WithBuyingGroupItemRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public RequestHeaders Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public WithBuyingGroupItemRequestBuilderGetQueryParameters QueryParameters { get; set; } = new WithBuyingGroupItemRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new WithBuyingGroupItemRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public WithBuyingGroupItemRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new RequestHeaders();
            }
        }
    }
}
