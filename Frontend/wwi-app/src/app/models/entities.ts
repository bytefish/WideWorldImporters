
export interface BuyingGroup {
        buyingGroupId?: number;
        buyingGroupName?: string;
        lastEditedBy?: number;
        lastEditedByNavigation?: Person;
        customers?: Customer[];
        specialDeals?: SpecialDeal[];
    }
    
    export interface City {
        cityId?: number;
        cityName?: string;
        stateProvinceId?: number;
        latestRecordedPopulation?: number | undefined;
        lastEditedBy?: number;
        location?: Geography2;
        lastEditedByNavigation?: Person;
        stateProvince?: StateProvince;
        customerDeliveryCities?: Customer[];
        customerPostalCities?: Customer[];
        supplierDeliveryCities?: Supplier[];
        supplierPostalCities?: Supplier[];
        systemParameterDeliveryCities?: SystemParameter[];
        systemParameterPostalCities?: SystemParameter[];
    }
    
    export interface ColdRoomTemperature {
        coldRoomTemperatureId?: number;
        coldRoomSensorNumber?: number;
        recordedWhen?: Date;
        temperature?: number;
    }
    
    export interface Color {
        colorId?: number;
        colorName?: string;
        lastEditedBy?: number;
        lastEditedByNavigation?: Person;
        stockItems?: StockItem[];
    }
    
    export interface Country {
        countryId?: number;
        countryName?: string;
        formalName?: string;
        isoAlpha3Code?: string | undefined;
        isoNumericCode?: number | undefined;
        countryType?: string | undefined;
        latestRecordedPopulation?: number | undefined;
        continent?: string;
        region?: string;
        subregion?: string;
        lastEditedBy?: number;
        border?: Geography2;
        lastEditedByNavigation?: Person;
        stateProvinces?: StateProvince[];
    }
    
    export interface Customer {
        customerId?: number;
        customerName?: string;
        billToCustomerId?: number;
        customerCategoryId?: number;
        buyingGroupId?: number | undefined;
        primaryContactPersonId?: number;
        alternateContactPersonId?: number | undefined;
        deliveryMethodId?: number;
        deliveryCityId?: number;
        postalCityId?: number;
        creditLimit?: number | undefined;
        accountOpenedDate?: Date;
        standardDiscountPercentage?: number;
        isStatementSent?: boolean;
        isOnCreditHold?: boolean;
        paymentDays?: number;
        phoneNumber?: string;
        faxNumber?: string;
        deliveryRun?: string | undefined;
        runPosition?: string | undefined;
        websiteUrl?: string;
        deliveryAddressLine1?: string;
        deliveryAddressLine2?: string | undefined;
        deliveryPostalCode?: string;
        postalAddressLine1?: string;
        postalAddressLine2?: string | undefined;
        postalPostalCode?: string;
        lastEditedBy?: number;
        deliveryLocation?: Geography2;
        alternateContactPerson?: Person | undefined;
        billToCustomer?: Customer;
        buyingGroup?: BuyingGroup | undefined;
        customerCategory?: CustomerCategory;
        deliveryCity?: City;
        deliveryMethod?: DeliveryMethod;
        lastEditedByNavigation?: Person;
        postalCity?: City;
        primaryContactPerson?: Person;
        customerTransactions?: CustomerTransaction[];
        inverseBillToCustomer?: Customer[];
        invoiceBillToCustomers?: Invoice[];
        invoiceCustomers?: Invoice[];
        orders?: Order[];
        specialDeals?: SpecialDeal[];
        stockItemTransactions?: StockItemTransaction[];
    }
    
    export interface CustomerCategory {
        customerCategoryId?: number;
        customerCategoryName?: string;
        lastEditedBy?: number;
        lastEditedByNavigation?: Person;
        customers?: Customer[];
        specialDeals?: SpecialDeal[];
    }
    
    export interface CustomerTransaction {
        customerTransactionId?: number;
        customerId?: number;
        transactionTypeId?: number;
        invoiceId?: number | undefined;
        paymentMethodId?: number | undefined;
        transactionDate?: Date;
        amountExcludingTax?: number;
        taxAmount?: number;
        transactionAmount?: number;
        outstandingBalance?: number;
        finalizationDate?: Date | undefined;
        isFinalized?: boolean | undefined;
        lastEditedBy?: number;
        lastEditedWhen?: Date;
        customer?: Customer;
        invoice?: Invoice | undefined;
        lastEditedByNavigation?: Person;
        paymentMethod?: PaymentMethod | undefined;
        transactionType?: TransactionType;
    }
    
    export interface DeliveryMethod {
        deliveryMethodId?: number;
        deliveryMethodName?: string;
        lastEditedBy?: number;
        lastEditedByNavigation?: Person;
        customers?: Customer[];
        invoices?: Invoice[];
        purchaseOrders?: PurchaseOrder[];
        suppliers?: Supplier[];
    }
    
    export interface Invoice {
        invoiceId?: number;
        customerId?: number;
        billToCustomerId?: number;
        orderId?: number | undefined;
        deliveryMethodId?: number;
        contactPersonId?: number;
        accountsPersonId?: number;
        salespersonPersonId?: number;
        packedByPersonId?: number;
        invoiceDate?: Date;
        customerPurchaseOrderNumber?: string | undefined;
        isCreditNote?: boolean;
        creditNoteReason?: string | undefined;
        comments?: string | undefined;
        deliveryInstructions?: string | undefined;
        internalComments?: string | undefined;
        totalDryItems?: number;
        totalChillerItems?: number;
        deliveryRun?: string | undefined;
        runPosition?: string | undefined;
        returnedDeliveryData?: string | undefined;
        confirmedDeliveryTime?: Date | undefined;
        confirmedReceivedBy?: string | undefined;
        lastEditedBy?: number;
        lastEditedWhen?: Date;
        accountsPerson?: Person;
        billToCustomer?: Customer;
        contactPerson?: Person;
        customer?: Customer;
        deliveryMethod?: DeliveryMethod;
        lastEditedByNavigation?: Person;
        order?: Order | undefined;
        packedByPerson?: Person;
        salespersonPerson?: Person;
        customerTransactions?: CustomerTransaction[];
        invoiceLines?: InvoiceLine[];
        stockItemTransactions?: StockItemTransaction[];
    }
    
    export interface InvoiceLine {
        invoiceLineId?: number;
        invoiceId?: number;
        stockItemId?: number;
        description?: string;
        packageTypeId?: number;
        quantity?: number;
        unitPrice?: number | undefined;
        taxRate?: number;
        taxAmount?: number;
        lineProfit?: number;
        extendedPrice?: number;
        lastEditedBy?: number;
        lastEditedWhen?: Date;
        invoice?: Invoice;
        lastEditedByNavigation?: Person;
        packageType?: PackageType;
        stockItem?: StockItem;
    }
    
    export interface Order {
        orderId?: number | undefined;
        customerId?: number;
        salespersonPersonId?: number;
        pickedByPersonId?: number | undefined;
        contactPersonId?: number;
        backorderOrderId?: number | undefined;
        orderDate?: Date;
        expectedDeliveryDate?: Date;
        customerPurchaseOrderNumber?: string | undefined;
        isUndersupplyBackordered?: boolean;
        comments?: string | undefined;
        deliveryInstructions?: string | undefined;
        internalComments?: string | undefined;
        pickingCompletedWhen?: Date | undefined;
        lastEditedBy?: number;
        lastEditedWhen?: Date;
        backorderOrder?: Order | undefined;
        contactPerson?: Person;
        customer?: Customer;
        lastEditedByNavigation?: Person;
        pickedByPerson?: Person | undefined;
        salespersonPerson?: Person;
        inverseBackorderOrder?: Order[];
        invoices?: Invoice[];
        orderLines?: OrderLine[];
    }
    
    export interface OrderLine {
        orderLineId?: number;
        orderId?: number | undefined;
        stockItemId?: number;
        description?: string;
        packageTypeId?: number;
        quantity?: number;
        unitPrice?: number | undefined;
        taxRate?: number;
        pickedQuantity?: number;
        pickingCompletedWhen?: Date | undefined;
        lastEditedBy?: number;
        lastEditedWhen?: Date;
        lastEditedByNavigation?: Person;
        order?: Order;
        packageType?: PackageType;
        stockItem?: StockItem;
    }
    
    export interface PackageType {
        packageTypeId?: number;
        packageTypeName?: string;
        lastEditedBy?: number;
        lastEditedByNavigation?: Person;
        invoiceLines?: InvoiceLine[];
        orderLines?: OrderLine[];
        purchaseOrderLines?: PurchaseOrderLine[];
        stockItemOuterPackages?: StockItem[];
        stockItemUnitPackages?: StockItem[];
    }
    
    export interface PaymentMethod {
        paymentMethodId?: number;
        paymentMethodName?: string;
        lastEditedBy?: number;
        lastEditedByNavigation?: Person;
        customerTransactions?: CustomerTransaction[];
        supplierTransactions?: SupplierTransaction[];
    }
    
    export interface Person {
        personId?: number;
        fullName?: string;
        preferredName?: string;
        searchName?: string;
        isPermittedToLogon?: boolean;
        logonName?: string | undefined;
        isExternalLogonProvider?: boolean;
        hashedPassword?: string | undefined;
        isSystemUser?: boolean;
        isEmployee?: boolean;
        isSalesperson?: boolean;
        userPreferences?: string | undefined;
        phoneNumber?: string | undefined;
        faxNumber?: string | undefined;
        emailAddress?: string | undefined;
        photo?: string | undefined;
        customFields?: string | undefined;
        otherLanguages?: string | undefined;
        lastEditedBy?: number;
        lastEditedByNavigation?: Person;
        buyingGroups?: BuyingGroup[];
        cities?: City[];
        colors?: Color[];
        countries?: Country[];
        customerAlternateContactPeople?: Customer[];
        customerCategories?: CustomerCategory[];
        customerLastEditedByNavigations?: Customer[];
        customerPrimaryContactPeople?: Customer[];
        customerTransactions?: CustomerTransaction[];
        deliveryMethods?: DeliveryMethod[];
        inverseLastEditedByNavigation?: Person[];
        invoiceAccountsPeople?: Invoice[];
        invoiceContactPeople?: Invoice[];
        invoiceLastEditedByNavigations?: Invoice[];
        invoiceLines?: InvoiceLine[];
        invoicePackedByPeople?: Invoice[];
        invoiceSalespersonPeople?: Invoice[];
        orderContactPeople?: Order[];
        orderLastEditedByNavigations?: Order[];
        orderLines?: OrderLine[];
        orderPickedByPeople?: Order[];
        orderSalespersonPeople?: Order[];
        packageTypes?: PackageType[];
        paymentMethods?: PaymentMethod[];
        purchaseOrderContactPeople?: PurchaseOrder[];
        purchaseOrderLastEditedByNavigations?: PurchaseOrder[];
        purchaseOrderLines?: PurchaseOrderLine[];
        specialDeals?: SpecialDeal[];
        stateProvinces?: StateProvince[];
        stockGroups?: StockGroup[];
        stockItemHoldings?: StockItemHolding[];
        stockItemStockGroups?: StockItemStockGroup[];
        stockItemTransactions?: StockItemTransaction[];
        stockItems?: StockItem[];
        supplierAlternateContactPeople?: Supplier[];
        supplierCategories?: SupplierCategory[];
        supplierLastEditedByNavigations?: Supplier[];
        supplierPrimaryContactPeople?: Supplier[];
        supplierTransactions?: SupplierTransaction[];
        systemParameters?: SystemParameter[];
        transactionTypes?: TransactionType[];
    }
    
    export interface PurchaseOrder {
        purchaseOrderId?: number;
        supplierId?: number;
        orderDate?: Date;
        deliveryMethodId?: number;
        contactPersonId?: number;
        expectedDeliveryDate?: Date | undefined;
        supplierReference?: string | undefined;
        isOrderFinalized?: boolean;
        comments?: string | undefined;
        internalComments?: string | undefined;
        lastEditedBy?: number;
        lastEditedWhen?: Date;
        contactPerson?: Person;
        deliveryMethod?: DeliveryMethod;
        lastEditedByNavigation?: Person;
        supplier?: Supplier;
        purchaseOrderLines?: PurchaseOrderLine[];
        stockItemTransactions?: StockItemTransaction[];
        supplierTransactions?: SupplierTransaction[];
    }
    
    export interface PurchaseOrderLine {
        purchaseOrderLineId?: number;
        purchaseOrderId?: number;
        stockItemId?: number;
        orderedOuters?: number;
        description?: string;
        receivedOuters?: number;
        packageTypeId?: number;
        expectedUnitPricePerOuter?: number | undefined;
        lastReceiptDate?: Date | undefined;
        isOrderLineFinalized?: boolean;
        lastEditedBy?: number;
        lastEditedWhen?: Date;
        lastEditedByNavigation?: Person;
        packageType?: PackageType;
        purchaseOrder?: PurchaseOrder;
        stockItem?: StockItem;
    }
    
    export interface SpecialDeal {
        specialDealId?: number;
        stockItemId?: number | undefined;
        customerId?: number | undefined;
        buyingGroupId?: number | undefined;
        customerCategoryId?: number | undefined;
        stockGroupId?: number | undefined;
        dealDescription?: string;
        startDate?: Date;
        endDate?: Date;
        discountAmount?: number | undefined;
        discountPercentage?: number | undefined;
        unitPrice?: number | undefined;
        lastEditedBy?: number;
        lastEditedWhen?: Date;
        buyingGroup?: BuyingGroup | undefined;
        customer?: Customer | undefined;
        customerCategory?: CustomerCategory | undefined;
        lastEditedByNavigation?: Person;
        stockGroup?: StockGroup | undefined;
        stockItem?: StockItem | undefined;
    }
    
    export interface StateProvince {
        stateProvinceId?: number;
        stateProvinceCode?: string;
        stateProvinceName?: string;
        countryId?: number;
        salesTerritory?: string;
        latestRecordedPopulation?: number | undefined;
        lastEditedBy?: number;
        border?: Geography2;
        country?: Country;
        lastEditedByNavigation?: Person;
        cities?: City[];
    }
    
    export interface StockGroup {
        stockGroupId?: number;
        stockGroupName?: string;
        lastEditedBy?: number;
        lastEditedByNavigation?: Person;
        specialDeals?: SpecialDeal[];
        stockItemStockGroups?: StockItemStockGroup[];
    }
    
    export interface StockItem {
        stockItemId?: number;
        stockItemName?: string;
        supplierId?: number;
        colorId?: number | undefined;
        unitPackageId?: number;
        outerPackageId?: number;
        brand?: string | undefined;
        size?: string | undefined;
        leadTimeDays?: number;
        quantityPerOuter?: number;
        isChillerStock?: boolean;
        barcode?: string | undefined;
        taxRate?: number;
        unitPrice?: number;
        recommendedRetailPrice?: number | undefined;
        typicalWeightPerUnit?: number;
        marketingComments?: string | undefined;
        internalComments?: string | undefined;
        photo?: string | undefined;
        customFields?: string | undefined;
        tags?: string | undefined;
        searchDetails?: string;
        lastEditedBy?: number;
        color?: Color | undefined;
        lastEditedByNavigation?: Person;
        outerPackage?: PackageType;
        supplier?: Supplier;
        unitPackage?: PackageType;
        stockItemHolding?: StockItemHolding;
        invoiceLines?: InvoiceLine[];
        orderLines?: OrderLine[];
        purchaseOrderLines?: PurchaseOrderLine[];
        specialDeals?: SpecialDeal[];
        stockItemStockGroups?: StockItemStockGroup[];
        stockItemTransactions?: StockItemTransaction[];
    }
    
    export interface StockItemHolding {
        stockItemId?: number;
        quantityOnHand?: number;
        binLocation?: string;
        lastStocktakeQuantity?: number;
        lastCostPrice?: number;
        reorderLevel?: number;
        targetStockLevel?: number;
        lastEditedBy?: number;
        lastEditedWhen?: Date;
        lastEditedByNavigation?: Person;
        stockItem?: StockItem;
    }
    
    export interface StockItemStockGroup {
        stockItemStockGroupId?: number;
        stockItemId?: number;
        stockGroupId?: number;
        lastEditedBy?: number;
        lastEditedWhen?: Date;
        lastEditedByNavigation?: Person;
        stockGroup?: StockGroup;
        stockItem?: StockItem;
    }
    
    export interface StockItemTransaction {
        stockItemTransactionId?: number;
        stockItemId?: number;
        transactionTypeId?: number;
        customerId?: number | undefined;
        invoiceId?: number | undefined;
        supplierId?: number | undefined;
        purchaseOrderId?: number | undefined;
        transactionOccurredWhen?: Date;
        quantity?: number;
        lastEditedBy?: number;
        lastEditedWhen?: Date;
        customer?: Customer | undefined;
        invoice?: Invoice | undefined;
        lastEditedByNavigation?: Person;
        purchaseOrder?: PurchaseOrder | undefined;
        stockItem?: StockItem;
        supplier?: Supplier | undefined;
        transactionType?: TransactionType;
    }
    
    export interface Supplier {
        supplierId?: number;
        supplierName?: string;
        supplierCategoryId?: number;
        primaryContactPersonId?: number;
        alternateContactPersonId?: number;
        deliveryMethodId?: number | undefined;
        deliveryCityId?: number;
        postalCityId?: number;
        supplierReference?: string | undefined;
        bankAccountName?: string | undefined;
        bankAccountBranch?: string | undefined;
        bankAccountCode?: string | undefined;
        bankAccountNumber?: string | undefined;
        bankInternationalCode?: string | undefined;
        paymentDays?: number;
        internalComments?: string | undefined;
        phoneNumber?: string;
        faxNumber?: string;
        websiteUrl?: string;
        deliveryAddressLine1?: string;
        deliveryAddressLine2?: string | undefined;
        deliveryPostalCode?: string;
        postalAddressLine1?: string;
        postalAddressLine2?: string | undefined;
        postalPostalCode?: string;
        lastEditedBy?: number;
        deliveryLocation?: Geography2;
        alternateContactPerson?: Person;
        deliveryCity?: City;
        deliveryMethod?: DeliveryMethod | undefined;
        lastEditedByNavigation?: Person;
        postalCity?: City;
        primaryContactPerson?: Person;
        supplierCategory?: SupplierCategory;
        purchaseOrders?: PurchaseOrder[];
        stockItemTransactions?: StockItemTransaction[];
        stockItems?: StockItem[];
        supplierTransactions?: SupplierTransaction[];
    }
    
    export interface SupplierCategory {
        supplierCategoryId?: number;
        supplierCategoryName?: string;
        lastEditedBy?: number;
        lastEditedByNavigation?: Person;
        suppliers?: Supplier[];
    }
    
    export interface SupplierTransaction {
        supplierTransactionId?: number;
        supplierId?: number;
        transactionTypeId?: number;
        purchaseOrderId?: number | undefined;
        paymentMethodId?: number | undefined;
        supplierInvoiceNumber?: string | undefined;
        transactionDate?: Date;
        amountExcludingTax?: number;
        taxAmount?: number;
        transactionAmount?: number;
        outstandingBalance?: number;
        finalizationDate?: Date | undefined;
        isFinalized?: boolean | undefined;
        lastEditedBy?: number;
        lastEditedWhen?: Date;
        lastEditedByNavigation?: Person;
        paymentMethod?: PaymentMethod | undefined;
        purchaseOrder?: PurchaseOrder | undefined;
        supplier?: Supplier;
        transactionType?: TransactionType;
    }
    
    export interface SystemParameter {
        systemParameterId?: number;
        deliveryAddressLine1?: string;
        deliveryAddressLine2?: string | undefined;
        deliveryCityId?: number;
        deliveryPostalCode?: string;
        postalAddressLine1?: string;
        postalAddressLine2?: string | undefined;
        postalCityId?: number;
        postalPostalCode?: string;
        applicationSettings?: string;
        lastEditedBy?: number;
        lastEditedWhen?: Date;
        deliveryLocation?: Geography2;
        deliveryCity?: City;
        lastEditedByNavigation?: Person;
        postalCity?: City;
    }
    
    export interface TransactionType {
        transactionTypeId?: number;
        transactionTypeName?: string;
        lastEditedBy?: number;
        lastEditedByNavigation?: Person;
        customerTransactions?: CustomerTransaction[];
        stockItemTransactions?: StockItemTransaction[];
        supplierTransactions?: SupplierTransaction[];
    }
    
    export interface VehicleTemperature {
        vehicleTemperatureId?: number;
        vehicleRegistration?: string;
        chillerSensorNumber?: number;
        recordedWhen?: Date;
        temperature?: number;
        fullSensorData?: string | undefined;
        isCompressed?: boolean;
        compressedSensorData?: string | undefined;
    }
    
    export interface Geography {
    }
    
    export interface Geography2 {
    }
    
    export interface GeographyPoint {
        type: GeographyPointType;
        coordinates: number[];
    }
    
    export interface GeographyLineString {
        type: GeographyLineStringType;
        coordinates: number[][];
    }
    
    export interface GeographyPolygon {
        type: GeographyPolygonType;
        coordinates: number[][][];
    }
    
    export interface GeographyMultiPoint {
        type: GeographyMultiPointType;
        coordinates: number[][];
    }
    
    export interface GeographyMultiLineString {
        type: GeographyMultiLineStringType;
        coordinates: number[][][];
    }
    
    export interface GeographyMultiPolygon {
        type: GeographyMultiPolygonType;
        coordinates: number[][][][];
    }
    
    export interface GeographyCollection {
        type: GeographyCollectionType;
        coordinates: Geography2[];
    }
    
    export interface ErrorDto {
        error: Main;
    }
    
    export interface Main {
        code: string;
        message: string;
        target?: string;
        details?: Detail[];
        /** The structure of this object is service-specific */
        innererror?: any;
    }
    
    export interface Detail {
        code: string;
        message: string;
        target?: string;
    }
    
    export enum _orderby {
        VehicleTemperatureId = "vehicleTemperatureId",
        VehicleTemperatureId_desc = "vehicleTemperatureId desc",
        VehicleRegistration = "vehicleRegistration",
        VehicleRegistration_desc = "vehicleRegistration desc",
        ChillerSensorNumber = "chillerSensorNumber",
        ChillerSensorNumber_desc = "chillerSensorNumber desc",
        RecordedWhen = "recordedWhen",
        RecordedWhen_desc = "recordedWhen desc",
        Temperature = "temperature",
        Temperature_desc = "temperature desc",
        FullSensorData = "fullSensorData",
        FullSensorData_desc = "fullSensorData desc",
        IsCompressed = "isCompressed",
        IsCompressed_desc = "isCompressed desc",
        CompressedSensorData = "compressedSensorData",
        CompressedSensorData_desc = "compressedSensorData desc",
    }
    
    export enum _select {
        VehicleTemperatureId = "vehicleTemperatureId",
        VehicleRegistration = "vehicleRegistration",
        ChillerSensorNumber = "chillerSensorNumber",
        RecordedWhen = "recordedWhen",
        Temperature = "temperature",
        FullSensorData = "fullSensorData",
        IsCompressed = "isCompressed",
        CompressedSensorData = "compressedSensorData",
    }
    
    export enum _expand {
        _ = "*",
    }
    
    export interface Anonymous {
        value?: BuyingGroup[];
    }
    
    export interface Anonymous2 {
        value?: Customer[];
    }
    
    export interface Anonymous3 {
        value?: string[];
    }
    
    export interface Anonymous4 {
        value?: SpecialDeal[];
    }
    
    export interface Anonymous5 {
        value?: string[];
    }
    
    export interface Anonymous6 {
        value?: City[];
    }
    
    export interface Anonymous7 {
        value?: Customer[];
    }
    
    export interface Anonymous8 {
        value?: string[];
    }
    
    export interface Anonymous9 {
        value?: Customer[];
    }
    
    export interface Anonymous10 {
        value?: string[];
    }
    
    export interface Anonymous11 {
        value?: Supplier[];
    }
    
    export interface Anonymous12 {
        value?: string[];
    }
    
    export interface Anonymous13 {
        value?: Supplier[];
    }
    
    export interface Anonymous14 {
        value?: string[];
    }
    
    export interface Anonymous15 {
        value?: SystemParameter[];
    }
    
    export interface Anonymous16 {
        value?: string[];
    }
    
    export interface Anonymous17 {
        value?: SystemParameter[];
    }
    
    export interface Anonymous18 {
        value?: string[];
    }
    
    export interface Anonymous19 {
        value?: ColdRoomTemperature[];
    }
    
    export interface Anonymous20 {
        value?: Color[];
    }
    
    export interface Anonymous21 {
        value?: StockItem[];
    }
    
    export interface Anonymous22 {
        value?: string[];
    }
    
    export interface Anonymous23 {
        value?: Country[];
    }
    
    export interface Anonymous24 {
        value?: StateProvince[];
    }
    
    export interface Anonymous25 {
        value?: string[];
    }
    
    export interface Anonymous26 {
        value?: CustomerCategory[];
    }
    
    export interface Anonymous27 {
        value?: Customer[];
    }
    
    export interface Anonymous28 {
        value?: string[];
    }
    
    export interface Anonymous29 {
        value?: SpecialDeal[];
    }
    
    export interface Anonymous30 {
        value?: string[];
    }
    
    export interface Anonymous31 {
        value?: Customer[];
    }
    
    export interface Anonymous32 {
        value?: CustomerTransaction[];
    }
    
    export interface Anonymous33 {
        value?: string[];
    }
    
    export interface Anonymous34 {
        value?: Customer[];
    }
    
    export interface Anonymous35 {
        value?: string[];
    }
    
    export interface Anonymous36 {
        value?: Invoice[];
    }
    
    export interface Anonymous37 {
        value?: string[];
    }
    
    export interface Anonymous38 {
        value?: Invoice[];
    }
    
    export interface Anonymous39 {
        value?: string[];
    }
    
    export interface Anonymous40 {
        value?: Order[];
    }
    
    export interface Anonymous41 {
        value?: string[];
    }
    
    export interface Anonymous42 {
        value?: SpecialDeal[];
    }
    
    export interface Anonymous43 {
        value?: string[];
    }
    
    export interface Anonymous44 {
        value?: StockItemTransaction[];
    }
    
    export interface Anonymous45 {
        value?: string[];
    }
    
    export interface Anonymous46 {
        value?: CustomerTransaction[];
    }
    
    export interface Anonymous47 {
        value?: DeliveryMethod[];
    }
    
    export interface Anonymous48 {
        value?: Customer[];
    }
    
    export interface Anonymous49 {
        value?: string[];
    }
    
    export interface Anonymous50 {
        value?: Invoice[];
    }
    
    export interface Anonymous51 {
        value?: string[];
    }
    
    export interface Anonymous52 {
        value?: PurchaseOrder[];
    }
    
    export interface Anonymous53 {
        value?: string[];
    }
    
    export interface Anonymous54 {
        value?: Supplier[];
    }
    
    export interface Anonymous55 {
        value?: string[];
    }
    
    export interface Anonymous56 {
        value?: InvoiceLine[];
    }
    
    export interface Anonymous57 {
        value?: Invoice[];
    }
    
    export interface Anonymous58 {
        value?: CustomerTransaction[];
    }
    
    export interface Anonymous59 {
        value?: string[];
    }
    
    export interface Anonymous60 {
        value?: InvoiceLine[];
    }
    
    export interface Anonymous61 {
        value?: string[];
    }
    
    export interface Anonymous62 {
        value?: StockItemTransaction[];
    }
    
    export interface Anonymous63 {
        value?: string[];
    }
    
    export interface Anonymous64 {
        value?: OrderLine[];
    }
    
    export interface Anonymous65 {
        value?: Order[];
    }
    
    export interface Anonymous66 {
        value?: Order[];
    }
    
    export interface Anonymous67 {
        value?: string[];
    }
    
    export interface Anonymous68 {
        value?: Invoice[];
    }
    
    export interface Anonymous69 {
        value?: string[];
    }
    
    export interface Anonymous70 {
        value?: OrderLine[];
    }
    
    export interface Anonymous71 {
        value?: string[];
    }
    
    export interface Anonymous72 {
        value?: PackageType[];
    }
    
    export interface Anonymous73 {
        value?: InvoiceLine[];
    }
    
    export interface Anonymous74 {
        value?: string[];
    }
    
    export interface Anonymous75 {
        value?: OrderLine[];
    }
    
    export interface Anonymous76 {
        value?: string[];
    }
    
    export interface Anonymous77 {
        value?: PurchaseOrderLine[];
    }
    
    export interface Anonymous78 {
        value?: string[];
    }
    
    export interface Anonymous79 {
        value?: StockItem[];
    }
    
    export interface Anonymous80 {
        value?: string[];
    }
    
    export interface Anonymous81 {
        value?: StockItem[];
    }
    
    export interface Anonymous82 {
        value?: string[];
    }
    
    export interface Anonymous83 {
        value?: PaymentMethod[];
    }
    
    export interface Anonymous84 {
        value?: CustomerTransaction[];
    }
    
    export interface Anonymous85 {
        value?: string[];
    }
    
    export interface Anonymous86 {
        value?: SupplierTransaction[];
    }
    
    export interface Anonymous87 {
        value?: string[];
    }
    
    export interface Anonymous88 {
        value?: Person[];
    }
    
    export interface Anonymous89 {
        value?: BuyingGroup[];
    }
    
    export interface Anonymous90 {
        value?: string[];
    }
    
    export interface Anonymous91 {
        value?: City[];
    }
    
    export interface Anonymous92 {
        value?: string[];
    }
    
    export interface Anonymous93 {
        value?: Color[];
    }
    
    export interface Anonymous94 {
        value?: string[];
    }
    
    export interface Anonymous95 {
        value?: Country[];
    }
    
    export interface Anonymous96 {
        value?: string[];
    }
    
    export interface Anonymous97 {
        value?: Customer[];
    }
    
    export interface Anonymous98 {
        value?: string[];
    }
    
    export interface Anonymous99 {
        value?: CustomerCategory[];
    }
    
    export interface Anonymous100 {
        value?: string[];
    }
    
    export interface Anonymous101 {
        value?: Customer[];
    }
    
    export interface Anonymous102 {
        value?: string[];
    }
    
    export interface Anonymous103 {
        value?: Customer[];
    }
    
    export interface Anonymous104 {
        value?: string[];
    }
    
    export interface Anonymous105 {
        value?: CustomerTransaction[];
    }
    
    export interface Anonymous106 {
        value?: string[];
    }
    
    export interface Anonymous107 {
        value?: DeliveryMethod[];
    }
    
    export interface Anonymous108 {
        value?: string[];
    }
    
    export interface Anonymous109 {
        value?: Person[];
    }
    
    export interface Anonymous110 {
        value?: string[];
    }
    
    export interface Anonymous111 {
        value?: Invoice[];
    }
    
    export interface Anonymous112 {
        value?: string[];
    }
    
    export interface Anonymous113 {
        value?: Invoice[];
    }
    
    export interface Anonymous114 {
        value?: string[];
    }
    
    export interface Anonymous115 {
        value?: Invoice[];
    }
    
    export interface Anonymous116 {
        value?: string[];
    }
    
    export interface Anonymous117 {
        value?: InvoiceLine[];
    }
    
    export interface Anonymous118 {
        value?: string[];
    }
    
    export interface Anonymous119 {
        value?: Invoice[];
    }
    
    export interface Anonymous120 {
        value?: string[];
    }
    
    export interface Anonymous121 {
        value?: Invoice[];
    }
    
    export interface Anonymous122 {
        value?: string[];
    }
    
    export interface Anonymous123 {
        value?: Order[];
    }
    
    export interface Anonymous124 {
        value?: string[];
    }
    
    export interface Anonymous125 {
        value?: Order[];
    }
    
    export interface Anonymous126 {
        value?: string[];
    }
    
    export interface Anonymous127 {
        value?: OrderLine[];
    }
    
    export interface Anonymous128 {
        value?: string[];
    }
    
    export interface Anonymous129 {
        value?: Order[];
    }
    
    export interface Anonymous130 {
        value?: string[];
    }
    
    export interface Anonymous131 {
        value?: Order[];
    }
    
    export interface Anonymous132 {
        value?: string[];
    }
    
    export interface Anonymous133 {
        value?: PackageType[];
    }
    
    export interface Anonymous134 {
        value?: string[];
    }
    
    export interface Anonymous135 {
        value?: PaymentMethod[];
    }
    
    export interface Anonymous136 {
        value?: string[];
    }
    
    export interface Anonymous137 {
        value?: PurchaseOrder[];
    }
    
    export interface Anonymous138 {
        value?: string[];
    }
    
    export interface Anonymous139 {
        value?: PurchaseOrder[];
    }
    
    export interface Anonymous140 {
        value?: string[];
    }
    
    export interface Anonymous141 {
        value?: PurchaseOrderLine[];
    }
    
    export interface Anonymous142 {
        value?: string[];
    }
    
    export interface Anonymous143 {
        value?: SpecialDeal[];
    }
    
    export interface Anonymous144 {
        value?: string[];
    }
    
    export interface Anonymous145 {
        value?: StateProvince[];
    }
    
    export interface Anonymous146 {
        value?: string[];
    }
    
    export interface Anonymous147 {
        value?: StockGroup[];
    }
    
    export interface Anonymous148 {
        value?: string[];
    }
    
    export interface Anonymous149 {
        value?: StockItemHolding[];
    }
    
    export interface Anonymous150 {
        value?: string[];
    }
    
    export interface Anonymous151 {
        value?: StockItem[];
    }
    
    export interface Anonymous152 {
        value?: string[];
    }
    
    export interface Anonymous153 {
        value?: StockItemStockGroup[];
    }
    
    export interface Anonymous154 {
        value?: string[];
    }
    
    export interface Anonymous155 {
        value?: StockItemTransaction[];
    }
    
    export interface Anonymous156 {
        value?: string[];
    }
    
    export interface Anonymous157 {
        value?: Supplier[];
    }
    
    export interface Anonymous158 {
        value?: string[];
    }
    
    export interface Anonymous159 {
        value?: SupplierCategory[];
    }
    
    export interface Anonymous160 {
        value?: string[];
    }
    
    export interface Anonymous161 {
        value?: Supplier[];
    }
    
    export interface Anonymous162 {
        value?: string[];
    }
    
    export interface Anonymous163 {
        value?: Supplier[];
    }
    
    export interface Anonymous164 {
        value?: string[];
    }
    
    export interface Anonymous165 {
        value?: SupplierTransaction[];
    }
    
    export interface Anonymous166 {
        value?: string[];
    }
    
    export interface Anonymous167 {
        value?: SystemParameter[];
    }
    
    export interface Anonymous168 {
        value?: string[];
    }
    
    export interface Anonymous169 {
        value?: TransactionType[];
    }
    
    export interface Anonymous170 {
        value?: string[];
    }
    
    export interface Anonymous171 {
        value?: PurchaseOrderLine[];
    }
    
    export interface Anonymous172 {
        value?: PurchaseOrder[];
    }
    
    export interface Anonymous173 {
        value?: PurchaseOrderLine[];
    }
    
    export interface Anonymous174 {
        value?: string[];
    }
    
    export interface Anonymous175 {
        value?: StockItemTransaction[];
    }
    
    export interface Anonymous176 {
        value?: string[];
    }
    
    export interface Anonymous177 {
        value?: SupplierTransaction[];
    }
    
    export interface Anonymous178 {
        value?: string[];
    }
    
    export interface Anonymous179 {
        value?: SpecialDeal[];
    }
    
    export interface Anonymous180 {
        value?: StateProvince[];
    }
    
    export interface Anonymous181 {
        value?: City[];
    }
    
    export interface Anonymous182 {
        value?: string[];
    }
    
    export interface Anonymous183 {
        value?: StockGroup[];
    }
    
    export interface Anonymous184 {
        value?: SpecialDeal[];
    }
    
    export interface Anonymous185 {
        value?: string[];
    }
    
    export interface Anonymous186 {
        value?: StockItemStockGroup[];
    }
    
    export interface Anonymous187 {
        value?: string[];
    }
    
    export interface Anonymous188 {
        value?: StockItemHolding[];
    }
    
    export interface Anonymous189 {
        value?: StockItem[];
    }
    
    export interface Anonymous190 {
        value?: InvoiceLine[];
    }
    
    export interface Anonymous191 {
        value?: string[];
    }
    
    export interface Anonymous192 {
        value?: OrderLine[];
    }
    
    export interface Anonymous193 {
        value?: string[];
    }
    
    export interface Anonymous194 {
        value?: PurchaseOrderLine[];
    }
    
    export interface Anonymous195 {
        value?: string[];
    }
    
    export interface Anonymous196 {
        value?: SpecialDeal[];
    }
    
    export interface Anonymous197 {
        value?: string[];
    }
    
    export interface Anonymous198 {
        value?: StockItemStockGroup[];
    }
    
    export interface Anonymous199 {
        value?: string[];
    }
    
    export interface Anonymous200 {
        value?: StockItemTransaction[];
    }
    
    export interface Anonymous201 {
        value?: string[];
    }
    
    export interface Anonymous202 {
        value?: StockItemStockGroup[];
    }
    
    export interface Anonymous203 {
        value?: StockItemTransaction[];
    }
    
    export interface Anonymous204 {
        value?: SupplierCategory[];
    }
    
    export interface Anonymous205 {
        value?: Supplier[];
    }
    
    export interface Anonymous206 {
        value?: string[];
    }
    
    export interface Anonymous207 {
        value?: Supplier[];
    }
    
    export interface Anonymous208 {
        value?: PurchaseOrder[];
    }
    
    export interface Anonymous209 {
        value?: string[];
    }
    
    export interface Anonymous210 {
        value?: StockItem[];
    }
    
    export interface Anonymous211 {
        value?: string[];
    }
    
    export interface Anonymous212 {
        value?: StockItemTransaction[];
    }
    
    export interface Anonymous213 {
        value?: string[];
    }
    
    export interface Anonymous214 {
        value?: SupplierTransaction[];
    }
    
    export interface Anonymous215 {
        value?: string[];
    }
    
    export interface Anonymous216 {
        value?: SupplierTransaction[];
    }
    
    export interface Anonymous217 {
        value?: SystemParameter[];
    }
    
    export interface Anonymous218 {
        value?: TransactionType[];
    }
    
    export interface Anonymous219 {
        value?: CustomerTransaction[];
    }
    
    export interface Anonymous220 {
        value?: string[];
    }
    
    export interface Anonymous221 {
        value?: StockItemTransaction[];
    }
    
    export interface Anonymous222 {
        value?: string[];
    }
    
    export interface Anonymous223 {
        value?: SupplierTransaction[];
    }
    
    export interface Anonymous224 {
        value?: string[];
    }
    
    export interface Anonymous225 {
        value?: VehicleTemperature[];
    }
    
    export enum GeographyPointType {
        Point = "Point",
    }
    
    export enum GeographyLineStringType {
        LineString = "LineString",
    }
    
    export enum GeographyPolygonType {
        Polygon = "Polygon",
    }
    
    export enum GeographyMultiPointType {
        MultiPoint = "MultiPoint",
    }
    
    export enum GeographyMultiLineStringType {
        MultiLineString = "MultiLineString",
    }
    
    export enum GeographyMultiPolygonType {
        MultiPolygon = "MultiPolygon",
    }
    
    export enum GeographyCollectionType {
        GeometryCollection = "GeometryCollection",
    }
    