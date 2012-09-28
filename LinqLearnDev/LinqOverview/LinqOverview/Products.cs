using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace LinqOverview
{
    [Table(Name = "Products")]
    class Products
    {
        [Column()]
        public int CategoryID { get; set; }

        [Column(IsPrimaryKey = true)]
        public int ProductID { get; set; }

        [Column()]
        public string ProductName { get; set; }

        [Column()]
        public decimal UnitPrice { get; set; }

        [Column()]
        public int UnitsInStock { get; set; }

        public override string ToString()
        {
            return String.Format("CategoryID: {0}, ProductID: {1}, ProductName: {2}, UnitPrice: {3}, UnitsInStock: {4}", this.CategoryID,
                this.ProductID, this.ProductName, this.UnitPrice, this.UnitsInStock);
        }
    }
}
