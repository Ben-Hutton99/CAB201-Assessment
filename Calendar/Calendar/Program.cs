using CAB201;
using System;
using System.Collections.Generic;

namespace Calendar
{
	class Program
	{
		static Calendar calendar = new Calendar();

		const int MENU_ADD = 0, MENU_LIST_ALL = 1, MENU_LIST_ON = 2, MENU_EXIT = 3;

		static void Main()
        {
			while (true)
            {
				int option = CAB201.UserInterface.GetOption(
					"Calendar main menu",
					"Add event",
					"List all events",
					"List events on a particuar date",
					"Exit"
					);

				if(option == MENU_EXIT)
                {
					break;
                }
                else
                {
					ProcessMainMenu(option);
                }
            }
			static void ProcessMainMenu(int opt)
            {
                switch (opt)
                {
					case MENU_ADD:
						AddEvent();
						break;

					case MENU_LIST_ALL:
						ListAllEvents();
						break;

					case MENU_LIST_ON:
						ListEventsOn();
						break;

					default:
						Console.WriteLine("This is impossible");
						break;
                }
            }

			static void AddEvent() {
				string name = CAB201.UserInterface.GetInput("Please enter the event name:");
				Date date = GetDate("When is the event scheduled to take place?");
				string location = CAB201.UserInterface.GetInput("Where will the event be held?");
				Event newEvent = new Event(name, date, location);
				calendar.AddEvent(newEvent);
			}
			static void ListAllEvents() {
				List<Event> events = calendar.GetEvents();
				foreach (Event evt in events)
                {
					Console.WriteLine(evt);
                }
			}
			static void ListEventsOn() {
				Date eventDate = GetDate("Please enter the event date");

				List<Event> events = calendar.GetEventsOn(eventDate);
				foreach (Event evt in events)
				{
					Console.WriteLine(evt);
				}

			}
		}

		/// <summary>
		/// Promps the user to enter a date and returns a valid date object within the results
		/// </summary>
		/// <param name="prompt">a prompt that will be used to get the input</param>
		/// <returns>A valid date object containing the users response</returns>
        static Date GetDate(string prompt)
        {
            while (true)
            {
                string UserInput = UserInterface.GetInput(prompt);
                string[] fields = UserInput.Split('/');

                if (fields.Length != 3)
                {
                    UserInterface.Error("Expected a date, in the form dd/mm/yyy");
                }
                else
                {
                    int day, month, year;

                    //parse day, month and year
                    if (int.TryParse(fields[0], out day)
                        && int.TryParse(fields[1], out month)
                        && int.TryParse(fields[2], out year)
                        )//There are 3 integer values
                    {
                        if (Date.IsValid(day, month, year))
                        {
                            return new Date(day, month, year);
                        }
                        else
                        {
                            UserInterface.Error("Please supply a valid date.");
                        }
                    }
                    else
                    {
                        UserInterface.Error("Day, month, and year must be numeric");
                    }
                }
            }
        }

        static void Main_00( string[] args ) {
			Console.WriteLine( "Hello World!" );

			Date today = new Date(7,9,2021);
			Date newYearsDay = new Date(1,1,2022);

			Console.WriteLine( $"Today is {today}" );
			Console.WriteLine( $"New years day is {newYearsDay}" );

			Event newYearsEvent = new Event("New Years Celebration", newYearsDay, "South bank park lands");

			Console.WriteLine( $"new years event is: {newYearsEvent}" );

			calendar.AddEvent( new Event( "An humble and undeserving person's birthday",
				new Date( 7, 5, 2022 ), "At uni somewhere" ) );
			calendar.AddEvent( new Event( "New years day",
				new Date( 1, 1, 2022 ), "On the beach" ) );
			calendar.AddEvent( new Event( "Exams start",
				new Date( 5, 11, 2021 ), "Freaking out at uni somewhere" ) );

			Console.WriteLine();
			Console.WriteLine( "Here are the events in the calendar" );
			List<Event> allEvents = calendar.GetEvents();

			foreach (Event evt in allEvents) {
				Console.WriteLine( evt );
				Console.WriteLine();
			}
		}
	}
}
