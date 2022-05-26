using TestApp.FoodClasses;
using TestApp.ToasterClasses;
using TestApp.ToasterClasses.SlotClasses;

namespace Test
{
    class Test
    {
        static void Main(string[] args)
        {
            //Given
            System.Console.WriteLine("Creating Toaster");
            ToasterBase toaster = new ToasterBase();

            toaster.PlugInToaster();

            System.Console.WriteLine("Load Poptart");
            toaster.LoadFood(new PopTart());

            System.Console.WriteLine("Set Heat To Low");
            toaster.SetHeat(HeatLevel.Low);

            System.Console.WriteLine("Push Down");
            toaster.PushDownAll();


            //When
            System.Console.WriteLine("Cook for 30 seconds");
            for (int i = 0; i < 30; i++)
            {
                toaster.CookFood();
            }

            List<FoodBase> foodBase = toaster.GetFood();


            //Then
            foreach (FoodBase food in foodBase)
            { 
                Console.WriteLine("This "+ food.GetType() + " item is: "+ food.GetToastLevelTop() + " on top and " +food.GetToastLevelBottom() + " on the bottom.");
            }

        }
    }
}