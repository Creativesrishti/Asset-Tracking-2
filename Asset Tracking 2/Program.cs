using ConsoleAppEFLex1;
using System.Security.Cryptography.X509Certificates;

//Console.WriteLine("Enter the list of assets and type q to exit");
//List<Asset> assets = new List<Asset>();

MyDbContext Context = new MyDbContext();
while (true)
{
    Console.WriteLine("1.List all assets");
    Console.WriteLine("2.Add new assets");
    Console.WriteLine("3.Edit an asset");
    Console.WriteLine("4.Delete an asset");
    String input = Console.ReadLine();
    switch (input) {
        case "1":
            List<Asset> Result = Context.Assets.ToList();
            List<Asset> sortedResults = Result.OrderBy(x => x.AssetType).ThenBy(x => x.PurchaseDate).ToList();
            if (sortedResults.Count > 0)
            {
                Console.WriteLine("Id".PadRight(10) + "Brand".PadRight(10) + "Purchase Date".PadRight(30)
                        + "Price".PadRight(10) + "Model Name".PadRight(10));
                foreach (var asset1 in sortedResults)
                {
                    Console.WriteLine(asset1.Id.ToString().PadRight(10) + asset1.Brand.PadRight(10) + asset1.PurchaseDate.ToString().PadRight(30)
                        + asset1.Price.ToString().PadRight(10) + asset1.ModelName.ToString().PadRight(10));
                }
            }
            else
            {
                Console.WriteLine("No records in the database");
            }
            break;
        case "2":
            Console.WriteLine("Enter the type of Asset you want to add(Computer/Phone)");
            string typeOfAsset = Console.ReadLine();
            if (typeOfAsset.ToLower() == "q")
            {
                break;
            }

            Console.WriteLine("Enter Brand name");
            string brand = Console.ReadLine();

            Console.WriteLine("Enter Purchase Date in format YYYY-MM-dd");
            string purchasedate = Console.ReadLine();

            Console.WriteLine("Enter Price");
            string price = Console.ReadLine();

            Console.WriteLine("Model Name");
            string modelname = Console.ReadLine();

            if (typeOfAsset.ToLower().Trim() == "computer")
            {
                Computers comp = new Computers(brand, DateTime.Parse(purchasedate), Convert.ToInt32(price), modelname, typeOfAsset);
                Context.Assets.Add(comp);
            }
            if (typeOfAsset.ToLower().Trim() == "phone")
            {
                Phones phone = new Phones(brand, DateTime.Parse(purchasedate), Convert.ToInt32(price), modelname, typeOfAsset);
                Context.Assets.Add(phone);
            }
            Context.SaveChanges();
            Console.WriteLine("Data saved successfully");
            break;
        case "3":
            Console.WriteLine("Enter the Id of the Asset to Edit");
            int id = Convert.ToInt32(Console.ReadLine());
            var asset = Context.Assets.SingleOrDefault(x => x.Id == id);
            Console.WriteLine("Enter Brand name");
            string newbrand = Console.ReadLine();

            Console.WriteLine("Enter Purchase Date in format YYYY-MM-dd");
            string newpurchasedate = Console.ReadLine();

            Console.WriteLine("Enter Price");
            string newprice = Console.ReadLine();

            Console.WriteLine("Model Name");
            string newmodelname = Console.ReadLine();
            asset.Brand = newbrand;
            asset.PurchaseDate = DateTime.Parse(newpurchasedate);
            asset.Price = Convert.ToInt32(newprice);
            asset.ModelName = newmodelname;
            Context.SaveChanges();
            Console.WriteLine("Asset edited successfully");
            break;
        case "4":
            Console.WriteLine("Enter the Id of asset to delete");
            int deleteId = Convert.ToInt32(Console.ReadLine());
            var deleteasset = Context.Assets.SingleOrDefault(x => x.Id == deleteId);
            Context.Assets.Remove(deleteasset);
            Context.SaveChanges();
            Console.WriteLine("Asset deleted successfully");
            break;
default:
            return;
            break;
    }

    
}



