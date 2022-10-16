using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEFLex1
{
    internal class Asset
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Price { get; set; }
        public string ModelName { get; set; }

        public string AssetType { get; set; }

    }
}
