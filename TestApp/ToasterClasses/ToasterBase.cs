using TestApp.FoodClasses;
using TestApp.ToasterClasses.SlotClasses;

namespace TestApp.ToasterClasses
{
    public class ToasterBase
    {
        private SlotGroup[] toasterSlots;
        private int StandardTime = 10;
        private HeatLevel heatLevel;
        private bool isPluggedIn;

        public ToasterBase()
        {
            toasterSlots = new SlotGroup[1];
            InitializeSlots();
            heatLevel = HeatLevel.Medium;
            isPluggedIn = false;
        }

        public ToasterBase(int numberOfSlots)
        {
            toasterSlots = new SlotGroup[numberOfSlots];
            InitializeSlots();
            heatLevel = HeatLevel.Medium;
            isPluggedIn = false;
        }

        public ToasterBase(int numberOfSlots, int slotsPer)
        {
            toasterSlots = new SlotGroup[numberOfSlots];
            InitializeSlots(slotsPer);
            heatLevel = HeatLevel.Medium;
            isPluggedIn = false;
        }

        private void InitializeSlots(int slotsPer)
        {
            for (int i = 0; i < toasterSlots.Length; i++)
            {
                toasterSlots[i] = new SlotGroup(slotsPer);
            }
        }

        internal List<FoodBase> GetFood()
        {
            List<FoodBase> list = new List<FoodBase>();

            for (int i = 0; i < toasterSlots.Length; i++)
            {
                List<FoodBase> foodFromSlot = toasterSlots[i].getFood();

                if (foodFromSlot != null && foodFromSlot.Count > 0)
                {
                    foreach (FoodBase food in foodFromSlot)
                    {
                        list.Add(food);
                    }
                }

            }
            return list;
        }

        public void SetHeat(HeatLevel heat)
        {
            heatLevel = heat;
        }

        public void PlugInToaster()
        {
            isPluggedIn = true;
        }
        public void UnPlugToaster()
        {
            isPluggedIn = false;
        }

        public void InitializeSlots()
        {
            for (int i = 0; i < toasterSlots.Length; i++)
            {
                toasterSlots[i] = new SlotGroup();
            }
        }

        public virtual bool LoadFood(FoodBase food)
        {
            bool returnValue = false;

            for (int i = 0; i < toasterSlots.Length; i++)
            {
                bool slotReturn = toasterSlots[i].LoadFood(food);
                if (slotReturn)
                {
                    Console.WriteLine("Successfully Loaded Food");
                    returnValue = true;
                    break;
                }
            }

            return returnValue;
        }        

        public virtual void PushDown(int slotNumber)
        {
            if (isPluggedIn)
            {
                if (VerifySlot(slotNumber))
                {
                    toasterSlots[slotNumber].PushDown();
                }
            }
            else
            {
                Console.WriteLine("Toaster Is Not Plugged in!");
            }
        }


        internal void PushDownAll()
        {
            if (isPluggedIn)
            {
                for (int slots = 0; slots < toasterSlots.Length; slots++)
                {
                    toasterSlots[slots].PushDown();
                    Console.WriteLine("Slot "+ slots +" is now Pushed Down");
                }
            }
            else
            {
                Console.WriteLine("Toaster Is Not Plugged in!");
            }
        }


        public virtual bool VerifySlot(int slotNumber)
        {
            return slotNumber >= 0 && slotNumber < toasterSlots.Length;
        }

        public virtual void CookFood()
        {
            if (isPluggedIn)
            {
                for (int slots = 0; slots < toasterSlots.Length; slots++)
                {
                    toasterSlots[slots].CookFood(heatLevel,StandardTime);
                }
            }
            else
            {
                Console.WriteLine("Toaster Is Not Plugged in!");
            }
        }
    }
}
