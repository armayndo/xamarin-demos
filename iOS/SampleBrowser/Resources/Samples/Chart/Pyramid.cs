#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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
using nint	 = System.Int32;
using nuint	 = System.Int32;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
#endif

namespace SampleBrowser
{
	public class Pyramid : SampleView
	{
		public Pyramid ()
		{
			SFChart chart 						= new SFChart ();
			chart.Title.Text 					= new NSString ("Sales Distribution of Cars by Region");
			chart.Legend.Visible 				= true;
			ChartViewModel dataModel			= new ChartViewModel ();

			SFPyramidSeries series = new SFPyramidSeries();
			series.ItemsSource = dataModel.PyramidData;
			series.XBindingPath = "XValue";
			series.YBindingPath = "YValue";
			series.DataMarker.ShowLabel = true;
			series.LegendIcon =   SFChartLegendIcon.Circle;
            chart.Legend.IconWidth = 14;
            chart.Legend.IconHeight = 14;
			series.DataMarker.LabelStyle.LabelPosition = SFChartDataMarkerLabelPosition.Inner;
            series.ColorModel.Palette = SFChartColorPalette.Natural;
			chart.Series.Add(series);

			chart.Legend.ToggleSeriesVisibility = true;

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