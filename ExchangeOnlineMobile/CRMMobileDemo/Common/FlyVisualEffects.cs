using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gizmox.WebGUI.Forms.VisualEffects;

namespace CRMMobileDemo.Common
{
    /// <summary>
    ///  A visual effect to move object from current location out to the left.
    /// </summary>
    public class FlyInFromLeftVisualEffect : TranslateVisualEffect
    { 
        public FlyInFromLeftVisualEffect()
            : base(new AxisLengthAndUnits(LengthUnits.Percent, LengthUnits.Percent, -100, 0), new AxisLengthAndUnits(LengthUnits.Percent, LengthUnits.Percent, 0, 0), 0.3M, 0, TransitionTimingFunction.Ease)
        {
        }

        public FlyInFromLeftVisualEffect(decimal decDuration, decimal decDelay, TransitionTimingFunction enmTransitionTimingFunction)
            : base(new AxisLengthAndUnits(LengthUnits.Percent, LengthUnits.Percent, -100, 0), new AxisLengthAndUnits(LengthUnits.Percent, LengthUnits.Percent, 0, 0), decDuration, decDelay, enmTransitionTimingFunction)
        {

        }

        public override object[] GetConstroctorArguments()
        {
            return new object[] { this.TransitionDuration, this.TransitionDelay, this.TransitionTimingFunction };
        }
    }


    /// <summary>
    /// A visual effect to move object from current location out to the right.
    /// </summary>
    public class FlyInFromRightVisualEffect : TranslateVisualEffect
    {
        public FlyInFromRightVisualEffect()
            : base(new AxisLengthAndUnits(LengthUnits.Percent, LengthUnits.Percent, 100, 0), new AxisLengthAndUnits(LengthUnits.Percent, LengthUnits.Percent, 0, 0), 0.3M, 0, TransitionTimingFunction.Ease)
        {
        }

        public FlyInFromRightVisualEffect(decimal decDuration, decimal decDelay, TransitionTimingFunction enmTransitionTimingFunction)
            : base(new AxisLengthAndUnits(LengthUnits.Percent, LengthUnits.Percent, 100, 0), new AxisLengthAndUnits(LengthUnits.Percent, LengthUnits.Percent, 0, 0), decDuration, decDelay, enmTransitionTimingFunction)
        {

        }

        public override object[] GetConstroctorArguments()
        {
            return new object[] { this.TransitionDuration, this.TransitionDelay, this.TransitionTimingFunction };
        }
    }

    /// <summary>
    /// A visual effect to move object from out right to the original position.
    /// </summary>
    public class FlyOutToRightVisualEffect : TranslateVisualEffect
    {
        public FlyOutToRightVisualEffect()
            : base(new AxisLengthAndUnits(LengthUnits.Percent, LengthUnits.Percent, 0, 0), new AxisLengthAndUnits(LengthUnits.Percent, LengthUnits.Percent, 100, 0), 0.3M, 0, TransitionTimingFunction.Ease)
        {
        }

        public FlyOutToRightVisualEffect(decimal decDuration, decimal decDelay, TransitionTimingFunction enmTransitionTimingFunction)
            : base(new AxisLengthAndUnits(LengthUnits.Percent, LengthUnits.Percent, 0, 0), new AxisLengthAndUnits(LengthUnits.Percent, LengthUnits.Percent, 100, 0), decDuration, decDelay, enmTransitionTimingFunction)
        {

        }

        public override object[] GetConstroctorArguments()
        {
            return new object[] { this.TransitionDuration, this.TransitionDelay, this.TransitionTimingFunction };
        }
    }

    /// <summary>
    /// A visual effect to move object from out left to the original position.
    /// </summary>
    public class FlyOutToLeftVisualEffect : TranslateVisualEffect
    {
        public FlyOutToLeftVisualEffect()
            : base(new AxisLengthAndUnits(LengthUnits.Percent, LengthUnits.Percent, 0, 0), new AxisLengthAndUnits(LengthUnits.Percent, LengthUnits.Percent, -100, 0), 0.3M, 0, TransitionTimingFunction.Ease)
        {
        }

        public FlyOutToLeftVisualEffect(decimal decDuration, decimal decDelay, TransitionTimingFunction enmTransitionTimingFunction)
            : base(new AxisLengthAndUnits(LengthUnits.Percent, LengthUnits.Percent, 0, 0), new AxisLengthAndUnits(LengthUnits.Percent, LengthUnits.Percent, -100, 0), decDuration, decDelay, enmTransitionTimingFunction)
        {

        }

        public override object[] GetConstroctorArguments()
        {
            return new object[] { this.TransitionDuration, this.TransitionDelay, this.TransitionTimingFunction };
        }
    }
}