using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Instruments
    {
        public static Random rnd = new Random();
        public virtual String GetInfo()
        {
            var str = "Я музыкальный инструмент";
            return str;
        }
    }


    public enum StringsLine {Classic, Reduced, Open, Drop};
    public class Strings : Instruments
    {
        public int StringCount = 0;
        public StringsLine line = StringsLine.Classic;

        public override String GetInfo()
        {
            var str = "Я струнный инструмент";
            str += String.Format("\nКолличество струн: {0}", this.StringCount);
            str += String.Format("\nСтрой: {0}", this.line);
            return str;
        }
        public static Strings Generate()
        {
            return new Strings
            {
                StringCount = 1 + rnd.Next() % 18,
                line = (StringsLine)rnd.Next(4)
            };
        }
    }

    public class Keyboards : Instruments
    {
        public int KeyCount = 0;
        public int OctaveCount = 0;
        public override String GetInfo()
        {
            var str = "Я клавишный инструмент";
            str += String.Format("\nКолличество клавиш: {0}", this.KeyCount);
            str += String.Format("\nКолличество полных октав: {0}", this.OctaveCount);
            return str;
        }
        public static Keyboards Generate()
        {
            return new Keyboards
            {
                KeyCount = 55 + rnd.Next() % 36,
                OctaveCount = 2 + rnd.Next() % 9
            };
        }
    }

    public enum DrumType {Classic, Bongo, Kick, Plate};
    public class Drums : Instruments 
    {
        public int Radius = 0;
        public DrumType Type = DrumType.Classic;
        public override String GetInfo()
        {
            var str = "Я ударный инструмент";
            str += String.Format("\nРадиус удар. поверхности: {0}", this.Radius);
            str += String.Format("\nТип: {0}", this.Type);
            return str;
        }
        public static Drums Generate()
        {
            return new Drums
            {
                Radius = 200 + rnd.Next() % 801,
                Type = (DrumType)rnd.Next(4)
            };
        }

    }
}