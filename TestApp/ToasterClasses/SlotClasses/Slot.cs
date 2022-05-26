using TestApp.FoodClasses;

namespace TestApp.ToasterClasses.SlotClasses
{
    public class Slot
    {
        private FoodBase? foodBeingCooked;

        public Slot()
        {
        }

        public virtual bool InsertFood(FoodBase foodBase)
        {
            if (HasFood())
            {
                Console.WriteLine("Already has food!");
                return false;
            }
            else
            {
                Console.WriteLine("Inserting Food!");
                foodBeingCooked = foodBase;
                return true;
            }
        }

        internal virtual bool HasFood()
        {
            if (foodBeingCooked == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal FoodBase? TakeFood()
        {
            if (foodBeingCooked != null)
            {
                Console.WriteLine("Ejecting Food!");
                FoodBase foodToBeReturned = foodBeingCooked;
                foodBeingCooked = null;
                return foodToBeReturned;
            }
            else
            {
                Console.WriteLine("No Food To Eject!");
                return null;
            }
        }

        public virtual void CookFood(HeatLevel heatLevel, bool isOneSided)
        {
            if (foodBeingCooked != null)
            {
                foodBeingCooked.Cook(((int)heatLevel), isOneSided);
            }
        }
    }
}