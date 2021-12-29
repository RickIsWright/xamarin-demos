#region Copyright Syncfusion Inc. 2001-2021
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfChart.iOS;

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
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
#endif
namespace SampleBrowser
{
	public class Doughnut : SampleView
	{
		public Doughnut ()
		{
			SFChart chart 						= new SFChart ();
			chart.Title.Text 					= new NSString ("Project Cost Breakdown");
			chart.Legend.Visible 				= true;
			chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.DockPosition = SFChartLegendPosition.Bottom;
            chart.Legend.OverflowMode = ChartLegendOverflowMode.Wrap;
            chart.Legend.IconWidth = 14;
            chart.Legend.IconHeight = 14;
			ChartViewModel dataModel			= new ChartViewModel ();

			SFDoughnutSeries series = new SFDoughnutSeries();
            series.StrokeColor = UIColor.White;
			series.ItemsSource = dataModel.DoughnutSeriesData;
			series.XBindingPath = "XValue";
			series.YBindingPath = "YValue";
			series.DataMarker.ShowLabel = true;
			series.ExplodeOnTouch = true;
			series.DataMarker.LabelContent = SFChartLabelContent.Percentage;
			series.EnableAnimation = true;
            series.ColorModel.Palette = SFChartColorPalette.Natural;
			chart.Series.Add(series);

			this.AddSubview(chart);
		}

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Bounds;
			}
			base.LayoutSubviews ();
		}

	}

}