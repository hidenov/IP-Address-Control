using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sense_unplug_evlog
{
	class sense_unplug_evlog
	{
		static void Main(string[] args)
		{
			using( EventLog event_log = new EventLog("System", "."))
			{
				event_log.EntryWritten += new EntryWrittenEventHandler( OnEvlogEntryWritten );
				event_log.EnableRaisingEvents = true;
				Console.Read(); // Push Return-key to End
				event_log.Close();
			}
		}

		public static void OnEvlogEntryWritten(object source, EntryWrittenEventArgs e)
		{
			EventLogEntry event_log_entry = e.Entry;

// "e1express" is suitable for 'Intel(R) PRO/1000 PT Server Adapter' only.
// You should change to suitable word if you using other NIC card.
			if( event_log_entry.Source == "e1express" )
			{
				if( event_log_entry.EntryType == EventLogEntryType.Warning )
				{
					Console.WriteLine( "Disconnect : " + event_log_entry.Message );
				}
				else
				{
					if( event_log_entry.EntryType == EventLogEntryType.Information )
					{
						Console.WriteLine( "Connect : " + event_log_entry.Message );
					}
				}
			}
		}
	}
}
