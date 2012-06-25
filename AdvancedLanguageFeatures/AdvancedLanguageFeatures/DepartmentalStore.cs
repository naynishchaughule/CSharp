using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedLanguageFeatures
{
    class Product
    {
        public Double Id { get; set; }
        public String Name { get; set; }
        public Double Price { get; set; }
        public Int32 StockCount { get; set; }

        public Product(Double id, String name, Double price, Int32 stockcount)
        {
            Id = id;
            Name = name;
            Price = price;
            StockCount = stockcount;
        }
    }
    
    //maintain a list of all the products in the store
    class ProductList
    {
        Product[] pArray;
        public ProductList()
        {
            //assuming there are 10,000 different types of products. Each type of product like a "deer-park water bottle - 500 ml" 
            //will have a StockCount.
            pArray = new Product[10000];
        }

        public void Display()
        {
            Console.WriteLine("Display in ProductList called");
        }
    }

    //class Store has a member variable pList which is not used that often but it occupies a lot of space in the memory.
    //such member variables can be instantiated only when the need arises. use Lazy<>
    class Store
    {
        //you can also call custom constructor
        //suppose you want to call additional method when this variable is created
        //The generic delegate in question is of type System.Func<>, which can point to a method that returns
        //the same data type being created by the related Lazy<> variable and can take up to 16 arguments (which
        //are typed using generic type parameters).
        Lazy<ProductList> pList = new Lazy<ProductList>(
        () =>
            {
                //do some additional work apart from calling the ctor and then return the instance of ProductList
                return new ProductList();
            }
        );          

        //other tasks in a store
        public void Billing()
        {
            
        }

        //this method is called by the object user to view the product list of a store
        //this is called less frequently, hence i can delay the creation of ProductList object until this method is called
        public void ShowProductList()
        {
            pList.Value.Display();
        }       
    }
}
