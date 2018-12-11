namespace CleaningRobot.Core
{
	public class Position
	{
		public int X { get; set; }

		public int Y { get; set; }

		public override bool Equals(object obj)
		{
			var that = (Position)obj;
			return ((X == that.X) && (Y == that.Y));
		}

		public override int GetHashCode()
		{
			return X.GetHashCode() * 17 + Y.GetHashCode();
		}
	}
}
