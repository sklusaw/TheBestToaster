using TestApp.FoodClasses.ToastClasses;

namespace TestApp.FoodClasses
{
    internal class PopTart : FoodBase
    {
        public PopTart() : base(MakePopTartToastLevel())
        {
        }

        private static ToastLevel MakePopTartToastLevel()
        {
            Dictionary<string,int> donenessDictionary = new Dictionary<string,int>();

            //values from the db
            donenessDictionary.Add("burnt", 20);


            return new ToastLevel(0, 6, 12, 15, 17);


        }
    }
}
