using System;

namespace NotificationsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                NotificationManager nm = new NotificationManager();

                Console.WriteLine("--------------------------");

                nm.ExcludeAddressFromSignal("14@mail.com", "second_signal");

                Console.WriteLine("--------------------------");

                nm.ExcludeAddressFromAllSignals("first_everybody@email.com");

                Console.WriteLine("--------------------------");
                nm.ProcessSignal("first_signal");
                nm.ProcessSignal("second_signal");


                Console.WriteLine("--------------------------");
                Console.WriteLine(nm.CheckIfAddressWillGetNotification("2@mail.com", "first_signal"));
                Console.WriteLine(nm.CheckIfAddressWillGetNotification("15@mail.com", "second_signal"));

                Console.WriteLine(nm.CheckIfAddressWillGetNotification("256@mail.com", "third_signal"));
                Console.WriteLine("--------------------------");

                Console.WriteLine(nm.GetListOfSupportedSignals());

                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
