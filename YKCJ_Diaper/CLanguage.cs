using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognex.VisionPro.Caliper;
using Jhjo.Common;
using Cognex.VisionPro.Blob;

namespace YKCJ_Diaper
{
    public class CLanguage
    {
        public static string GetBlobThreshold(EBLOB_THRESHOLD EThreshold)
        {
            string StrResult = string.Empty;

            try
            {
                switch (EThreshold)
                {
                    case EBLOB_THRESHOLD.Histogram:
                        StrResult = "이미지 명암";
                        break;

                    case EBLOB_THRESHOLD.Fixed:
                        StrResult = "고정";
                        break;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return StrResult;
        }


        public static EBLOB_THRESHOLD GetBlobThreshold(string StrThreshold)
        {
            EBLOB_THRESHOLD EResult = EBLOB_THRESHOLD.Histogram;

            try
            {
                switch (StrThreshold)
                {
                    case "이미지 명암":
                        EResult = EBLOB_THRESHOLD.Histogram;
                        break;

                    case "고정":
                        EResult = EBLOB_THRESHOLD.Fixed;
                        break;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return EResult;
        }


        public static string GetBlobPolarity(CogBlobSegmentationPolarityConstants EPolarity)
        {
            string StrResult = string.Empty;

            try
            {
                switch (EPolarity)
                {
                    case CogBlobSegmentationPolarityConstants.DarkBlobs:
                        StrResult = "어두운 이물";
                        break;

                    case CogBlobSegmentationPolarityConstants.LightBlobs:
                        StrResult = "밝은 이물";
                        break;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return StrResult;
        }


        public static CogBlobSegmentationPolarityConstants GetBlobPolarity(string StrPolarity)
        {
            CogBlobSegmentationPolarityConstants EResult = CogBlobSegmentationPolarityConstants.DarkBlobs;

            try
            {
                switch (StrPolarity)
                {
                    case "밝은 이물":
                        EResult = CogBlobSegmentationPolarityConstants.LightBlobs;
                        break;

                    case "어두운 이물":
                        EResult = CogBlobSegmentationPolarityConstants.DarkBlobs;
                        break;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return EResult;
        }


        public static string GetCaliperPolarity(CogCaliperPolarityConstants EPolarity)
        {
            string StrResult = string.Empty;

            try
            {
                switch (EPolarity)
                {
                    case CogCaliperPolarityConstants.DarkToLight:
                        StrResult = "어두운에서 밝은";
                        break;

                    case CogCaliperPolarityConstants.LightToDark:
                        StrResult = "밝은에서 어두운";
                        break;

                    case CogCaliperPolarityConstants.DontCare:
                        StrResult = "어느 하나";
                        break;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return StrResult;
        }


        public static CogCaliperPolarityConstants GetCaliperPolarity(string StrPolarity)
        {
            CogCaliperPolarityConstants EResult = CogCaliperPolarityConstants.DontCare;

            try
            {
                switch (StrPolarity)
                {
                    case "어두운에서 밝은":
                        EResult = CogCaliperPolarityConstants.DarkToLight;
                        break;

                    case "밝은에서 어두운":
                        EResult = CogCaliperPolarityConstants.LightToDark;
                        break;

                    case "어느 하나":
                        EResult = CogCaliperPolarityConstants.DontCare;
                        break;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return EResult;
        }




        public static string GetCaliperPriority(ECALIPER_PRIORITY EPriority)
        {
            string StrResult = string.Empty;

            try
            {
                switch (EPriority)
                {
                    case ECALIPER_PRIORITY.MostThreshold:
                        StrResult = "명암";
                        break;

                    case ECALIPER_PRIORITY.MostPosition:
                        StrResult = "위치";
                        break;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return StrResult;
        }


        public static ECALIPER_PRIORITY GetCaliperPriority(string StrPolarity)
        {
            ECALIPER_PRIORITY EResult = ECALIPER_PRIORITY.MostThreshold;

            try
            {
                switch (StrPolarity)
                {
                    case "명암":
                        EResult = ECALIPER_PRIORITY.MostThreshold;
                        break;

                    case "위치":
                        EResult = ECALIPER_PRIORITY.MostPosition;
                        break;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return EResult;
        }
    }
}
