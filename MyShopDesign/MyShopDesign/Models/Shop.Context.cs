﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MyShopEntities : DbContext
    {
        public MyShopEntities()
            : base("name=MyShopEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<T_Shop_Product> T_Shop_Product { get; set; }
        public virtual DbSet<T_Shop_ProductCategory> T_Shop_ProductCategory { get; set; }
        public virtual DbSet<T_Shop_Users> T_Shop_Users { get; set; }
        public virtual DbSet<T_Shop_Workers> T_Shop_Workers { get; set; }
        public virtual DbSet<T_Shop_Wuliu> T_Shop_Wuliu { get; set; }
        public virtual DbSet<V_Shop_ProductPriceAsc> V_Shop_ProductPriceAsc { get; set; }
        public virtual DbSet<V_Shop_ProductPriceDesc> V_Shop_ProductPriceDesc { get; set; }
        public virtual DbSet<T_Shop_Basket> T_Shop_Basket { get; set; }
        public virtual DbSet<T_Shop_OFProduct> T_Shop_OFProduct { get; set; }
        public virtual DbSet<V_Shop_SuperAdin> V_Shop_SuperAdin { get; set; }
        public virtual DbSet<T_Shop_OrderForm> T_Shop_OrderForm { get; set; }
    }
}
