using System;

using UIKit;
using MapKit;
using CoreLocation;

namespace NoddyApp
{
	public partial class ViewController : UIViewController
	{
		private MKMapView _map;

		public ViewController (IntPtr handle) : base (handle)
		{
			_map = new MKMapView (View.Bounds);
			_map.AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;
			View.AddSubview (_map);
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			var sampleCoordinate = new CLLocationCoordinate2D (42.3467512, -71.0969456);
			_map.AddAnnotation (new MapAnnotation (sampleCoordinate));

			_map.DidSelectAnnotationView += (s,e) => {
				var annotation = e.View.Annotation as MapAnnotation;
				if (annotation != null) {
					//demo accessing the coordinate of the selected annotation to
					//zoom in on it
					_map.Region = MKCoordinateRegion.FromDistance (
						annotation.Coordinate, 500, 500);

					//demo accessing the title of the selected annotation
					Console.WriteLine ("{0} was tapped", annotation.Title);
				}
			};
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}


	}
}

