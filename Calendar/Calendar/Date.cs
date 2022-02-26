using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
	class Date
	{
		private int year, month, day;

		public Date( int day, int month, int year) {
			Year = year;
			Month = month;
			Day = day;
		}

		public int Year {
			get { return year; }
			set {
				if (value <= 0) {
					Console.WriteLine( "Bad year" );
					return;
				}

				year = value;
			}
		}

		public int Month {
			get { return month; }
			set {
				if (value < 1 || value > 12) {
					Console.WriteLine( "Bad month" );
					return;
				}

				month = value;
			}
		}

		public int Day {
			get { return day; }
			set {
				int [] days30 = { 9, 4, 6, 11 };
				int [] days31 = { 1, 3, 5, 7, 8, 10, 12};
				bool ok = true;

				if (value < 1) 
					ok = false;
				else if (days30.Contains( month ) && value > 30)
					ok = false;
				else if (days31.Contains( month ) && value > 31) 
					ok = false;
				else if (month == 2) {
					if (IsLeapYear( year )) {
						if (value > 29) ok = false;
					}
					else {
						if (value > 28) ok = false;
					}
				}

				if ( ! ok ) {
					Console.WriteLine("Bad day");
					return;
				}

				day = value;
			}
		}

		static bool IsLeapYear( int year ) {
			if (year % 400 == 0) return true;
			if (year % 100 == 0) return false;
			if (year % 4 == 0) return true;
			return false;
		}

		static public bool IsValid(int day, int month, int year)
        {
			if (year < 1) return false;
			if (month < 1) return false;
			if (month > 12) return false;

			int[] days30 = { 9, 4, 6, 11 };
			int[] days31 = { 1, 3, 5, 7, 8, 10, 12 };

			if (day < 1)
				return false;
			else if (days30.Contains(month) && day > 30)
				return false;
			else if (days31.Contains(month) && day > 31)
				return false;
			else if (month == 2)
			{
				if (IsLeapYear(year))
				{
					if (day > 29) return false;
				}
				else
				{
					if (day > 28) return false;
				}
			}
			return true;
		}

		public override string ToString() {
			return $"{day}/{month}/{year}";
		}
	}
}
