using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEFLex1
{
    internal class Computers : Asset
    {

        public Computers(string brand, DateTime purchasedate, int price, string modelname, string assetType)
        {
            Brand = brand;
            PurchaseDate = purchasedate;
            Price = price;
            ModelName = modelname;
            AssetType = assetType;
        }

    }
}
