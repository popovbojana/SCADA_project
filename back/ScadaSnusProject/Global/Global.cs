namespace ScadaSnusProject.Global;


    public class DigitalGlobalValues
    {
        public static string OpenClosedDescription { get; private set; }
        public static bool Open { get; private set; }
        public static string OnOffDescription { get; private set; }
        public static bool On { get; private set; }

        static DigitalGlobalValues()
        {
            OpenClosedDescription = "Tank state whether its open or close";
            Open = true;
            OnOffDescription = "Tanke state whether its on or off";
            On = true;
        }
    }


    public class AnalogGlobalValues
    {
        public static string TemperatureDescription { get; private set; }
        public static int TemperatureValue { get; private set; }
        public static int TemperatureMinValue { get; private set; }
        public static int TemperatureMaxValue { get; private set; }
        public static string C { get; private set; }
        public static string DepthDescription { get; private set; }
        public static int DepthValue { get; private set; }
        public static int DepthMinValue { get; private set; }
        public static int DepthMaxValue { get; private set; }
        public static string M { get; private set; }
        public static string DensityDescription { get; private set; }
        public static int DensityValue { get; private set; }
        public static int DensityMinValue { get; private set; }
        public static int DensityMaxValue { get; private set; }
        public static string KgM3 { get; private set; }
        
        static AnalogGlobalValues()
        {
            TemperatureDescription = "Tank temperature";
            TemperatureValue = 50;
            TemperatureMinValue = 1;
            TemperatureMaxValue = 99;
            C = "C";

            DepthDescription = "Tank depth";
            DepthValue = 35;
            DepthMinValue = 20;
            DepthMaxValue = 50;
            M = "M";

            DensityDescription = "Tank density";
            DensityValue = 1000;
            DensityMinValue = 900;
            DensityMaxValue = 1100;
            KgM3 = "Kg/m**3";

        }
    }