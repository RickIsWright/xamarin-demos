#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
using Syncfusion.SfBusyIndicator.iOS;


#endregion
using System;
using Syncfusion.SfMaps.iOS;
using System.Collections.ObjectModel;
#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using nint = System.Int32;
using nuint = System.Int32;
using CGPoint= System.Drawing.PointF;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
using nfloat  = System.Single;
#endif

namespace SampleBrowser
{
	public class ColorMapping: SampleView
	{
		internal SfBusyIndicator busyindicator;
		UIView view;
		UILabel label;
		SFShapeFileLayer layer;
        bool isDisposed;

		public override void LayoutSubviews ()
		{
			view.Frame =  new CGRect(Frame.Location.X,0.0f,Frame.Size.Width,Frame.Size.Height);
			busyindicator.Frame =  new CGRect(Frame.Location.X,0.0f,Frame.Size.Width,Frame.Size.Height);;
			label.Frame=new CGRect(0f,0f,Frame.Size.Width,40);
			SetNeedsDisplay ();
		}
        protected override void Dispose(bool disposing)
        {
            isDisposed = true;
            base.Dispose(disposing);
        }
        public ColorMapping ()
		{
			SFMap	maps = new SFMap ();
			view = new UIView ();
			busyindicator = new SfBusyIndicator();
			busyindicator.ViewBoxWidth=75;
			busyindicator.ViewBoxHeight=75;
			busyindicator.Foreground=  UIColor.FromRGB (0x77, 0x97, 0x72);  /*#779772*/
			busyindicator.AnimationType=SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeSlicedCircle;
			view.AddSubview (busyindicator);

			NSTimer.CreateScheduledTimer (TimeSpan.FromSeconds (0.3), delegate {
                if (isDisposed)
                    return;
				maps.Frame = new CGRect(0,0,Frame.Size.Width,Frame.Size.Height);

				view.AddSubview (maps);
			});
			view.Frame=new CGRect(0,0,300,400);
			label = new UILabel ();
			label.TextAlignment = UITextAlignment.Center;
			label.Text = "Primary Agricultural Activity of USA";
			label.Font = UIFont.SystemFontOfSize (18);
			label.Frame=new  CGRect(0,0,300,40);
			label.TextColor = UIColor.Black;
			view.AddSubview (label);

			layer = new SFShapeFileLayer();
			layer.Uri = (NSString)NSBundle.MainBundle.PathForResource ("usa_state", "shp");
			layer.DataSource = GetDataSource ();
			SetColorMapping(layer.ShapeSettings);
			layer.ShapeSettings.ColorValuePath =(NSString)"Type";
			layer.ShapeSettings.StrokeColor = UIColor.White;
			layer.LegendSettings = new SFMapLegendSettings ();
            layer.LegendSettings.Position = new CGPoint (50, 10);
			layer.LegendSettings.ShowLegend = true;
            maps.Layers.Add (layer);
            maps.Delegate = new MapsColorMappingDelegate (this);
            AddSubview (view);

            ColorMappingTooltipSetting tooltipSetting = new ColorMappingTooltipSetting();
            tooltipSetting.ShowTooltip = true;
            layer.TooltipSettings = tooltipSetting;
        }

		NSMutableArray GetDataSource()
		{
			NSMutableArray array = new NSMutableArray ();

			array.Add(getDictionary("Alabama" , "Vegetables" , 42));
			array.Add(getDictionary( "Alaska" , "Vegetables" , 0 ));
			array.Add(getDictionary( "Arizona" , "Rice" , 36 ));
			array.Add(getDictionary( "Arkansas" , "Vegetables" , 46 ));
			array.Add(getDictionary( "California" , "Rice" , 24 ));
			array.Add(getDictionary( "Colorado" , "Rice" , 31));
			array.Add(getDictionary( "Connecticut" , "Grains" , 18 ));
			array.Add(getDictionary( "Delaware" , "Grains" , 28 ));
			array.Add(getDictionary( "District of Columbia" , "Grains" , 27 ));
			array.Add(getDictionary( "Florida" , "Rice" , 48 ));
			array.Add(getDictionary( "Georgia" , "Rice" , 44));
			array.Add(getDictionary( "Hawaii" , "Grains" , 49 ));
			array.Add(getDictionary( "Idaho" , "Grains" , 8 ));
			array.Add(getDictionary( "Illinois" , "Vegetables" , 26 ));
			array.Add(getDictionary( "Indiana" , "Grains" , 21 ));
			array.Add(getDictionary( "Iowa" , "Vegetables" , 13 ));
			array.Add(getDictionary( "Kansas" , "Rice" , 33 ));
			array.Add(getDictionary( "Kentucky" , "Grains" , 32 ));
			array.Add(getDictionary( "Louisiana" , "Rice" , 47 ));
			array.Add(getDictionary( "Maine" , "Grains" , 3 ));
			array.Add(getDictionary( "Maryland" , "Grains" , 30 ));
			array.Add(getDictionary( "Massachusetts" , "Grains" , 14 ));
			array.Add(getDictionary( "Michigan" , "Grains" , 50 ));
			array.Add(getDictionary( "Minnesota" , "Wheat" , 10 ));
			array.Add(getDictionary( "Mississippi" , "Vegetables" , 43 ));
			array.Add(getDictionary( "Missouri" , "Vegetables" , 35 ));
			array.Add(getDictionary( "Montana" , "Grains" , 2 ));
			array.Add(getDictionary( "Nebraska" , "Rice" , 15 ));
			array.Add(getDictionary( "Nevada" , "Wheat" , 22 ));
			array.Add(getDictionary( "New Hampshire" , "Grains" , 12 ));
			array.Add(getDictionary( "New Jersey" , "Vegetables" , 20 ));
			array.Add(getDictionary( "New Mexico" , "Rice" , 41 ));
			array.Add(getDictionary( "New York" , "Vegetables" , 16 ));
			array.Add(getDictionary( "North Carolina" , "Rice" , 38 ));
			array.Add(getDictionary( "North Dakota" , "Grains" , 4 ));
			array.Add(getDictionary( "Ohio" , "Vegetables" , 25 ));
			array.Add(getDictionary( "Oklahoma" , "Rice" , 37 ));
			array.Add(getDictionary( "Oregon" , "Wheat" , 11 ));
			array.Add(getDictionary( "Pennsylvania" , "Vegetables" , 17 ));
			array.Add(getDictionary( "Rhode Island" , "Grains" , 19 ));
			array.Add(getDictionary( "South Carolina" , "Rice" , 45 ));
			array.Add(getDictionary( "South Dakota" , "Grains" , 5 ));
			array.Add(getDictionary( "Tennessee" , "Vegetables" , 39 ));
			array.Add(getDictionary( "Texas" , "Vegetables" , 40 ));
			array.Add(getDictionary( "Utah" , "Rice" , 23 ));
			array.Add(getDictionary( "Vermont" , "Grains" , 9 ));
			array.Add(getDictionary( "Virginia" , "Rice" , 34 ));
			array.Add(getDictionary( "Washington" , "Vegetables" , 1 ));
			array.Add(getDictionary( "West Virginia" , "Grains" , 29 ));
			array.Add(getDictionary( "Wisconsin" , "Grains" , 7 ));
			array.Add(getDictionary( "Wyoming" , "Wheat" , 6 ));
			return array;
		}

		NSDictionary getDictionary(string name,string type,int index)
		{
			NSString name1= (NSString)name;
			object[] objects= new object[3];
			object[] keys=new object[3];
			keys.SetValue ("Country", 0);
			keys.SetValue ("index", 1);
			keys.SetValue ("Type", 2);
			objects.SetValue (name1, 0);
			objects.SetValue (index, 1);
			objects.SetValue (type, 2);
			return NSDictionary.FromObjectsAndKeys (objects, keys);
		}

		void SetColorMapping(SFShapeSetting setting)
		{
            ObservableCollection<SFMapColorMapping> colorMappings = new ObservableCollection<SFMapColorMapping> ();
			SFEqualColorMapping colorMapping1= new SFEqualColorMapping();
			colorMapping1.Value= (NSString)"Rice";
			colorMapping1.LegendLabel= (NSString)"Rice";
            colorMapping1.Color = UIColor.FromRGB(0xFD, 0x8C, 0x48);
			colorMappings.Add(colorMapping1);

			SFEqualColorMapping colorMapping2= new SFEqualColorMapping();
			colorMapping2.Value=(NSString) "Grains";
			colorMapping2.LegendLabel= (NSString)"Grains";
            colorMapping2.Color = UIColor.FromRGB(0x3A, 0x99, 0xD9);
			colorMappings.Add(colorMapping2);

			SFEqualColorMapping colorMapping3= new SFEqualColorMapping();
			colorMapping3.Value=(NSString) "Wheat";
			colorMapping3.LegendLabel= (NSString)"Wheat";
			colorMapping3.Color =UIColor.FromRGB (0xE5, 0x4D, 0x42);
			colorMappings.Add(colorMapping3);

			SFEqualColorMapping colorMapping4= new SFEqualColorMapping();
			colorMapping4.Value= (NSString)"Vegetables";
			colorMapping4.LegendLabel= (NSString)"Vegetables";
            colorMapping4.Color = UIColor.FromRGB(0x29, 0xBB, 0x9C);
			colorMappings.Add(colorMapping4);

			setting.ColorMappings = colorMappings;
		}
	}

	public class MapsColorMappingDelegate:SFMapsDelegate
	{
		public MapsColorMappingDelegate(ColorMapping sample)
		{
			mapping= sample;
		}
		ColorMapping mapping;

		public override void DidLoad (SFMap map)
		{
			if (mapping.busyindicator != null) {
				mapping.busyindicator.RemoveFromSuperview ();
				mapping.busyindicator = null;
			}
		}
     }

    public class ColorMappingTooltipSetting : TooltipSetting
    {
        public ColorMappingTooltipSetting()
        {

        }

        public override UIView GetView(object shapeData)
        {
            NSDictionary dic = (NSDictionary)shapeData;

            UIView view = new UIView();
            NSString topText = (NSString)(dic["Country"]);
            NSString bottomText = (NSString)(dic["Type"]);

            UILabel topLabel = new UILabel();
            topLabel.Text = topText;
            topLabel.Font = UIFont.SystemFontOfSize(12);
            topLabel.TextColor = UIColor.White;
            topLabel.TextAlignment = UITextAlignment.Center;

            UILabel bottomLabel = new UILabel();
            bottomLabel.Text = bottomText;
            bottomLabel.Font = UIFont.SystemFontOfSize(12);
            bottomLabel.TextColor = UIColor.White;
            bottomLabel.TextAlignment = UITextAlignment.Center;

            view.AddSubview(topLabel);
            view.AddSubview(bottomLabel);

            CGSize expectedLabelSize1 = topText.GetSizeUsingAttributes(new UIStringAttributes() { Font = topLabel.Font });
            CGSize expectedLabelSize2 = bottomText.GetSizeUsingAttributes(new UIStringAttributes() { Font = bottomLabel.Font });

            view.Frame = new CGRect(0.0f, 0.0f, Math.Max(expectedLabelSize1.Width, expectedLabelSize2.Width), 35.0f);
            topLabel.Frame = new CGRect(0.0f, 0.0f, Math.Max(expectedLabelSize1.Width, expectedLabelSize2.Width), 15.0f);
            bottomLabel.Frame = new CGRect(0.0f, 20.0f, Math.Max(expectedLabelSize1.Width, expectedLabelSize2.Width), 15.0f);

            return view;
        }
    }
}

