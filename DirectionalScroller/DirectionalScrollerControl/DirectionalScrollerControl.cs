﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

/*
 * This code is from https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.scrollbarrenderer?view=windowsdesktop-7.0
 *  with minor changes to alter the behaviour of the scrollbar
 */

namespace DirectionalScrollerControl
{
   public delegate void ValueChangedHandler(object sender, ValueChangedEventArgs e);

    public partial class DirectionalScrollerControl : Control
    {
        private double oldValue = 0.0;
        private double value = 0.0;
        public int Value
        {
            get
            {
                return (int)Math.Truncate(value);
            }
            set
            {
                this.value = value;
            }
        }

        private double percent = 0.0;
        private int minimum = -10;
        public int Minimum
        {
            get
            {
                return minimum;
            }
            set
            {
                if (value > maximum)
                {
                    throw new Exception("Minimum may not be greater than Maximum");
                }
                minimum = value;
            }
        }
        private int maximum = 10;
        public int Maximum
        {
            get
            {
                return maximum;
            }
            set
            {
                if (value < maximum)
                {
                    throw new Exception("Maximum may not be less than Minimum");
                }
                maximum = value;
            }
        }
        //Font f1 = new Font("Arial", 8.0f);
        //Brush b1 = Brushes.Black;

        public ValueChangedHandler OnValueChanged;

        private Rectangle clickedBarRectangle;
        private Rectangle thumbRectangle;
        private Rectangle leftArrowRectangle;
        private Rectangle rightArrowRectangle;
        private bool leftArrowClicked = false;
        private bool rightArrowClicked = false;
        private bool leftBarClicked = false;
        private bool rightBarClicked = false;
        private bool thumbClicked = false;
        private ScrollBarState thumbState = ScrollBarState.Normal;
        private ScrollBarArrowButtonState leftButtonState = ScrollBarArrowButtonState.LeftNormal;
        private ScrollBarArrowButtonState rightButtonState = ScrollBarArrowButtonState.RightNormal;

        // This control does not allow these widths to be altered.
        private int thumbWidth = 20;
        private int arrowWidth = 17;

        // Set the right limit of the thumb's right border.
        private int thumbRightLimitRight = 0;

        // Set the right limit of the thumb's left border.
        private int thumbRightLimitLeft = 0;

        // Set the left limit of thumb's left border.
        private int thumbLeftLimit = 0;

        // Set the distance from the left edge of the thumb to the cursor tip.
        private int thumbPosition = 0;

        // Set the distance from the left edge of the scroll bar track to the cursor tip.
        private int trackPosition = 0;

        // This timer draws the moving thumb while the scroll arrows or track are pressed.
        private Timer progressTimer = new Timer();

        public DirectionalScrollerControl() : base()
        {
            InitializeComponent();
            this.Location = new Point(10, 10);
            this.Width = 200;
            this.Height = 20;
            this.DoubleBuffered = true;

            SetUpScrollBar();
            progressTimer.Interval = 20;
            progressTimer.Tick += new EventHandler(progressTimer_Tick);
        }

        // Calculate the sizes of the scroll bar elements.
        private void SetUpScrollBar()
        {
            clickedBarRectangle = ClientRectangle;
            thumbRectangle = new Rectangle(
                ClientRectangle.X + (ClientRectangle.Width / 2) - (thumbWidth / 2),
                ClientRectangle.Y, thumbWidth,
                ClientRectangle.Height);
            leftArrowRectangle = new Rectangle(
                ClientRectangle.X, ClientRectangle.Y,
                arrowWidth, ClientRectangle.Height);
            rightArrowRectangle = new Rectangle(
                ClientRectangle.Right - arrowWidth,
                ClientRectangle.Y, arrowWidth,
                ClientRectangle.Height);

            // Set the default starting thumb position.
            thumbPosition = thumbWidth / 2;

            // Set the right limit of the thumb's right border.
            thumbRightLimitRight = ClientRectangle.Right - arrowWidth;

            // Set the right limit of the thumb's left border.
            thumbRightLimitLeft = thumbRightLimitRight - thumbWidth;

            // Set the left limit of the thumb's left border.
            thumbLeftLimit = ClientRectangle.X + arrowWidth;

            SetValue();
        }

        // Draw the scroll bar in its normal state.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Visual styles are not enabled.
            if (!ScrollBarRenderer.IsSupported)
            {
                this.Parent.Text = "CustomScrollBar Disabled";
                return;
            }

            this.Parent.Text = "CustomScrollBar Enabled";

            // Draw the scroll bar track.
            ScrollBarRenderer.DrawRightHorizontalTrack(e.Graphics, ClientRectangle, ScrollBarState.Normal);

            // Draw the thumb and thumb grip in the current state.
            ScrollBarRenderer.DrawHorizontalThumb(e.Graphics, thumbRectangle, thumbState);
            ScrollBarRenderer.DrawHorizontalThumbGrip(e.Graphics, thumbRectangle, thumbState);

            // Draw the scroll arrows in the current state.
            ScrollBarRenderer.DrawArrowButton(e.Graphics, leftArrowRectangle, leftButtonState);
            ScrollBarRenderer.DrawArrowButton(e.Graphics, rightArrowRectangle, rightButtonState);

            // Draw a highlighted rectangle in the left side of the scroll 
            // bar track if the user has clicked between the left arrow and thumb.
            if (leftBarClicked)
            {
                clickedBarRectangle.X = thumbLeftLimit;
                clickedBarRectangle.Width = thumbRectangle.X - thumbLeftLimit;
                ScrollBarRenderer.DrawLeftHorizontalTrack(e.Graphics, clickedBarRectangle, ScrollBarState.Pressed);
            }

            // Draw a highlighted rectangle in the right side of the scroll 
            // bar track if the user has clicked between the right arrow and thumb.
            else if (rightBarClicked)
            {
                clickedBarRectangle.X = thumbRectangle.X + thumbRectangle.Width;
                clickedBarRectangle.Width = thumbRightLimitRight - clickedBarRectangle.X;
                ScrollBarRenderer.DrawRightHorizontalTrack(e.Graphics, clickedBarRectangle, ScrollBarState.Pressed);
            }
            //e.Graphics.DrawString(value.ToString("#0.0"), f1, b1, thumbRectangle.X + 3, thumbRectangle.Y);
        }

        // Handle a mouse click in the scroll bar.
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (!ScrollBarRenderer.IsSupported)
                return;

            // When the thumb is clicked, update the distance from the left
            // edge of the thumb to the cursor tip.
            if (thumbRectangle.Contains(e.Location))
            {
                thumbClicked = true;
                thumbPosition = e.Location.X - thumbRectangle.X;
                thumbState = ScrollBarState.Pressed;
            }

            // When the left arrow is clicked, start the timer to scroll 
            // while the arrow is held down.
            else if (leftArrowRectangle.Contains(e.Location))
            {
                leftArrowClicked = true;
                leftButtonState = ScrollBarArrowButtonState.LeftPressed;
                progressTimer.Start();
            }

            // When the right arrow is clicked, start the timer to scroll 
            // while the arrow is held down.
            else if (rightArrowRectangle.Contains(e.Location))
            {
                rightArrowClicked = true;
                rightButtonState = ScrollBarArrowButtonState.RightPressed;
                progressTimer.Start();
            }

            // When the scroll bar is clicked, start the timer to move the
            // thumb while the mouse is held down.
            else
            {
                trackPosition = e.Location.X;

                if (e.Location.X < this.thumbRectangle.X)
                {
                    leftBarClicked = true;
                }
                else
                {
                    rightBarClicked = true;
                }
                progressTimer.Start();
            }

            Invalidate();
        }

        // Draw the track.
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (!ScrollBarRenderer.IsSupported)
                return;

            thumbRectangle.X = ClientRectangle.X + (ClientRectangle.Width / 2) - (thumbWidth / 2);
            SetValue();

            // Update the thumb position, if the new location is within the bounds.
            if (thumbClicked)
            {
                thumbClicked = false;
                thumbState = ScrollBarState.Normal;
            }

            // If one of the four thumb movement areas was clicked, stop the timer.
            else if (leftArrowClicked)
            {
                leftArrowClicked = false;
                leftButtonState = ScrollBarArrowButtonState.LeftNormal;
                progressTimer.Stop();
            }

            else if (rightArrowClicked)
            {
                rightArrowClicked = false;
                rightButtonState = ScrollBarArrowButtonState.RightNormal;
                progressTimer.Stop();
            }

            else if (leftBarClicked)
            {
                leftBarClicked = false;
                progressTimer.Stop();
            }

            else if (rightBarClicked)
            {
                rightBarClicked = false;
                progressTimer.Stop();
            }

            Invalidate();
        }

        // Track mouse movements if the user clicks on the scroll bar thumb.
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (!ScrollBarRenderer.IsSupported)
                return;

            // Update the thumb position, if the new location is within the bounds.
            if (thumbClicked)
            {
                // The thumb is all the way to the left.
                if (e.Location.X <= (thumbLeftLimit + thumbPosition))
                {
                    thumbRectangle.X = thumbLeftLimit;
                }

                // The thumb is all the way to the right.
                else if (e.Location.X >= (thumbRightLimitLeft + thumbPosition))
                {
                    thumbRectangle.X = thumbRightLimitLeft;
                }

                // The thumb is between the ends of the track.
                else
                {
                    thumbRectangle.X = e.Location.X - thumbPosition;

                    SetValue();
                }

                Invalidate();
            }
        }

        protected void SetValue()
        {
            percent = (thumbRectangle.X - thumbRectangle.Width + 4) / 1.0 / (thumbRightLimitLeft - thumbLeftLimit);
            double scaled = percent * maximum;
            int intermediate = (int)Math.Truncate((scaled - (maximum / 2)) * 4);
            value = intermediate / 2.0;
            if (value != oldValue)
            {
                OnValueChanged?.Invoke(this, new ValueChangedEventArgs(value));
            }
            oldValue = value;
        }

        // Recalculate the sizes of the scroll bar elements.
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SetUpScrollBar();
        }

        // Handle the timer tick by updating the thumb position.
        private void progressTimer_Tick(object sender, EventArgs myEventArgs)
        {
            if (!ScrollBarRenderer.IsSupported)
                return;

            // If an arrow is clicked, move the thumb in small increments.
            if (rightArrowClicked && thumbRectangle.X < thumbRightLimitLeft)
            {
                thumbRectangle.X++;
            }
            else if (leftArrowClicked && thumbRectangle.X > thumbLeftLimit)
            {
                thumbRectangle.X--;
            }

            // If the track bar to right of the thumb is clicked, move the 
            // thumb to the right in larger increments until the right edge 
            // of the thumb hits the cursor.
            else if (rightBarClicked &&
                thumbRectangle.X < thumbRightLimitLeft &&
                thumbRectangle.X + thumbRectangle.Width < trackPosition)
            {
                thumbRectangle.X += 3;
            }

            // If the track bar to left of the thumb is clicked, move the 
            // thumb to the left in larger increments until the left edge 
            // of the thumb hits the cursor.
            else if (leftBarClicked &&
                thumbRectangle.X > thumbLeftLimit &&
                thumbRectangle.X > trackPosition)
            {
                thumbRectangle.X -= 3;
            }

            Invalidate();
        }
    }

    public class ValueChangedEventArgs : EventArgs
    {
        private double value;
        public double Value
        {
            get
            {
                return this.value;
            }
        }
        public ValueChangedEventArgs(double value)
        {
            this.value = value;
        }
    }
}
