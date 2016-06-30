using System;
using System.Linq;
using System.Management;

namespace change_ip
{
    class change_ip
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input current IP Address");
            String current_ip = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Input new IP Address");
            String new_ip = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Input Subnet Mask");
            String subnet_mask = Console.ReadLine();
            Console.WriteLine();
            try
            {
                if (ChangeIPAddress(current_ip, new_ip, subnet_mask) == true)
                {
                    Console.WriteLine("IP Address Changed : " + current_ip + " -> " + new_ip);
                }
                else
                {
                    Console.WriteLine("IP Address Change Failure!");
                }
            }
            catch( Exception e )
            {
                Console.WriteLine( "Catch Exception ! Message = " + e.Message);
            }
            Console.ReadLine(); // Push Return-key to End
        }

        static bool ChangeIPAddress( String CurrentIP, String NewIP, String SubnetMask )
        {
            bool rc = false;
            String query_str = "SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled=TRUE";

			using (ManagementObjectSearcher management_obj_searcher = new ManagementObjectSearcher(query_str))
			{
				using (ManagementObjectCollection management_obj_collection = management_obj_searcher.Get())
				{
					foreach (ManagementObject management_obj in management_obj_collection)
					{
						if (management_obj["IPAddress"] != null)
						{
							for (int i = 0; i < ((String[])management_obj["IPAddress"]).Count(); i++)
							{
								if (((String[])management_obj["IPAddress"])[i] == CurrentIP)
								{
									// Find Currrent IP Address
									try
									{
										using (ManagementBaseObject management_base_obj = management_obj.GetMethodParameters("EnableStatic"))
										{
											management_base_obj["IPAddress"] = new string[] { NewIP };
											management_base_obj["SubnetMask"] = new string[] { SubnetMask };
											management_obj.InvokeMethod("EnableStatic", management_base_obj, null);
										}
									}
									catch (Exception e_ChangeIPAddress)
									{
										throw e_ChangeIPAddress;
									}
									rc = true;
									break;
								}
							}
						}
						if (rc == true)
						{
							break;
						}
					}
				}
			}
			return (rc);
        }
    }
}
