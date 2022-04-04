#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfBarcode.iOS;

#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using CGRect = System.Drawing.RectangleF;
using CGPoint = System.Drawing.PointF;
using CGSize = System.Drawing.SizeF;
#endif

namespace SampleBrowser
{
	public class Code128ABarcode : SampleView
	{
		SFBarcode barcode;
		CGRect frameRect = new CGRect ();
		float frameMargin = 8.0f;

		public Code128ABarcode ()
		{
			barcode = new SFBarcode();
		}

		void LoadAllowedTextsLabel()
		{
			UILabel label = new UILabel ();
			label.Frame = frameRect;
			label.TextColor = UIColor.FromRGB (38/255.0f, 38/255.0f, 38/255.0f);
			label.Text = "Allowed Characters";
			label.Font = UIFont.BoldSystemFontOfSize(12);
			label.SizeToFit();
			label.Frame = new CGRect(frameRect.Location.X, 10, frameRect.Size.Width, label.Frame.Size.Height);
			this.AddSubview (label);

			frameRect.Location = new CGPoint(frameRect.Location.X, (10 + label.Frame.Size.Height + frameMargin));
			frameRect.Size = new CGSize(frameRect.Size.Width, (frameRect.Size.Height - label.Frame.Size.Height + frameMargin));

			UILabel allowedTextsLabel = new UILabel ();
			allowedTextsLabel.Frame = frameRect;
			allowedTextsLabel.TextColor = UIColor.FromRGB (63/255.0f, 63/255.0f, 63/255.0f);
			allowedTextsLabel.Text = "ASCII values from 0 to 95\nNUL SOH STX ETX EOT ENQ ACK BEL BS HT LF VT FF CR SO SI DLE DC1 DC2 DC3 DC4 NAK SYN ETB CAN EM SUB ESC FS GS RS US SPACE ! \" # $ % & ' ( ) * + , - . / 0 1 2 3 4 5 6 7 8 9 : ; < = > ? @ A B C D E F G H I J K L M N O P Q R S T U V W X Y Z [ \\ ]^ _";
			allowedTextsLabel.Font = UIFont.SystemFontOfSize (10.0f);
			allowedTextsLabel.Lines = 0;
			allowedTextsLabel.SizeToFit ();
			allowedTextsLabel.Frame = new CGRect(frameRect.Location.X, frameRect.Location.Y, frameRect.Size.Width , allowedTextsLabel.Frame.Size.Height);
			this.AddSubview(allowedTextsLabel);

			frameRect.Location = new CGPoint(frameRect.Location.X, (frameRect.Location.Y + allowedTextsLabel.Frame.Size.Height + frameMargin));
			frameRect.Size = new CGSize(frameRect.Size.Width, frameRect.Size.Height - allowedTextsLabel.Frame.Size.Height);
		}

		void LoadBarcode()
		{
			
			barcode.BackgroundColor = UIColor.FromRGB (242/255.0f, 242/255.0f, 242/255.0f);
			barcode.Frame = frameRect;
			barcode.Text = (NSString)"ACL32 SF-D8";
			barcode.Symbology = SFBarcodeSymbolType.SFBarcodeSymbolTypeCode128A;
			SFCode128ASettings settings = new SFCode128ASettings();
			settings.BarHeight = 80;
			settings.NarrowBarWidth = 1f;
			barcode.SymbologySettings = settings;
			this.AddSubview(barcode);
		}

		public override void LayoutSubviews ()
		{
			frameRect = Frame;
			frameRect.Location = new CGPoint (frameRect.Location.X + frameMargin, frameRect.Location.Y + 1.5f * frameMargin);
			frameRect.Size = new CGSize(frameRect.Size.Width - (frameRect.Location.X + frameMargin), frameRect.Size.Height - (frameRect.Location.Y + 1.5f * frameMargin));

			LoadAllowedTextsLabel ();

			LoadBarcode ();

			base.LayoutSubviews ();
		}
	}
}

