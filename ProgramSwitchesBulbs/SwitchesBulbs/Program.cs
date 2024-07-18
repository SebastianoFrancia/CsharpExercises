using System.Diagnostics;
using SwitchesClass;

namespace SwitchBulbs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try{
                Switches One = new Switches();
                Switches Tow = new Switches();

                Random rdn = new Random();
                int numClick = rdn.Next();

                for(int i = 0; i<numClick; i++)
                {
                    One.Status(true);
                    Tow.Status(true);
                    One.Status(false);
                    Tow.Status(false);
                }

            }catch(Exception ex){
                throw ex;
            }
        }
    }
}