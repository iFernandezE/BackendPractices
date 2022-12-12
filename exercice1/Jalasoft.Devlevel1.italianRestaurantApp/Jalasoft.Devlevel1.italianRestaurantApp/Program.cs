internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Italian restaurant Console App");
        var dishesMenu = new Dictionary<string, double>();
        var beveragesMenu = new Dictionary<string, double>();
        prepareMenu(dishesMenu, beveragesMenu);
        var ordersQueue = new Queue<order>();
        // console:
        int op = opConsole();
        while(op ==1 && ordersQueue.Count<=5){
            
        }
    }

    
    private static int opConsole()
    {
        Console.WriteLine("* Italian Restaurant App *\n" +
        "choose your option:\n" +
        "   1) make an order.\n" +
        "   2) exit\n");
        int op = int.Parse( Console.ReadLine() );
        return op;
    }

    private static void prepareMenu(Dictionary<string, double> dishesMenu, Dictionary<string, double> beveragesMenu)
    {
        dishesMenu.Add(dishes.Spaghetti.ToString(), 10.99);
        dishesMenu.Add(dishes.Lasagna.ToString(),12.99);
        dishesMenu.Add(dishes.Pizza.ToString(),8);
        dishesMenu.Add(dishes.Calzone.ToString(),6);

        beveragesMenu.Add(beverages.Soda.ToString(),6.5);
        beveragesMenu.Add(beverages.Wine.ToString(),9);
        beveragesMenu.Add(beverages.Beer.ToString(),7.5);
    }

    enum dishes{ 
        Spaghetti,
        Lasagna,
        Pizza,
        Calzone}
    enum beverages{ 
        Soda,
        Wine,
        Beer
    }
    
    public struct order{
        public string clientName;
        public List<string> dishes;
        public List<string> beverages;
        
        public order(string clientName){
            this.clientName = clientName;
        }
        public void addDish(){
            
        }
        public void addBeverage(){

        }
        public double getTotalPrice()
        {

        }
    }
}