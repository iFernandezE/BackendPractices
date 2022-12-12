using System;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("*Italian restaurant Console App*\n");
        var dishesMenu = new Dictionary<string, double>();
        var beveragesMenu = new Dictionary<string, double>();
        prepareMenu(dishesMenu, beveragesMenu);
        var ordersQueue = new Queue<order>();
        // console:
        int op = appOption();
        while(op ==1){
            Console.Write("Client Name> ");
            string clienName = Console.ReadLine();
            Console.Write("pay method(cash, card)> ");
            string payMethod = Console.ReadLine();
            var order = new order(clienName,payMethod);
            int opOrder = orderOption();
            while(opOrder!=3){
                if (opOrder == 1)
                {
                    order.addDish(dishesMenu);
                }
                else if (opOrder == 2)
                {
                    order.addBeverage(beveragesMenu);
                }
                opOrder = orderOption();
            }
            ordersQueue.Enqueue(order);
            Console.WriteLine($"Queue Orders [{ordersQueue.Count()}]");
            if (ordersQueue.Count()==5){
                
                    prepairOrders(ordersQueue);
              
            }
            op = appOption();
        }
    }

    private static void prepairOrders(Queue<order> ordersQueue)
    {
        while(ordersQueue.Count()>0){
            ordersQueue.Dequeue().getOrderInfo();
        }
    }

    private static int orderOption()
    {
        Console.Write(
        "\nchoose item to add:\n" +
        "   1) dish.\n" +
        "   2) beverage\n" +
        "   3) nothing else\n" +
        "   option> ");
        int opOrder = int.Parse(Console.ReadLine());
        return opOrder;
    }

    private static int appOption()
    {
        Console.Write("\n* Italian Restaurant App *\n" +
        "choose your option:\n" +
        "   1) make an order.\n" +
        "   2) exit\n" +
        "   option> ");
        int appOp = int.Parse( Console.ReadLine() );
        return appOp;
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
    
    public class order{
        public string clientName;
        public string payMethod;
        public Dictionary<string, string> dishesList = new Dictionary<string, string>();
        public Dictionary<string, string> beveragesList = new Dictionary<string, string>();
        public double total;
        
        public order(string clientName, string payMethod){
            this.clientName = clientName;
            this.payMethod = payMethod;
        }
        public void addDish(Dictionary<string, double> dishesMenu)
        {
            Console.Write("choose dish:\n"+
            "   0) " + dishes.Spaghetti.ToString()+"\n"+
            "   1) " + dishes.Lasagna.ToString()+ "\n" +
            "   2) " + dishes.Pizza.ToString()+ "\n" +
            "   3) " + dishes.Calzone.ToString()+ "\n" +
            "\n    option> ");
            int dishOp = int.Parse(Console.ReadLine());
            Console.Write("\n    amount> ");
            int amount = int.Parse(Console.ReadLine());
            total = total + dishesMenu[((dishes)dishOp).ToString()]*amount;
            dishesList.Add(((dishes)dishOp).ToString(), amount.ToString());
            Console.WriteLine("agregado");

        }
        public void addBeverage(Dictionary<string, double> beveragesMenu)
        {
            Console.Write("choose dish:\n" +
            "   0) " + beverages.Soda.ToString() + "\n" +
            "   1) " + beverages.Wine.ToString() + "\n" +
            "   2) " + beverages.Beer.ToString() + "\n" +
            "\n option> ");
            int beverageOp = int.Parse(Console.ReadLine());
            Console.Write("\n    amount> ");
            int amount = int.Parse(Console.ReadLine());
            total = total + beveragesMenu[((beverages)beverageOp).ToString()]*amount;
            beveragesList.Add(((beverages)beverageOp).ToString(), amount.ToString());
        }
        public string getOrderInfo(){
            string info = $"Customer {clientName}: ";
            foreach(var (key,value) in dishesList){
                info+= value.ToString()+"(s) "+key+" ";
            }
            info += $"total cost: ${total} / payment method:{payMethod}";
            return info;
        }
    }
}