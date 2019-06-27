using System;
using System.Linq;

namespace Tuple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split();
            string personName = personInfo[0] + " " + personInfo[1];
            string adress = personInfo[2];
            string town = personInfo[3];

            string[] beerInfo = Console.ReadLine().Split();
            string name = beerInfo[0];
            int liters = int.Parse(beerInfo[1]);
            bool isDrunk = personInfo[2] == "drunk" ? false : true;

            string[] bankInfo = Console.ReadLine().Split();
            string bankHolderName = bankInfo[0];
            double ballance = double.Parse(bankInfo[1]);
            string bankName = bankInfo[2];


            SpecialTuple<string, string,string> personTuple = new SpecialTuple<string, string, string>(personName,adress,town);
            SpecialTuple<string, int,bool> beerTuple = new SpecialTuple<string, int, bool>(name, liters,isDrunk);
            SpecialTuple<string,double,string> specialTuple = new SpecialTuple<string, double, string>(bankHolderName, ballance,bankName);
            Console.WriteLine(personTuple);
            Console.WriteLine(beerTuple);
            Console.WriteLine(specialTuple);
        }
    }
}
