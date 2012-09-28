using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvLinq
{
    public partial class Category
    {
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            switch (action)
            {
                case System.Data.Linq.ChangeAction.Delete:
                    break;
                case System.Data.Linq.ChangeAction.Insert:                    
                    break;
                case System.Data.Linq.ChangeAction.None:
                    break;
                case System.Data.Linq.ChangeAction.Update:
                    break;
                default:
                    break;
            }
        }
    }
    public partial class Product
    {
    }
}
