// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService {
    public class CustomerCategory : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The customerCategoryId property</summary>
        public int? CustomerCategoryId { get; set; }
        /// <summary>The customerCategoryName property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? CustomerCategoryName { get; set; }
#nullable restore
#else
        public string CustomerCategoryName { get; set; }
#endif
        /// <summary>The customers property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Customer>? Customers { get; set; }
#nullable restore
#else
        public List<Customer> Customers { get; set; }
#endif
        /// <summary>The lastEditedBy property</summary>
        public int? LastEditedBy { get; set; }
        /// <summary>The lastEditedByNavigation property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Person? LastEditedByNavigation { get; set; }
#nullable restore
#else
        public Person LastEditedByNavigation { get; set; }
#endif
        /// <summary>The specialDeals property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<SpecialDeal>? SpecialDeals { get; set; }
#nullable restore
#else
        public List<SpecialDeal> SpecialDeals { get; set; }
#endif
        /// <summary>
        /// Instantiates a new CustomerCategory and sets the default values.
        /// </summary>
        public CustomerCategory() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static CustomerCategory CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CustomerCategory();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"customerCategoryId", n => { CustomerCategoryId = n.GetIntValue(); } },
                {"customerCategoryName", n => { CustomerCategoryName = n.GetStringValue(); } },
                {"customers", n => { Customers = n.GetCollectionOfObjectValues<Customer>(Customer.CreateFromDiscriminatorValue)?.ToList(); } },
                {"lastEditedBy", n => { LastEditedBy = n.GetIntValue(); } },
                {"lastEditedByNavigation", n => { LastEditedByNavigation = n.GetObjectValue<Person>(Person.CreateFromDiscriminatorValue); } },
                {"specialDeals", n => { SpecialDeals = n.GetCollectionOfObjectValues<SpecialDeal>(SpecialDeal.CreateFromDiscriminatorValue)?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("customerCategoryId", CustomerCategoryId);
            writer.WriteStringValue("customerCategoryName", CustomerCategoryName);
            writer.WriteCollectionOfObjectValues<Customer>("customers", Customers);
            writer.WriteIntValue("lastEditedBy", LastEditedBy);
            writer.WriteObjectValue<Person>("lastEditedByNavigation", LastEditedByNavigation);
            writer.WriteCollectionOfObjectValues<SpecialDeal>("specialDeals", SpecialDeals);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}