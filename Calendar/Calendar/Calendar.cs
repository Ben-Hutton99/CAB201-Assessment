using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
	class Calendar
	{
		private List<Event> events = new List<Event>();

		public void AddEvent( Event newEvent ) {
			events.Add( newEvent );
		}

		public List<Event> GetEvents() {
			List<Event> results = new List<Event>();

			foreach( Event evt in events) {
				results.Add( evt );
			}

			return results;
		}


		public List<Event> GetEventsOn( Date date) {
			List<Event> results = new List<Event>();

			foreach( Event evt in events) {
				Date evtDate = evt.Date;

				if (evtDate.Day == date.Day && evtDate.Month == date.Month && evtDate.Year == date.Year) {
					results.Add( evt );
				}
			}

			return results;
		}

	}
}
