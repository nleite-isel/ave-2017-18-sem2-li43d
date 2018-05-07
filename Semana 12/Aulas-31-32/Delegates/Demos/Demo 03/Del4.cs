using System;
using System.Windows.Forms;
using System.IO;


namespace Del4
{

    internal delegate void Feedback(Int32 value);


    public sealed class Program
    {
        int i;

        // Utilizacao de delegate anonimo dentro dum metodo de instancia
        // Variavel this e' capturada
        private /*static*/ void AnonymousDelegateDemo()
        {
            Console.WriteLine("----- Anonymous Delegate Demo -----");

            Counter(1, 3, delegate (int value)
            {

                Console.WriteLine("i = " + i + ", Item = " + value.ToString());
            });

            Console.WriteLine();
            /*
            //Ou:
            Feedback anonymous = delegate(int value) {
                Console.WriteLine("Item=" + value);
            };

            Counter(1, 3, anonymous);
            Console.WriteLine();
            */
        }
        private static void Counter(Int32 from, Int32 to, Feedback fb)
        {
            if (fb == null) return;

            // If any callbacks are specified, call them
            for (Int32 val = from; val <= to; val++)
                fb(val);
            // fb.Invoke(val);
        }
        private static void FeedbackToConsole(Int32 value)
        {
            Console.WriteLine("Item=" + value.ToString());
        }

        private static void FeedbackToMsgBox(Int32 value)
        {
            MessageBox.Show("Item=" + value.ToString());
        }

        private void FeedbackToFile(Int32 value)
        {
            StreamWriter sw = new StreamWriter("Status", true);
            sw.WriteLine("Item=" + value.ToString());
            sw.Close();
        }

        public static void Main1()
        {
            Program p = new Program();

            p.AnonymousDelegateDemo();
        }

    }
}

