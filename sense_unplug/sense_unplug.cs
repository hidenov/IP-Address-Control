using System;
using System.Net.NetworkInformation;

namespace sense_unplug
{
    class sense_unplug
    {
        static void Main(string[] args)
        {
            // Add Delegete ( Network Availability Changed )
            NetworkChange.NetworkAvailabilityChanged += NetworkChange_NetworkAvailabilityChanged;
            // Add Delegete ( IP Address Changed )
            NetworkChange.NetworkAddressChanged += NetworkChange_NetworkAddressChanged;
            Console.ReadLine();
        }

        static private void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            if (e.IsAvailable)
            {
                Console.WriteLine("Network Connection to Enabled");
            }
            else
            {
                Console.WriteLine("Network Connection to Disabled");
            }
        }

        static private void NetworkChange_NetworkAddressChanged(object sender, EventArgs e)
        {
            Console.WriteLine("IPAddress Changed!");
        }
    }
}
