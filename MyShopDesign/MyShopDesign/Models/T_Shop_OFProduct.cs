//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyShopDesign.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_Shop_OFProduct
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Nullable<int> Count { get; set; }
        public Nullable<double> Total { get; set; }
    
        public virtual T_Shop_Product T_Shop_Product { get; set; }
        public virtual T_Shop_OrderForm T_Shop_OrderForm { get; set; }
    }
}
