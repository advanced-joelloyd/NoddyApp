using System;
using CoreLocation;

namespace NoddyApp
{
	public class MapAnnotation : MKAnnotation
	{
		private readonly string _title;

		public MapAnnotation (CLLocationCoordinate2D coordinate)
		{
			this.Coordinate = coordinate;
			this._title = "It's a test.";
		}
			
		public override CLLocationCoordinate2D Coordinate {
			get;
			set;
		}

		public override string Title {
			get {
				return this._title;
			}
		}	
	}
}

