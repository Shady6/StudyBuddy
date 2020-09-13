using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stud_bud_back.Entities
{
	public class Time
	{
		private int hours;
		private int minutes;

		public Time(int hours, int minutes)
		{
			setHours(hours);
			setMinutes(minutes);
		}

		public void setHours(int hours)
		{
			if (hours >= 0 && hours <= 23)
				this.hours = hours;
			else
				throw new ArgumentOutOfRangeException("hours", "Hours value can range from inclusive 0 to inclusive 23");
		}

		public void setMinutes(int minutes)
		{
			if (minutes >= 0 && minutes <= 59)
				this.minutes = minutes;
			else
				throw new ArgumentOutOfRangeException("minutes", "Minutes value can range from inclusive 0 to inclusive 59");
		}

		public int getHours() { return hours; }
		public int getMinutes() { return minutes; }

		public override string ToString()
		{
			return String.Format(
				"{0:00}:{1:00}",
				this.hours, this.minutes);
		}
	}
}
