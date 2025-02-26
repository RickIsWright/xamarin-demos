#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SampleBrowser.SfChart
{
	public partial class AxisCrossing : SampleView
	{
		public AxisCrossing()
		{
			InitializeComponent();

            if(Device.RuntimePlatform != Device.UWP && Device.RuntimePlatform != Device.WPF && Device.Idiom != TargetIdiom.Phone)
            {
                ((Syncfusion.SfChart.XForms.NumericalAxis)this.chart.SecondaryAxis).Interval = 20;
                secondaryAxisLabelStyle.LabelFormat ="#'% '";
            }
            else
            {
                secondaryAxisLabelStyle.LabelFormat = "0'% '";
            }
        }
    }
}
