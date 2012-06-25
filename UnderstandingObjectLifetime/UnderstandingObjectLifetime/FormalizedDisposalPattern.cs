using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnderstandingObjectLifetime
{
    public enum MyEnum
        {
            User,
            CLR
        }

    class FormalizedDisposalPattern : IDisposable
    {
        bool isDisposed = false;
        ~FormalizedDisposalPattern()
        {
            Helper(MyEnum.CLR);
        }

        public void Dispose()
        {
            Helper(MyEnum.User);
            GC.SuppressFinalize(this);
        }

        public void Helper(MyEnum e)
        {
            if (!isDisposed)
            {
                if (e == MyEnum.User)
                {
                    //dispose managed resources
                    Console.WriteLine("dispose managed resources");
                }
                //dispose unmanaged resources
                Console.WriteLine("dispose unmanaged resources");
                isDisposed = true;                
            }
        }
    }
}
