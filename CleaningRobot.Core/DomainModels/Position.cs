namespace CleaningRobot.Core
{
	public class Position
	{
		public int X
		{
			get { return _x; }
			set
			{
				if(value < DataRestrictions.XMinValue)
				{
					_x = DataRestrictions.XMinValue;
				}
				else if (value > DataRestrictions.XMaxValue)
				{
					_x = DataRestrictions.XMaxValue;
				}
				else
				{
					_x = value;
				}
			}
		}

		public int Y
		{
			get { return _y; }
			set
			{
				if (value < DataRestrictions.YMinValue)
				{
					_y = DataRestrictions.YMinValue;
				}
				else if (value > DataRestrictions.YMaxValue)
				{
					_y = DataRestrictions.YMaxValue;
				}
				else
				{
					_y = value;
				}
			}
		}

		private int _x { get; set; }
		private int _y { get; set; }

		public override bool Equals(object obj)
		{
			var that = (Position)obj;
			return ((_x == that.X) && (_y == that.Y));
		}

		public override int GetHashCode()
		{
			return _x.GetHashCode() * 17 + _y.GetHashCode();
		}
	}
}
