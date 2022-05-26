namespace TestApp.FoodClasses.ToastClasses
{
    public class ToastLevel
    {

        private int notToasted;
        private int someBrown;
        private int mediumBrown;
        private int veryBrown;
        private int burnt;

        public ToastLevel()
        {
            NotToasted = 0;
            SomeBrown = 5;
            MediumBrown = 10;
            VeryBrown = 20;
            Burnt = 30;
        }

        public ToastLevel(int notToasted, int someBrown, int mediumBrown, int veryBrown, int burnt)
        {
            this.notToasted = notToasted;
            this.someBrown = someBrown;
            this.mediumBrown = mediumBrown;
            this.veryBrown = veryBrown;
            this.burnt = burnt;
        }

        public int Burnt { get => burnt; set => burnt = value; }
        public int VeryBrown { get => veryBrown; set => veryBrown = value; }
        public int MediumBrown { get => mediumBrown; set => mediumBrown = value; }
        public int SomeBrown { get => someBrown; set => someBrown = value; }
        public int NotToasted { get => notToasted; set => notToasted = value; }
    }
}
