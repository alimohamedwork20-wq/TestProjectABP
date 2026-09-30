using Riok.Mapperly.Abstractions;
using TestProjectABP.Brands;
using TestProjectABP.Categories;
using TestProjectABP.Invoices;
using TestProjectABP.Orders;
using TestProjectABP.Products;
using TestProjectABP.Suppliers;
using Volo.Abp.Mapperly;

namespace TestProjectABP;

//----------------------  Product Mapper ----------------------//
[Mapper]
public partial class CreateUpdateProductDtoToProductMapper : MapperBase<CreateUpdateProductDto, Product>
{
    public override partial Product Map(CreateUpdateProductDto source);
    public override partial void Map(CreateUpdateProductDto source, Product destination);
}

[Mapper]
public partial class ProductToProductDtoMapper : MapperBase<Product, ProductDto>
{
    public override partial ProductDto Map(Product source);
    public override partial void Map(Product source, ProductDto destination);
}

//----------------------  Category Mapper ----------------------//
[Mapper]
public partial class CategoryToCategoryDto : MapperBase<Category,CategoryDto>
{
    public override partial CategoryDto Map(Category source);
    public  override  partial void Map(Category source, CategoryDto destination);
}

[Mapper]
public partial class CreateUpdateCategoryDtoToCategory : MapperBase<CreateUpdateCategoryDto, Category>
{
    public override partial Category Map(CreateUpdateCategoryDto source);
    public override partial void Map(CreateUpdateCategoryDto source, Category destination);
}

//----------------------  Brand Mapper ----------------------//
[Mapper]
public partial class BrandToBrandDto : MapperBase<Brand, BrandDto>
{
    public override partial BrandDto Map(Brand source);
    public override partial void Map(Brand source, BrandDto destination);
}

[Mapper]
public partial class CreateUpdateBrandDtoToBrand : MapperBase<CreateUpdateBrandDto, Brand>
{
    public override partial Brand Map(CreateUpdateBrandDto source);
    public override partial void Map(CreateUpdateBrandDto source, Brand destination);
}

//----------------------  Supplier Mapper ----------------------//
[Mapper]
public partial class CreateUpdateSupplierDtoToSupplierMapper : MapperBase<CreateUpdateSupplierDto, Supplier>
{
    public override partial Supplier Map(CreateUpdateSupplierDto source);
    public override partial void Map(CreateUpdateSupplierDto source, Supplier destination);
}

[Mapper]
public partial class SupplierToSupplierDtoMapper : MapperBase<Supplier, SupplierDto>
{
    public override partial SupplierDto Map(Supplier source);
    public override partial void Map(Supplier source, SupplierDto destination);
}

//----------------------  Order Mapper ----------------------//
[Mapper]
public partial class OrderToOrderDtoMapper : MapperBase<Order, OrderDto>{
    public override partial OrderDto Map(Order source);
    public override partial void Map(Order source, OrderDto destination);
}

[Mapper]
public partial class CreateUpdateOrderDtoToOrderMapper : MapperBase<CreateUpdateOrderDto, Order>
{
    public override partial Order Map(CreateUpdateOrderDto source);
    public override partial void Map(CreateUpdateOrderDto source, Order destination);
}

//----------------------  OrderItem Mapper ----------------------//
[Mapper]
public partial class OrderItemToOrderItemDtoMapper : MapperBase<OrderItem, OrderItemDto>
{
    public override partial OrderItemDto Map(OrderItem source);
    public override partial void Map(OrderItem source, OrderItemDto destination);
}

[Mapper]
public partial class CreateOrderItemDtoToOrderItemMapper : MapperBase<CreateOrderItemDto, OrderItem>
{
    public override partial OrderItem Map(CreateOrderItemDto source);
    public override partial void Map(CreateOrderItemDto source, OrderItem destination);
}

//----------------------  Invoice Mapper ----------------------//

[Mapper]
public partial class InvoiceToInvoiceDtoMapper : MapperBase<Invoice, InvoiceDto>
{
    public override partial InvoiceDto Map(Invoice source);
    public override partial void Map(Invoice source, InvoiceDto destination);
}

[Mapper]
public partial class CreateUpdateInvoiceDtoToInvoiceMapper : MapperBase<CreateUpdateInvoiceDto, Invoice>
{
    public override partial Invoice Map(CreateUpdateInvoiceDto source);
    public override partial void Map(CreateUpdateInvoiceDto source, Invoice destination);
}

//----------------------  InvoiceItem Mapper ----------------------//
[Mapper]
public partial class InvoiceItemToInvoiceItemDtoMapper : MapperBase<InvoiceItem, InvoiceItemDto>
{
    public override partial InvoiceItemDto Map(InvoiceItem source);
    public override partial void Map(InvoiceItem source, InvoiceItemDto destination);
}

[Mapper]
public partial class CreateUpdateInvoiceItemDtoToInvoiceItemMapper : MapperBase<CreateUpdateInvoiceItemDto, InvoiceItem>
{
    public override partial InvoiceItem Map(CreateUpdateInvoiceItemDto source);
    public override partial void Map(CreateUpdateInvoiceItemDto source, InvoiceItem destination);
}