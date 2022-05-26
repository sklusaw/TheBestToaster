using TestApp.FoodClasses.ToastClasses;

namespace TestApp.FoodClasses
{
    public abstract class FoodBase
    {
        private ToastLevel toastLevel;
        private int cookSpeed;
        private int currentCookedLevelTop;
        private int currentCookedLevelBottom;


        public FoodBase()
        {
            cookSpeed = 1;
            toastLevel = new ToastLevel();
        }
        public FoodBase(ToastLevel toastLevel)
        {
            cookSpeed = 1;
            this.toastLevel = toastLevel;
        }

        internal void Cook(int cookHeat)
        {
            currentCookedLevelTop += cookSpeed * cookHeat;
            currentCookedLevelBottom += cookSpeed * cookHeat;
        }
        internal void Cook(int cookHeat, bool isOneSided)
        {
            // Factor One Sided Cooking
            if(isOneSided == false)
            {
                currentCookedLevelBottom += cookSpeed * cookHeat;
            }
            currentCookedLevelTop += cookSpeed * cookHeat;
        }

        public string GetToastLevelTop()
        { 
            return GetToastLevel(currentCookedLevelTop); 
        }

        public string GetToastLevelBottom()
        {
            return GetToastLevel(currentCookedLevelBottom);
        }

        public string GetToastLevel(int currentCookedLevel)
        {
            if (currentCookedLevel >= toastLevel.NotToasted && currentCookedLevel < toastLevel.SomeBrown)
            {
                return "Not Toasted";
            }
            else if (currentCookedLevel >= toastLevel.SomeBrown && currentCookedLevel < toastLevel.MediumBrown)
            {
                return "Some Browning";
            }
            else if (currentCookedLevel >= toastLevel.MediumBrown && currentCookedLevel < toastLevel.VeryBrown)
            {
                return "Medium Browning";
            }
            else if (currentCookedLevel >= toastLevel.VeryBrown && currentCookedLevel < toastLevel.Burnt)
            {
                return "Very Brown";
            }

            return "Burnt";

        }
    }
}
