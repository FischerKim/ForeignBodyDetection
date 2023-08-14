using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Common;

namespace YKCJ_Diaper
{
    public class CThresholdFactory
    {
        public static IThreshold GetThreshold(string StrThreshold)
        {
            IThreshold OResult = null;

            try
            {
                EBLOB_THRESHOLD EThreshold = (EBLOB_THRESHOLD)Enum.Parse(typeof(EBLOB_THRESHOLD), StrThreshold);

                switch (EThreshold)
                {
                    case EBLOB_THRESHOLD.Histogram:
                        OResult = new CHistogramThreshold();
                        break;

                    case EBLOB_THRESHOLD.Fixed:
                        OResult = new CFixedThreshold();
                        break;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return OResult;
        }


        public static IThreshold GetThreshold(EBLOB_THRESHOLD EThreshold)
        {
            IThreshold OResult = null;

            try
            {
                switch (EThreshold)
                {
                    case EBLOB_THRESHOLD.Histogram:
                        OResult = new CHistogramThreshold();
                        break;

                    case EBLOB_THRESHOLD.Fixed:
                        OResult = new CFixedThreshold();
                        break;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return OResult;
        }


        public static IThreshold GetThreshold(IThreshold OSource)
        {
            IThreshold OResult = null;

            try
            {
                switch (OSource.EKind)
                {
                    case EBLOB_THRESHOLD.Histogram:
                        OResult = new CHistogramThreshold(OSource);
                        break;

                    case EBLOB_THRESHOLD.Fixed:
                        OResult = new CFixedThreshold(OSource);
                        break;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return OResult;
        }
    }
}
