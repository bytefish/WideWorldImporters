// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Text.Json;
using System.Text.Json.Nodes;

namespace WideWorldImporters.Api.Infrastructure
{
    /// <summary>
    /// Extension methods to provide missing functionality from the <see cref="System.Text.Json"/> namespace.
    /// </summary>
    public static partial class JsonExtensions
    {
        public static TNode? CopyNode<TNode>(this TNode? node) where TNode : JsonNode => node?.Deserialize<TNode>();
    }
}
