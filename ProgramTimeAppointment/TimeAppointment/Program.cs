using AppointmentClass;
using TimeClass;

namespace Verifica_2023_10_20_Francia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try{
                Appointment appointmentFirst = new Appointment(8, 5, 0, 12, 57, 0);
                Appointment appointmentSecond = new Appointment(8, 5, 0, 13, 57, 0);

                if (appointmentFirst.VerifyMoreLonger(appointmentSecond))
                {
                    Console.WriteLine("the first appointment is more long as the second");
                }else
                {
                    Console.WriteLine("the second appointment is more long as the first");
                }




                if (appointmentFirst.TimeStart.Hours > appointmentSecond.TimeStart.Hours)
                {
                    if (appointmentFirst.TimeStart.Minutes > appointmentSecond.TimeStart.Minutes)
                    {
                        if (appointmentFirst.TimeStart.Seconds > appointmentSecond.TimeStart.Seconds)
                        {
                            Console.WriteLine("the first appointment start affter the second");
                        }
                    }
                }


                if(appointmentFirst.VerifyOvernyng(appointmentSecond)) 
                {
                    Console.WriteLine("the appointments are overnyng");
                }

            }
            catch(Exception e) 
            {
                throw e;
            }
        }
    }
}