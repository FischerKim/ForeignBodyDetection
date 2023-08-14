using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Common;

namespace YKCJ_Diaper
{
    public class CROIFactory
    {
        public static AROI GetROI(string StrKind)
        {
            AROI OResult = null;

            try
            {
                EROI EKind = (EROI)Enum.Parse(typeof(EROI), StrKind);

                switch (EKind)
                {
                    case EROI.Circle:
                        OResult = new CROICircle();
                        break;

                    case EROI.CircularAnnulusSection:
                        OResult = new CROICircularAnnulusSection();
                        break;

                    case EROI.Ellipse:
                        OResult = new CROIEllipse();
                        break;

                    case EROI.EllipticalAnnulusSection:
                        OResult = new CROIEllipticalAnnulusSection();
                        break;

                    case EROI.Polygon:
                        OResult = new CROIPolygon();
                        break;

                    case EROI.Rectangle:
                        OResult = new CROIRectangle();
                        break;

                    case EROI.RectangleAffine:
                        OResult = new CROIRectangleAffine();
                        break;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return OResult;
        }


        public static AROI GetROI(string StrKind, double[] ArrF64Value)
        {
            AROI OResult = null;

            try
            {
                EROI EKind = (EROI)Enum.Parse(typeof(EROI), StrKind);

                switch (EKind)
                {
                    case EROI.Circle:
                        OResult = new CROICircle(ArrF64Value);
                        break;

                    case EROI.CircularAnnulusSection:
                        OResult = new CROICircularAnnulusSection(ArrF64Value);
                        break;

                    case EROI.Ellipse:
                        OResult = new CROIEllipse(ArrF64Value);
                        break;

                    case EROI.EllipticalAnnulusSection:
                        OResult = new CROIEllipticalAnnulusSection(ArrF64Value);
                        break;

                    case EROI.Polygon:
                        OResult = new CROIPolygon(ArrF64Value);
                        break;

                    case EROI.Rectangle:
                        OResult = new CROIRectangle(ArrF64Value);
                        break;

                    case EROI.RectangleAffine:
                        OResult = new CROIRectangleAffine(ArrF64Value);
                        break;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return OResult;
        }


        public static AROI GetROI(EROI EKind)
        {
            AROI OResult = null;

            try
            {
                switch (EKind)
                {
                    case EROI.Circle:
                        OResult = new CROICircle();
                        break;

                    case EROI.CircularAnnulusSection:
                        OResult = new CROICircularAnnulusSection();
                        break;

                    case EROI.Ellipse:
                        OResult = new CROIEllipse();
                        break;

                    case EROI.EllipticalAnnulusSection:
                        OResult = new CROIEllipticalAnnulusSection();
                        break;

                    case EROI.Polygon:
                        OResult = new CROIPolygon();
                        break;

                    case EROI.Rectangle:
                        OResult = new CROIRectangle();
                        break;

                    case EROI.RectangleAffine:
                        OResult = new CROIRectangleAffine();
                        break;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return OResult;
        }


        public static AROI GetROI(AROI OSource)
        {
            AROI OResult = null;

            try
            {
                switch (OSource.EKind)
                {
                    case EROI.Circle:
                        OResult = new CROICircle(OSource);
                        break;

                    case EROI.CircularAnnulusSection:
                        OResult = new CROICircularAnnulusSection(OSource);
                        break;

                    case EROI.Ellipse:
                        OResult = new CROIEllipse(OSource);
                        break;

                    case EROI.EllipticalAnnulusSection:
                        OResult = new CROIEllipticalAnnulusSection(OSource);
                        break;

                    case EROI.Polygon:
                        OResult = new CROIPolygon(OSource);
                        break;

                    case EROI.Rectangle:
                        OResult = new CROIRectangle(OSource);
                        break;

                    case EROI.RectangleAffine:
                        OResult = new CROIRectangleAffine(OSource);
                        break;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return OResult;
        }


        public static CROIWindow GetROIWindow(EROI EKind)
        {
            CROIWindow OResult = null;

            try
            {
                switch (EKind)
                {
                    case EROI.Circle:
                        OResult = new frmROICircle();
                        break;

                    case EROI.CircularAnnulusSection:
                        OResult = new frmROICircularAnnulusSection();
                        break;

                    case EROI.Ellipse:
                        OResult = new frmROIEllipse();
                        break;

                    case EROI.EllipticalAnnulusSection:
                        OResult = new frmROIEllipticalAnnulusSection();
                        break;

                    case EROI.Polygon:
                        OResult = new frmROIPolygon();
                        break;

                    case EROI.Rectangle:
                        OResult = new frmROIRectangle();
                        break;

                    case EROI.RectangleAffine:
                        OResult = new frmROIRectangleAffine();
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
