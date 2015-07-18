﻿using System;
using Foundation;
using MapKit;
using CoreLocation;

namespace NoddyApp
{
	public abstract class MKAnnotation : NSObject
	{
		public abstract CLLocationCoordinate2D Coordinate {
			[Export("coordinate")]
			get;
			[Export("setCoordinate:")]
			set;
		}

		public virtual string Title
		{
			[Export ("title")]
			get
			{
				throw new ModelNotImplementedException ();
			}
		}

		public virtual string Subtitle
		{
			[Export ("subtitle")]
			get
			{
				throw new ModelNotImplementedException ();
			}
		}
	}
}

