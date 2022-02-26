using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
	class Event
	{
		private string name;
		private Date date;

		// TODO: change to Address
		private string location;

		public Event( string name, Date date, string location) {
			this.name = name;
			this.date = date;
			this.location = location;
		}

		public string Name { 
			get { return name; }
		}

		public Date Date {
			get { return date; }
		}

		public string Location {
			get { return location; }
		}

		public override string ToString() {
			return $"{name}{Environment.NewLine}{date}{Environment.NewLine}{location}";
		}
	}
}
