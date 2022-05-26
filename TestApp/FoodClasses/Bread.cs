using TestApp.FoodClasses.ToastClasses;

namespace TestApp.FoodClasses
{
    internal class Bread : FoodBase
    {
        public Bread() : base(MakeBreadToastLevel())
        {
        }

        private static ToastLevel MakeBreadToastLevel()
        {
            return new ToastLevel(0, 5, 10, 15, 17);
        }
    }
}
