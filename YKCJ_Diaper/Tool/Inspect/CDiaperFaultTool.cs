using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Daekhon.Common;
using Jhjo.Common;
using System.Threading;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro;
using Jhjo.DB;

namespace YKCJ_Diaper
{
    public class CDiaperFaultTool : IDisposable
    {
        #region SINGLE TON
        private static CDiaperFaultTool Src_It = null;


        public static CDiaperFaultTool It
        {
            get
            {
                CDiaperFaultTool OResult = null;

                try
                {
                    if (CDiaperFaultTool.Src_It == null)
                    {
                        CDiaperFaultTool.Src_It = new CDiaperFaultTool();
                    }

                    OResult = CDiaperFaultTool.Src_It;
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }

                return OResult;
            }
        }
        #endregion


        #region CONST
        private const int SECOND_TICK = 600000000;
        #endregion


        #region VARIABLE
        private IImageExporter m_OExporter = null;
        private List<CImageInfo> m_LstOImageInfo = null;
        private object m_OImageInterrupt = null;

        private CogBlobTool m_OBlobTool = null;
        private CogHistogramTool m_OHistogramTool = null;
        private CogCaliperTool m_OCaliperTool = null;
        private CDiaperFaultRecipe m_ORecipe = null;
        private CSubStanceFilterList m_OSubStance = null;
        private bool m_BChangedRecipe = false;
        private object m_OInspectInterrupt = null;
        
        private bool m_BInspectionSpeedEnabled = false;
        private int m_I32InspectionSpeed = 0;
        private long m_I64BeforeProductTick = long.MaxValue;
        private bool m_BTapeSizeEnabled = false;
        private int m_I32TapeSize = 0;
        private bool m_BReject = false;
        private bool m_BSaveNG = true;
        private bool m_BSaveOK = false;
        private int m_I32SaveOKCount = 0;
        private bool m_BSendSignal = true;

        private CogCopyRegionTool m_OCopyRegionTool = null;
        private CogRectangle m_OCopyRegion = null;
        private CogStopwatch m_OStopWatch = null;
        private CDpm m_ODpm = null;

        private Thread m_OWorker = null;
        private bool m_BDoWork = false;

        private CogImage8Grey m_OCurrentImage = null;
        #endregion


        #region DELEGATE & EVENT
        public delegate void RecipeChangedHandler(CDiaperFaultRecipe OResult);
        public RecipeChangedHandler RecipeChanged = null;

        public delegate void InspectedHandler(CDiaperFaultResult OResult);
        public InspectedHandler Inspected = null;

        public delegate void SaveOKImageHandler(int I32Count);
        public SaveOKImageHandler SaveOKImage = null; 
        #endregion


        #region PROPERTIES
        public IImageExporter OExporter
        {
            get { return this.m_OExporter; }
            set
            {
                try
                {
                    if (this.m_OExporter != null)
                    {
                        this.m_OExporter.Exported -= new ExportedHandler(this.OExporter_Exported);
                    }

                    this.m_OExporter = value;

                    if (this.m_OExporter != null)
                    {
                        this.m_OExporter.Exported += new ExportedHandler(this.OExporter_Exported);
                    }
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }
            }
        }


        public CSubStanceFilterList OSubStance
        {
            get 
            {
                CSubStanceFilterList OResult = null;

                try
                {
                    Monitor.Enter(this.m_OInspectInterrupt);

                    OResult = new CSubStanceFilterList(this.m_OSubStance);
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }
                finally
                {
                    Monitor.Exit(this.m_OInspectInterrupt);
                }

                return OResult;
            }
            set
            {
                try
                {
                    Monitor.Enter(this.m_OInspectInterrupt);

                    this.m_OSubStance = new CSubStanceFilterList(value);
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }
                finally
                {
                    Monitor.Exit(this.m_OInspectInterrupt);
                }
            }
        }


        public IRecipe ORecipe
        {
            get { return this.m_ORecipe; }
            set 
            {
                try
                {
                    Monitor.Enter(this.m_OInspectInterrupt);


                    if (this.m_ORecipe != null)
                    {
                        this.m_ORecipe.Dispose();
                        this.m_ORecipe = null;
                    }


                    this.m_ORecipe = new CDiaperFaultRecipe((CDiaperFaultRecipe)value);
                    this.m_BChangedRecipe = true;
                    if (this.m_ORecipe != null)
                    {
                        this.m_ORecipe.Load();
                    }
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }
                finally
                {
                    Monitor.Exit(this.m_OInspectInterrupt);
                }
            }
        }


        public bool BInspectionSpeedEnabled
        {
            get { return this.m_BInspectionSpeedEnabled; }
            set { this.m_BInspectionSpeedEnabled = value; }
        }


        public int I32InspectionSpeed
        {
            get { return this.m_I32InspectionSpeed; }
            set { this.m_I32InspectionSpeed = value; }
        }


        public bool BTapeSizeEnabled
        {
            get { return this.m_BTapeSizeEnabled; }
            set { this.m_BTapeSizeEnabled = value; }
        }


        public int I32TapeSize
        {
            get { return this.m_I32TapeSize; }
            set { this.m_I32TapeSize = value; }
        }


        public bool BSendSignal
        {
            get { return this.m_BSendSignal; }
            set { this.m_BSendSignal = value; }
        }


        public bool BReject
        {
            get { return this.m_BReject; }
            set 
            {
                try
                {
                    this.m_BReject = value;

                    if (this.m_BReject == true) CControlBox.It.On(EIO.REJECT);
                    else CControlBox.It.Off(EIO.REJECT);
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }
            }
        }


        public bool BSaveNG
        {
            get { return this.m_BSaveNG; }
            set { this.m_BSaveNG = value; }
        }


        public bool BSaveOK
        {
            get { return this.m_BSaveOK; }
            set { this.m_BSaveOK = value; }
        }


        public CDpm ODpm
        {
            get { return this.m_ODpm; }
            set { this.m_ODpm = value; }
        }


        public CogImage8Grey OCurrentImage
        {
            get { return this.m_OCurrentImage; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CDiaperFaultTool()
        {
            try
            {
                this.m_LstOImageInfo = new List<CImageInfo>();
                this.m_OImageInterrupt = new object();

                this.m_OBlobTool = new CogBlobTool();
                this.m_OBlobTool.RunParams.SegmentationParams.Mode = CogBlobSegmentationModeConstants.HardFixedThreshold;
                this.m_OHistogramTool = new CogHistogramTool();
                this.m_OCaliperTool = new CogCaliperTool();
                this.m_OCaliperTool.RunParams.EdgeMode = CogCaliperEdgeModeConstants.SingleEdge;
                this.m_OCaliperTool.RunParams.MaxResults = 1;
                this.m_OInspectInterrupt = new object();

                this.m_OCopyRegionTool = new CogCopyRegionTool();
                this.m_OCopyRegion = new CogRectangle();
                this.m_OCopyRegion.Width = 100;
                this.m_OCopyRegion.Height = 100;
                this.m_OStopWatch = new CogStopwatch();
                this.m_ODpm = new CDpm();

                this.BeginWork();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        ~CDiaperFaultTool()
        {
            try
            {
                this.Dispose();
            }
            catch (Exception ex)
            {
                CError.Ignore(ex);
            }
        }
        #endregion


        #region EVENT
        private void OExporter_Exported(object OImageInfo)
        {
            try
            {
                Monitor.Enter(this.m_OImageInterrupt);

                this.m_LstOImageInfo.Add((CImageInfo)OImageInfo);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(this.m_OImageInterrupt);
            }
        }
        #endregion


        #region FUNCTION
        private void BeginWork()
        {
            try
            {
                if (this.m_OWorker == null)
                {
                    this.m_BDoWork = true;

                    this.m_OWorker = new Thread(this.Work);
                    this.m_OWorker.IsBackground = true;
                    this.m_OWorker.Start();
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void Work()
        {
            try
            {
                while (this.m_BDoWork == true)
                {
                    try
                    {
                        CImageInfo OImageInfo = this.GetImageInfo();
                        CDiaperFaultResult OResult = this.DoProcess(OImageInfo);

                        if (OResult != null)
                        {
                            this.OnInspected(OResult);
                            this.m_OCurrentImage = OImageInfo.OImage;
                        }
                    }
                    catch (Exception ex)
                    {
                        CError.Ignore(ex);
                    }

                    Thread.Sleep(1);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void EndWork()
        {
            try
            {
                if (this.m_OWorker != null)
                {
                    this.m_BDoWork = false;

                    this.m_OWorker.Join();
                    this.m_OWorker = null;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private CDiaperFaultResult DoProcess(CImageInfo OImageInfo)
        {
            CDiaperFaultResult OResult = null;

            try
            {
                OResult = this.ProcInspect(OImageInfo);

                if ((OResult != null) && (OResult.BInspected == true))
                {
                    if (OResult.BOK == true)
                    {
                        if (this.BSaveOK == true)
                        {
                            string StrFile = String.Format(".\\Image\\OK\\{0:yyyy}\\{0:MM}\\{0:dd}\\{0:HH-mm-ss fff}.bmp", OResult.OImageInfo.OTime);
                            CImageSaveTool.It.SetImage(StrFile, OResult.OImageInfo.OImage);

                            this.m_I32SaveOKCount++;
                            this.OnSaveOKImage();
                            if (this.m_I32SaveOKCount == 100)
                            {
                                this.m_I32SaveOKCount = 0;
                                this.m_BSaveOK = false;
                            }
                        }
                    }
                    else
                    {
                        this.CopyFaultRegion(ref OResult);

                        if (this.m_BSendSignal == true)
                        {
                            if (this.m_BReject == false)
                            {
                                CControlBox.It.On(EIO.NG);
                            }
                            if ((OResult.OFaultResult != null) && (OResult.OFaultResult.EIOSignal != EIO.NONE))
                            {
                                CControlBox.It.On(OResult.OFaultResult.EIOSignal);
                            }
                        }

                        string StrFile = String.Format(".\\Image\\NG\\{0:yyyy}\\{0:MM}\\{0:dd}\\{1}\\{0:HH-mm-ss fff}.bmp", OResult.OImageInfo.OTime, OResult.StrBlobName);
                        if (this.m_BSaveNG == true) CImageSaveTool.It.SetImage(StrFile, OResult.OImageInfo.OImage);

                        this.WriteToDB(OResult, StrFile);
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return OResult;
        }


        private CDiaperFaultResult ProcInspect(CImageInfo OImageInfo)
        {
            CDiaperFaultResult OResult = null;

            try
            {
                Monitor.Enter(this.m_OInspectInterrupt);

                if (this.m_BChangedRecipe == true)
                {
                    this.m_BChangedRecipe = false;
                    this.OnRecipeChanged(new CDiaperFaultRecipe(this.m_ORecipe));
                }

                if (OImageInfo != null)
                {
                    this.m_ODpm.Add();
                    OResult = this.DoInspect(OImageInfo);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(this.m_OInspectInterrupt);
            }

            return OResult;
        }


        private CDiaperFaultResult DoInspect(CImageInfo OImageInfo)
        {
            CDiaperFaultResult OResult = null;

            try
            {
                this.m_OStopWatch.Reset();
                this.m_OStopWatch.Start();

                OResult = new CDiaperFaultResult();
                OResult.OImageInfo = OImageInfo;

                if ((this.IsDoInspectByDpm(OImageInfo) == true) && (this.m_ORecipe != null))
                {
                    OResult.BInspected = true;
                    OResult.BOK = true;

                    this.DoInspectMD(ref OResult);
                    this.DoInspectCD(ref OResult);
                    this.FollowROI(ref OResult);
                    if (this.DoInspectBlob(ref OResult) == true)
                    {
                        this.DoInspectPattern(ref OResult);
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                this.m_OStopWatch.Stop();
                OResult.F64Period = this.m_OStopWatch.Milliseconds;
            }

            return OResult;
        }


        private bool IsDoInspectByDpm(CImageInfo OImageInfo)
        {
            bool BResult = true;

            try
            {
                if (this.BInspectionSpeedEnabled == true)
                {
                    long I64ProductGab = OImageInfo.OTime.Ticks - this.m_I64BeforeProductTick;

                    if (I64ProductGab > 0)
                    {
                        if (this.m_I32InspectionSpeed > (SECOND_TICK / I64ProductGab))
                        {
                            BResult = false;
                        }
                    }
                }

                this.m_I64BeforeProductTick = OImageInfo.OTime.Ticks;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return BResult;
        }


        private void DoInspectMD(ref CDiaperFaultResult OResult)
        {
            try
            {
                OResult.ArrOMD = new CFollowResult[CDiaperFaultRecipe.MD_COUNT];

                for (int _Index = 0; _Index < this.m_ORecipe.ArrOMD.Length; _Index++)
                {
                    OResult.ArrOMD[_Index] = new CFollowResult(EFOLLOW.MD, this.m_ORecipe.ArrOMD[_Index].I32Index);
                    if (this.m_ORecipe.ArrOMD[_Index].BEnabled == false) continue;

                    
                    this.m_OCaliperTool.InputImage = OResult.OImageInfo.OImage;
                    this.m_OCaliperTool.Region = (CogRectangleAffine)this.m_ORecipe.ArrOMD[_Index].OROI.ORegion;
                    this.m_OCaliperTool.RunParams.Edge0Polarity = this.m_ORecipe.ArrOMD[_Index].EPolarity;
                    this.m_OCaliperTool.RunParams.ContrastThreshold = this.m_ORecipe.ArrOMD[_Index].I32ContrastThreshold;
                    this.m_OCaliperTool.RunParams.FilterHalfSizeInPixels = this.m_ORecipe.ArrOMD[_Index].I32HalfPixel;
                    if (this.m_ORecipe.ArrOMD[_Index].EPriority == ECALIPER_PRIORITY.MostThreshold)
                    {
                        this.m_OCaliperTool.RunParams.SingleEdgeScorers.Clear();
                        this.m_OCaliperTool.RunParams.SingleEdgeScorers.Add(new CogCaliperScorerContrast());
                    }
                    else
                    {
                        this.m_OCaliperTool.RunParams.SingleEdgeScorers.Clear();

                        CogCaliperScorerPositionNeg OScorer = new CogCaliperScorerPositionNeg();
                        OScorer.SetXYParameters(-50000, 50000, 100000, 1, 0);
                        this.m_OCaliperTool.RunParams.SingleEdgeScorers.Add(OScorer);
                    }
                    this.m_OCaliperTool.Run();
                    
                    
                    OResult.ArrOMD[_Index].BInspected = true;
                    if ((this.m_OCaliperTool.Results != null) && (this.m_OCaliperTool.Results.Count > 0))
                    {
                        OResult.ArrOMD[_Index].BOK = true;
                        OResult.ArrOMD[_Index].F64X = this.m_OCaliperTool.Results[0].Edge0.PositionX;
                        OResult.ArrOMD[_Index].F64Y = this.m_OCaliperTool.Results[0].Edge0.PositionY;
                        OResult.ArrOMD[_Index].F64Differ = this.m_OCaliperTool.Results[0].Edge0.PositionX - this.m_ORecipe.ArrOMD[_Index].F64StandardPosition;
                    }
                    else OResult.ArrOMD[_Index].BOK = false;
                    
                    foreach (CBlobRecipe _Item in this.m_ORecipe.ArrOBlob)
                    {
                        if (_Item.BEnabled == false) continue;
                        if (_Item.StrMD != _Item.I32Index.ToString()) continue;

                        _Item.OROI.F64AdjustX = OResult.ArrOMD[_Index].F64Differ;
                    }
                    foreach (CPatternRecipe _Item in this.m_ORecipe.ArrOPattern)
                    {
                        if (_Item.BEnabled == false) continue;
                        if (_Item.StrMD != _Item.I32Index.ToString()) continue;

                        _Item.OROI.F64AdjustX = OResult.ArrOMD[_Index].F64Differ;
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void DoInspectCD(ref CDiaperFaultResult OResult)
        {
            try
            {
                OResult.ArrOCD = new CFollowResult[CDiaperFaultRecipe.CD_COUNT];

                for (int _Index = 0; _Index < this.m_ORecipe.ArrOCD.Length; _Index++)
                {
                    OResult.ArrOCD[_Index] = new CFollowResult(EFOLLOW.CD, this.m_ORecipe.ArrOCD[_Index].I32Index);
                    if (this.m_ORecipe.ArrOCD[_Index].BEnabled == false) continue;


                    this.m_OCaliperTool.InputImage = OResult.OImageInfo.OImage;
                    this.m_OCaliperTool.Region = (CogRectangleAffine)this.m_ORecipe.ArrOCD[_Index].OROI.ORegion;
                    this.m_OCaliperTool.RunParams.Edge0Polarity = this.m_ORecipe.ArrOCD[_Index].EPolarity;
                    this.m_OCaliperTool.RunParams.ContrastThreshold = this.m_ORecipe.ArrOCD[_Index].I32ContrastThreshold;
                    this.m_OCaliperTool.RunParams.FilterHalfSizeInPixels = this.m_ORecipe.ArrOCD[_Index].I32HalfPixel;
                    if (this.m_ORecipe.ArrOCD[_Index].EPriority == ECALIPER_PRIORITY.MostThreshold)
                    {
                        this.m_OCaliperTool.RunParams.SingleEdgeScorers.Clear();
                        this.m_OCaliperTool.RunParams.SingleEdgeScorers.Add(new CogCaliperScorerContrast());
                    }
                    else
                    {
                        this.m_OCaliperTool.RunParams.SingleEdgeScorers.Clear();

                        CogCaliperScorerPositionNeg OScorer = new CogCaliperScorerPositionNeg();
                        OScorer.SetXYParameters(-50000, 50000, 100000, 1, 0);
                        this.m_OCaliperTool.RunParams.SingleEdgeScorers.Add(OScorer);
                    }
                    this.m_OCaliperTool.Run();

                    
                    OResult.ArrOCD[_Index].BInspected = true;
                    if ((this.m_OCaliperTool.Results != null) && (this.m_OCaliperTool.Results.Count > 0))
                    {
                        OResult.ArrOCD[_Index].BOK = true;
                        OResult.ArrOCD[_Index].F64X = this.m_OCaliperTool.Results[0].Edge0.PositionX;
                        OResult.ArrOCD[_Index].F64Y = this.m_OCaliperTool.Results[0].Edge0.PositionY;
                        OResult.ArrOCD[_Index].F64Differ = this.m_OCaliperTool.Results[0].Edge0.PositionY - this.m_ORecipe.ArrOCD[_Index].F64StandardPosition;
                    }
                    else OResult.ArrOCD[_Index].BOK = false;

                    foreach (CBlobRecipe _Item in this.m_ORecipe.ArrOBlob)
                    {
                        if (_Item.BEnabled == false) continue;
                        if (_Item.StrCD != _Item.I32Index.ToString()) continue;

                        _Item.OROI.F64AdjustY = OResult.ArrOCD[_Index].F64Differ;
                    }
                    foreach (CPatternRecipe _Item in this.m_ORecipe.ArrOPattern)
                    {
                        if (_Item.BEnabled == false) continue;
                        if (_Item.StrCD != _Item.I32Index.ToString()) continue;

                        _Item.OROI.F64AdjustY = OResult.ArrOCD[_Index].F64Differ;
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void FollowROI(ref CDiaperFaultResult OResult)
        {
            try
            {
                foreach (CBlobRecipe _Item2 in this.m_ORecipe.ArrOBlob)
                {
                    if (_Item2.BEnabled == false) continue;

                    _Item2.OROI.Refresh();
                    _Item2.OROI.Follow();
                }

                foreach (CPatternRecipe _Item2 in this.m_ORecipe.ArrOPattern)
                {
                    if (_Item2.BEnabled == false) continue;

                    _Item2.OROI.Refresh();
                    _Item2.OROI.Follow();
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private bool DoInspectBlob(ref CDiaperFaultResult OResult)
        {
            bool BResult = true;

            try
            {
                OResult.ArrOBlob = new CBlobResult[CDiaperFaultRecipe.BLOB_COUNT];

                for (int _Index = 0; _Index < this.m_ORecipe.ArrOBlob.Length; _Index++)
                {
                    OResult.ArrOBlob[_Index] = new CBlobResult(this.m_ORecipe.ArrOBlob[_Index].I32Index);
                    OResult.ArrOBlob[_Index].EPolarity = this.m_ORecipe.ArrOBlob[_Index].EPolarity;
                    OResult.ArrOBlob[_Index].EIOSignal = this.m_ORecipe.ArrOBlob[_Index].EIOSignal;

                    if (this.m_ORecipe.ArrOBlob[_Index].BEnabled == false) continue;

                    if (this.m_ORecipe.ArrOBlob[_Index].OThreshold.EKind == EBLOB_THRESHOLD.Histogram)
                    {
                        this.m_OHistogramTool.InputImage = OResult.OImageInfo.OImage;
                        this.m_OHistogramTool.Region = this.m_ORecipe.ArrOBlob[_Index].OROI.ORegion;
                        this.m_OHistogramTool.Run();

                        if (this.m_OHistogramTool.Result != null)
                        {
                            OResult.ArrOBlob[_Index].BHasThreshold = true;
                            
                            CHistogramThreshold OThreshold = (CHistogramThreshold)this.m_ORecipe.ArrOBlob[_Index].OThreshold;                            
                            if (this.m_ORecipe.ArrOBlob[_Index].EPolarity == CogBlobSegmentationPolarityConstants.DarkBlobs)
                            {
                                OResult.ArrOBlob[_Index].I32CurrentThreshold = this.m_OHistogramTool.Result.Minimum;
                                OResult.ArrOBlob[_Index].I32AverageThreshold = OThreshold.GetThreshold(this.m_OHistogramTool.Result.Minimum);
                            }
                            else
                            {
                                OResult.ArrOBlob[_Index].I32CurrentThreshold = this.m_OHistogramTool.Result.Maximum;
                                OResult.ArrOBlob[_Index].I32AverageThreshold = OThreshold.GetThreshold(this.m_OHistogramTool.Result.Maximum);
                            }
                        }
                    }
                    else
                    {
                        OResult.ArrOBlob[_Index].BHasThreshold = true;
                        OResult.ArrOBlob[_Index].I32CurrentThreshold = this.m_ORecipe.ArrOBlob[_Index].OThreshold.I32Value;
                        OResult.ArrOBlob[_Index].I32AverageThreshold = this.m_ORecipe.ArrOBlob[_Index].OThreshold.I32Value;
                    }
                }


                int I32Threshold = 0;
                int I32MinSize = 0;
                for (int _Index = 0; _Index < this.m_ORecipe.ArrOBlob.Length; _Index++)
                {
                    if (this.m_ORecipe.ArrOBlob[_Index].BEnabled == false) continue;
                    if (OResult.ArrOBlob[_Index].BHasThreshold == false) continue;


                    //Threshold
                    if (this.m_ORecipe.ArrOBlob[_Index].EPolarity == CogBlobSegmentationPolarityConstants.DarkBlobs)
                    {
                        I32Threshold = OResult.ArrOBlob[_Index].I32AverageThreshold - this.m_ORecipe.ArrOBlob[_Index].I32Offset;
                    }
                    else 
                    {
                        I32Threshold = OResult.ArrOBlob[_Index].I32AverageThreshold + this.m_ORecipe.ArrOBlob[_Index].I32Offset;
                    }
                    if (I32Threshold < 0) I32Threshold = 0;
                    else if (I32Threshold > 255) I32Threshold = 255;


                    //TapeSize
                    I32MinSize = this.m_ORecipe.ArrOBlob[_Index].I32MinSize;
                    if (this.m_BTapeSizeEnabled == true)
                    {
                        if (I32MinSize < this.m_I32TapeSize)
                        {
                            I32MinSize = this.m_I32TapeSize;
                        }
                    }


                    this.m_OBlobTool.InputImage = OResult.OImageInfo.OImage;
                    this.m_OBlobTool.Region = this.m_ORecipe.ArrOBlob[_Index].OROI.ORegion;
                    this.m_OBlobTool.RunParams.ConnectivityMinPixels = I32MinSize;
                    this.m_OBlobTool.RunParams.SegmentationParams.Polarity = this.m_ORecipe.ArrOBlob[_Index].EPolarity;
                    this.m_OBlobTool.RunParams.SegmentationParams.HardFixedThreshold = I32Threshold;
                    this.m_OBlobTool.Run();


                    OResult.ArrOBlob[_Index].BInspected = true;
                    if (this.m_OBlobTool.Results == null)
                    {
                        if (this.m_ORecipe.ArrOBlob[_Index].OThreshold.EKind == EBLOB_THRESHOLD.Histogram)
                        {
                            ((CHistogramThreshold)this.m_ORecipe.ArrOBlob[_Index].OThreshold).Apply(OResult.ArrOBlob[_Index].I32CurrentThreshold);
                        }
                    }
                    else
                    {
                        CogBlobResultCollection OBlobResult = this.m_OBlobTool.Results.GetBlobs(true);

                        if (OBlobResult.Count == 0)
                        {
                            if (this.m_ORecipe.ArrOBlob[_Index].OThreshold.EKind == EBLOB_THRESHOLD.Histogram)
                            {
                                ((CHistogramThreshold)this.m_ORecipe.ArrOBlob[_Index].OThreshold).Apply(OResult.ArrOBlob[_Index].I32CurrentThreshold);
                            }
                        }
                        else
                        {
                            CogRectangle OBound = OBlobResult[0].GetBoundary().EnclosingRectangle(CogCopyShapeConstants.All);
                            CSubStanceFilter OFilter = this.m_OSubStance.GetMatchFilter(OBound.Width, OBound.Height, OBlobResult[0].Perimeter, OBlobResult[0].Area, OBlobResult[0].Elongation);

                            OResult.BIsBlobNG = true;
                            if (OFilter != null) OResult.StrBlobName = OFilter.StrName;
                            if (OFilter != null) OResult.EColor = OFilter.EColor;
                            OResult.F64BlobXLength = Math.Round(OBound.Width, 1);
                            OResult.F64BlobYLength = Math.Round(OBound.Height, 1);
                            OResult.F64BlobPerimeter = Math.Round(OBlobResult[0].Perimeter, 1);
                            OResult.F64BlobArea = Math.Round(OBlobResult[0].Area, 1);
                            OResult.F64Elongation = Math.Round(OBlobResult[0].Elongation, 2);


                            OResult.ArrOBlob[_Index].BOK = false;
                            OResult.ArrOBlob[_Index].F64X = OBlobResult[0].CenterOfMassX;
                            OResult.ArrOBlob[_Index].F64Y = OBlobResult[0].CenterOfMassY;
                            OResult.ArrOBlob[_Index].F64Size = OBlobResult[0].Area;

                            OResult.OFaultResult = OResult.ArrOBlob[_Index];
                            OResult.BOK = false;

                            BResult = false;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return BResult;
        }


        private bool DoInspectPattern(ref CDiaperFaultResult OResult)
        {
            bool BResult = true;

            try
            {
                OResult.ArrOPattern = new CPatternResult[CDiaperFaultRecipe.PATTERN_COUNT];
                for (int _Index = 0; _Index < this.m_ORecipe.ArrOPattern.Length; _Index++)
                {
                    OResult.ArrOPattern[_Index] = new CPatternResult(this.m_ORecipe.ArrOPattern[_Index].I32Index);
                    OResult.ArrOPattern[_Index].EIOSignal = this.m_ORecipe.ArrOPattern[_Index].EIOSignal;

                    if (this.m_ORecipe.ArrOPattern[_Index].BEnabled == false) continue;

                    this.m_ORecipe.ArrOPattern[_Index].OTool.InputImage = OResult.OImageInfo.OImage;
                    this.m_ORecipe.ArrOPattern[_Index].OTool.SearchRegion = this.m_ORecipe.ArrOPattern[_Index].OROI.ORegion;
                    this.m_ORecipe.ArrOPattern[_Index].OTool.Run();
                    OResult.ArrOPattern[_Index].BInspected = true;

                    if (this.m_ORecipe.ArrOPattern[_Index].OTool.Results == null)
                    {
                        OResult.ArrOPattern[_Index].BOK = false;
                        OResult.ArrOPattern[_Index].F64X = ((CogRectangle)this.m_ORecipe.ArrOPattern[_Index].OROI.ORegion).CenterX;
                        OResult.ArrOPattern[_Index].F64Y = ((CogRectangle)this.m_ORecipe.ArrOPattern[_Index].OROI.ORegion).CenterY;

                        OResult.OFaultResult = OResult.ArrOPattern[_Index];
                        OResult.BOK = false;

                        BResult = false;
                        break;
                    }
                    else
                    {
                        if (this.m_ORecipe.ArrOPattern[_Index].OTool.Results.Count == 0)
                        {
                            OResult.ArrOPattern[_Index].BOK = false;
                            OResult.ArrOPattern[_Index].F64X = ((CogRectangle)this.m_ORecipe.ArrOPattern[_Index].OROI.ORegion).CenterX;
                            OResult.ArrOPattern[_Index].F64Y = ((CogRectangle)this.m_ORecipe.ArrOPattern[_Index].OROI.ORegion).CenterY;

                            OResult.OFaultResult = OResult.ArrOPattern[_Index];
                            OResult.BOK = false;

                            BResult = false;
                            break;
                        }
                        else
                        {
                            OResult.ArrOPattern[_Index].F64Score = this.m_ORecipe.ArrOPattern[_Index].OTool.Results[0].Score;

                            if (this.m_ORecipe.ArrOPattern[_Index].OTool.Results[0].Score * 100 < this.m_ORecipe.ArrOPattern[_Index].I32MinScore)
                            {
                                OResult.ArrOPattern[_Index].BOK = false;
                                OResult.ArrOPattern[_Index].F64X = ((CogRectangle)this.m_ORecipe.ArrOPattern[_Index].OROI.ORegion).CenterX;
                                OResult.ArrOPattern[_Index].F64Y = ((CogRectangle)this.m_ORecipe.ArrOPattern[_Index].OROI.ORegion).CenterY;

                                OResult.OFaultResult = OResult.ArrOPattern[_Index];
                                OResult.BOK = false;

                                BResult = false;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return BResult;
        }


        private void CopyFaultRegion(ref CDiaperFaultResult OResult)
        {
            try
            {
                this.m_OCopyRegion.X = OResult.OFaultResult.F64X - 50;
                this.m_OCopyRegion.Y = OResult.OFaultResult.F64Y - 50;

                this.m_OCopyRegionTool.InputImage = OResult.OImageInfo.OImage;
                this.m_OCopyRegionTool.Region = this.m_OCopyRegion;
                this.m_OCopyRegionTool.Run();

                OResult.OZoomImage = (CogImage8Grey)this.m_OCopyRegionTool.OutputImage;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void WriteToDB(CDiaperFaultResult OResult, string StrFile)
        {
            try
            {
                IDynamicTable OTable = CDB.It.GetDynamicTable(CDB.TABLE_REPORT);
                
                try
                {
                    OTable.BeginSyncData();

                    int I32RowIndex = OTable.InsertRow();
                    OTable.Update(I32RowIndex, CDB.REPORT_DATETIME, OResult.OImageInfo.OTime.ToString("yyyy.MM.dd HH:mm:ss fff"));
                    OTable.Update(I32RowIndex, CDB.REPORT_RECIPE, this.m_ORecipe.StrName);
                    OTable.Update(I32RowIndex, CDB.REPORT_TOOL, OResult.OFaultResult.ETool.ToString());
                    OTable.Update(I32RowIndex, CDB.REPORT_INDEX, OResult.OFaultResult.I32Index.ToString());
                    OTable.Update(I32RowIndex, CDB.REPORT_VALUE, OResult.OFaultResult.F64Value.ToString());
                    OTable.Update(I32RowIndex, CDB.REPORT_X, OResult.OFaultResult.F64X);
                    OTable.Update(I32RowIndex, CDB.REPORT_Y, OResult.OFaultResult.F64Y);
                    OTable.Update(I32RowIndex, CDB.REPORT_REFERANCE, OResult.OFaultResult.StrReferance);
                    OTable.Update(I32RowIndex, CDB.REPORT_FILE, StrFile);

                    OTable.Update(I32RowIndex, CDB.REPORT_SUBSTANCE, OResult.StrBlobName);
                    if (OResult.BIsBlobNG == true)
                    {
                        OTable.Update(I32RowIndex, CDB.REPORT_SUBSTANCE_X_LENGTH, OResult.F64BlobXLength);
                        OTable.Update(I32RowIndex, CDB.REPORT_SUBSTANCE_Y_LENGTH, OResult.F64BlobYLength);
                        OTable.Update(I32RowIndex, CDB.REPORT_SUBSTANCE_PERIMETER, OResult.F64BlobPerimeter);
                        OTable.Update(I32RowIndex, CDB.REPORT_SUBSTANCE_AREA, OResult.F64BlobArea);
                        OTable.Update(I32RowIndex, CDB.REPORT_SUBSTANCE_ELONGATION, OResult.F64Elongation);
                    }
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }
                finally
                {
                    OTable.EndSyncData();
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private CImageInfo GetImageInfo()
        {
            CImageInfo OResult = null;

            try
            {
                Monitor.Enter(this.m_OImageInterrupt);

                if (this.m_LstOImageInfo.Count > 0)
                {
                    OResult = this.m_LstOImageInfo[0];
                    this.m_LstOImageInfo.RemoveAt(0);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(this.m_OImageInterrupt);
            }

            return OResult;
        }


        private void OnRecipeChanged(CDiaperFaultRecipe ORecipe)
        {
            try
            {
                if (this.RecipeChanged != null)
                {
                    this.RecipeChanged(ORecipe);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void OnInspected(CDiaperFaultResult OResult)
        {
            try
            {
                if (this.Inspected != null)
                {
                    this.Inspected(OResult);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void OnSaveOKImage()
        {
            try
            {
                if (this.SaveOKImage != null)
                {
                    this.SaveOKImage(this.m_I32SaveOKCount);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void Dispose()
        {
            try
            {
                this.EndWork();
                

                if (this.m_OBlobTool != null)
                {
                    this.m_OBlobTool.Dispose();
                    this.m_OBlobTool = null;
                }
                if (this.m_OHistogramTool != null)
                {
                    this.m_OHistogramTool.Dispose();
                    this.m_OHistogramTool = null;
                }
                if (this.m_OCaliperTool != null)
                {
                    this.m_OCaliperTool.Dispose();
                    this.m_OCaliperTool = null;
                }
                if (this.m_OCopyRegionTool != null)
                {
                    this.m_OCopyRegionTool.Dispose();
                    this.m_OCopyRegionTool = null;
                }
                if (this.m_LstOImageInfo != null)
                {
                    this.m_LstOImageInfo.Clear();
                    this.m_LstOImageInfo = null;
                }
                if (this.m_ORecipe != null)
                {
                    this.m_ORecipe.Dispose();
                    this.m_ORecipe = null;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
    }
}
