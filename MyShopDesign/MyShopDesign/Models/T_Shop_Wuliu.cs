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
    
    public partial class T_Shop_Wuliu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Shop_Wuliu()
        {
            this.T_Shop_OrderForm = new HashSet<T_Shop_OrderForm>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Address { get; set; }
    
        public virtual T_Shop_Users T_Shop_Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Shop_OrderForm> T_Shop_OrderForm { get; set; }
    }
}
