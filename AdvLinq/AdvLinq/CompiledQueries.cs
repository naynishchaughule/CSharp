using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace AdvLinq
{
    class CompiledQueries
    {
        NorthwindDataContext context = new NorthwindDataContext();

        public static Func<NorthwindDataContext, IQueryable<Product>> prodsIn = 
                                    CompiledQuery.Compile((NorthwindDataContext context) =>
                                    from item in context.Products
                                    where item.CategoryID == 48090
                                    select item);

        public static Func<NorthwindDataContext, Category> catsIn = CompiledQuery.Compile((NorthwindDataContext con) => (con.Categories.Where<Category>((cat) => (cat.CategoryID == 48090)).Single<Category>((cat) => (cat.CategoryID == 48090))));
                                                                            
    }
}
