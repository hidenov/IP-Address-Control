using System;
using System.Linq;
using System.Management;

namespace show_net_adapter
{
	class show_net_adapter
    {
		static void Main(string[] args)
		{
            int obj_count = 0;
			String query_str = "SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled=TRUE";

			using (ManagementObjectSearcher management_obj_searcher = new ManagementObjectSearcher(query_str))
			{
				using (ManagementObjectCollection management_obj_collection = management_obj_searcher.Get())
				{
					Console.Write("Whole Network Adapter Parameter\r\n\r\n");
					foreach (ManagementObject management_obj in management_obj_collection)
					{
						Console.WriteLine("Caption : " + management_obj["Caption"]);
						Console.WriteLine("Description : " + management_obj["Description"]);
						Console.WriteLine("SettingID : " + management_obj["SettingID"]);
						Console.WriteLine("ArpAlwaysSourceRoute : " + management_obj["ArpAlwaysSourceRoute"]);
						Console.WriteLine("ArpUseEtherSNAP : " + management_obj["ArpUseEtherSNAP"]);
						Console.WriteLine("DatabasePath : " + management_obj["DatabasePath"]);
						Console.WriteLine("DeadGWDetectEnabled : " + management_obj["DeadGWDetectEnabled"]);
						WriteLine<String>(management_obj, "DefaultIPGateway");
						Console.WriteLine("DefaultTOS : " + management_obj["DefaultTOS"]);
						Console.WriteLine("DefaultTTL : " + management_obj["DefaultTTL"]);
						Console.WriteLine("DHCPEnabled : " + management_obj["DHCPEnabled"]);
						Console.WriteLine("DHCPLeaseExpires : " + management_obj["DHCPLeaseExpires"]);
						Console.WriteLine("DHCPLeaseObtained : " + management_obj["DHCPLeaseObtained"]);
						Console.WriteLine("DHCPServer : " + management_obj["DHCPServer"]);
						Console.WriteLine("DNSDomain : " + management_obj["DNSDomain"]);
						WriteLine<String>(management_obj, "DNSDomainSuffixSearchOrder");
						Console.WriteLine("DNSEnabledForWINSResolution : " + management_obj["DNSEnabledForWINSResolution"]);
						WriteLine<String>(management_obj, "DNSServerSearchOrder");
						Console.WriteLine("DomainDNSRegistrationEnabled : " + management_obj["DomainDNSRegistrationEnabled"]);
						Console.WriteLine("ForwardBufferMemory : " + management_obj["ForwardBufferMemory"]);
						Console.WriteLine("FullDNSRegistrationEnabled : " + management_obj["FullDNSRegistrationEnabled"]);
						WriteLine<UInt16>(management_obj, "GatewayCostMetric");
						Console.WriteLine("IGMPLevel : " + management_obj["IGMPLevel"]);
						Console.WriteLine("Index : " + management_obj["Index"]);
						Console.WriteLine("InterfaceIndex : " + management_obj["InterfaceIndex"]);
						WriteLine<String>(management_obj, "IPAddress");
						Console.WriteLine("IPConnectionMetric : " + management_obj["IPConnectionMetric"]);
						Console.WriteLine("IPEnabled : " + management_obj["IPEnabled"]);
						Console.WriteLine("IPFilterSecurityEnabled : " + management_obj["IPFilterSecurityEnabled"]);
						Console.WriteLine("IPPortSecurityEnabled : " + management_obj["IPPortSecurityEnabled"]);
						WriteLine<String>(management_obj, "IPSecPermitIPProtocols");
						WriteLine<String>(management_obj, "IPSecPermitTCPPorts");
						WriteLine<String>(management_obj, "IPSecPermitUDPPorts");
						WriteLine<String>(management_obj, "IPSubnet");
						Console.WriteLine("IPUseZeroBroadcast : " + management_obj["IPUseZeroBroadcast"]);
						Console.WriteLine("IPXAddress : " + management_obj["IPXAddress"]);
						Console.WriteLine("IPXEnabled : " + management_obj["IPXEnabled"]);
						WriteLine<String>(management_obj, "IPXFrameType");
						Console.WriteLine("IPXMediaType : " + management_obj["IPXMediaType"]);
						WriteLine<String>(management_obj, "IPXNetworkNumber");
						Console.WriteLine("IPXVirtualNetNumber : " + management_obj["IPXVirtualNetNumber"]);
						Console.WriteLine("KeepAliveInterval : " + management_obj["KeepAliveInterval"]);
						Console.WriteLine("KeepAliveTime : " + management_obj["KeepAliveTime"]);
						Console.WriteLine("MACAddress : " + management_obj["MACAddress"]);
						Console.WriteLine("MTU : " + management_obj["MTU"]);
						Console.WriteLine("NumForwardPackets : " + management_obj["NumForwardPackets"]);
						Console.WriteLine("PMTUBHDetectEnabled : " + management_obj["PMTUBHDetectEnabled"]);
						Console.WriteLine("PMTUDiscoveryEnabled : " + management_obj["PMTUDiscoveryEnabled"]);
						Console.WriteLine("ServiceName : " + management_obj["ServiceName"]);
						Console.WriteLine("TcpipNetbiosOptions : " + management_obj["TcpipNetbiosOptions"]);
						Console.WriteLine("TcpMaxConnectRetransmissions : " + management_obj["TcpMaxConnectRetransmissions"]);
						Console.WriteLine("TcpMaxDataRetransmissions : " + management_obj["TcpMaxDataRetransmissions"]);
						Console.WriteLine("TcpNumConnections : " + management_obj["TcpNumConnections"]);
						Console.WriteLine("TcpUseRFC1122UrgentPointer : " + management_obj["TcpUseRFC1122UrgentPointer"]);
						Console.WriteLine("TcpWindowSize : " + management_obj["TcpWindowSize"]);
						Console.WriteLine("WINSEnableLMHostsLookup : " + management_obj["WINSEnableLMHostsLookup"]);
						Console.WriteLine("WINSHostLookupFile : " + management_obj["WINSHostLookupFile"]);
						Console.WriteLine("WINSPrimaryServer : " + management_obj["WINSPrimaryServer"]);
						Console.WriteLine("WINSScopeID : " + management_obj["WINSScopeID"]);
						Console.WriteLine("WINSSecondaryServer : " + management_obj["WINSSecondaryServer"]);
						Console.Write("\r\n--------\r\n");
						obj_count++;
					}
				}
			}
            Console.WriteLine("Network Adapter Count = " + obj_count );
			Console.ReadLine(); // Push Return-Key to End
		}

		static private void WriteLine<T>(ManagementObject Obj, String Indexer)
		{
			if (Obj[Indexer] != null)
			{
				for (int i = 0; i < ((T[])Obj[Indexer]).Count(); i++)
				{
					Console.WriteLine(Indexer + " : " + ((T[])Obj[Indexer])[i]);
				}
			}
			else
			{
				Console.WriteLine(Indexer + " : null");
			}
		}
	}
}
