using TestApp.FoodClasses;

namespace TestApp.ToasterClasses.SlotClasses
{
    public class SlotGroup
    {
        private Slot[] foodSlots;
        private bool isPushedDown;
        private bool isOneSided = false;
        private int timer;
        public SlotGroup()
        {
            foodSlots = new Slot[1];
            InitializeSlots();
        }
        public SlotGroup(int numberOfSlots)
        {
            foodSlots = new Slot[numberOfSlots];
            InitializeSlots();
        }

        public void InitializeSlots()
        {
            for (int i = 0; i < foodSlots.Length; i++)
            {
                foodSlots[i] = new Slot();
            }
        }

        public virtual bool LoadFood(FoodBase abstractFood)
        {
            bool returnValue = false;

            for (int i = 0; i < foodSlots.Length; i++)
            {
                bool foodSlotValue = foodSlots[i].InsertFood(abstractFood);

                if (foodSlotValue == true)
                {
                    Console.WriteLine("Found an Open Slot! Inserted into Food Slot " + i);
                    break;
                }
            }

            return returnValue;
        }

        internal List<FoodBase> getFood()
        {

            List<FoodBase> returnValue = new List<FoodBase>();

            if (!isPushedDown)
            {
                for (int i = 0; i < foodSlots.Length; i++)
                {
                    FoodBase? food = foodSlots[i].TakeFood();

                    if (food != null)
                    {
                        returnValue.Add(food);
                    }
                }
            }
            else
            { 
                Console.WriteLine("Can't take food while pushed down!");
            }
            return returnValue;
        }

        public void PushDown()
        {
            isPushedDown = true;
        }
        public void EjectFood()
        {
            isPushedDown = false;
        }

        internal void SwitchOneSided()
        {
            isOneSided = !isOneSided;
        }

        internal void CookFood(HeatLevel heatLevel, int toasterTime)
        {
            // This method only simulates one second -- please put in a loop to simulate time.

            if (isPushedDown)
            {
                for (int i = 0; i < foodSlots.Length; i++)
                {
                    foodSlots[i].CookFood(heatLevel,isOneSided);
                }
                timer += 1;

                if (timer >= toasterTime)
                {
                    Console.WriteLine("Ding! A slot is done!");
                    EjectFood();
                }
            }
            else
            {   
                //Console.WriteLine("Can't cook food while not pushed down!");
            }
        }

    }
}