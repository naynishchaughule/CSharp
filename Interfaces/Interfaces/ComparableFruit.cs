using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    class ComparableFruit : IComparable
    {
        public enum SortBy
        {
            FruitName,
            FruitPrice
        }

        public String Name { get; set; }
        public Double Price { get; set; }
        public static IComparer SortByName 
        {
            get 
            {
                return new SortByName();
            }
        }

        public static IComparer SortByPrice
        {
            get
            {
                return new SortByPrice();
            }
        }

        public ComparableFruit(String name, Double price)
        {
            Name = name;
            Price = price;
        }

        public int CompareTo(object obj)
        {
            //all intrinsic types implement IComparable, so use them instead of the below code
            //if (this.Price < ((ComparableFruit)obj).Price)
            //{
            //    return -1;
            //}
            //else if (this.Price == ((ComparableFruit)obj).Price)
            //{
            //    return 0;
            //}
            //else
            //{
            //    return 1;
            //}
            return this.Price.CompareTo(((ComparableFruit)obj).Price);
        }

        public static IComparer SortOrder(SortBy s)
        {
            if (s == SortBy.FruitName)
            {
                return new SortByName();
            }
            else if (s == SortBy.FruitPrice)
            {
                return new SortByPrice();
            }
            else
            {
                //default order
                return new SortByName();                     
            }
        }
    }
}
