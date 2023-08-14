using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Common;
using Cognex.VisionPro.Display;
using System.Threading;
using Cognex.VisionPro;

namespace YKCJ_Diaper
{
    public class CMainImageHelperTool : IDisposable
    {
        #region VARIABLE
        private CogDisplay m_ODisplayer = null;
        private CDiaperFaultRecipe m_ODrawRecipe = null;
        private CogLine m_OLineX = null;
        private CogLine m_OLineY = null;
        private CogPointMarker[] m_ArrOMDMarker = null;
        private CogPointMarker[] m_ArrOCDMarker = null;
        private int m_I32MD = 0;
        private int m_I32CD = 0;
        private object m_ODisplayInterrupt = null;

        private CDiaperFaultRecipe m_OWaitRecipe = null;
        private List<CDiaperFaultResult> m_LstOResult = null;
        private object m_OInterrupt = null;

        private Thread m_OWorker = null;
        private bool m_BDoWork = false;
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CMainImageHelperTool(CogDisplay ODisplayer)
        {
            try
            {
                this.m_ODisplayer = ODisplayer;
                this.m_ODisplayInterrupt = new object();

                this.m_OLineX = new CogLine();
                this.m_OLineX.X = 100;
                this.m_OLineX.Color = CogColorConstants.Red;
                this.m_OLineX.Visible = false;
                this.m_ODisplayer.InteractiveGraphics.Add(this.m_OLineX, "LineX", true);

                this.m_OLineY = new CogLine();
                this.m_OLineY.Y = 100;
                this.m_OLineY.Color = CogColorConstants.Red;
                this.m_OLineY.Visible = false;
                this.m_OLineY.Rotation = CogMisc.DegToRad(90);
                this.m_ODisplayer.InteractiveGraphics.Add(this.m_OLineY, "LineY", true);

                this.m_ArrOMDMarker = new CogPointMarker[CDiaperFaultRecipe.MD_COUNT];
                for (int _Index = 0; _Index < CDiaperFaultRecipe.MD_COUNT; _Index++)
                {
                    this.m_ArrOMDMarker[_Index] = new CogPointMarker();
                    this.m_ArrOMDMarker[_Index].Color = CogColorConstants.Yellow;
                    this.m_ArrOMDMarker[_Index].SizeInScreenPixels = 30;
                    this.m_ArrOMDMarker[_Index].Visible = false;
                }

                this.m_ArrOCDMarker = new CogPointMarker[CDiaperFaultRecipe.CD_COUNT];
                for (int _Index = 0; _Index < CDiaperFaultRecipe.CD_COUNT; _Index++)
                {
                    this.m_ArrOCDMarker[_Index] = new CogPointMarker();
                    this.m_ArrOCDMarker[_Index].Color = CogColorConstants.Yellow;
                    this.m_ArrOCDMarker[_Index].SizeInScreenPixels = 30;
                    this.m_ArrOCDMarker[_Index].Visible = false;
                }

                this.m_LstOResult = new List<CDiaperFaultResult>();
                this.m_OInterrupt = new object();

                this.BeginWork();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        ~CMainImageHelperTool()
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
                CDiaperFaultRecipe ORecipe = null;
                CDiaperFaultResult OResult = null;

                while (this.m_BDoWork == true)
                {
                    try
                    {
                        this.GetDrawingObject(out ORecipe, out OResult);

                        if ((ORecipe != null) || (OResult != null))
                        {
                            this.DrawObject(ORecipe, OResult);
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


        public void SetRecipe(CDiaperFaultRecipe ORecipe)
        {
            try
            {
                Monitor.Enter(this.m_OInterrupt);

                this.m_OWaitRecipe = ORecipe;
                this.m_LstOResult.Clear();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(this.m_OInterrupt);
            }
        }


        public void SetResult(CDiaperFaultResult OResult)
        {
            try
            {
                Monitor.Enter(this.m_OInterrupt);

                this.m_LstOResult.Add(OResult);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(this.m_OInterrupt);
            }
        }


        private void GetDrawingObject(out CDiaperFaultRecipe ORecipe, out CDiaperFaultResult OResult)
        {
            ORecipe = null;
            OResult = null;

            try
            {
                Monitor.Enter(this.m_OInterrupt);

                if (this.m_OWaitRecipe != null)
                {
                    ORecipe = this.m_OWaitRecipe;
                    this.m_OWaitRecipe = null;
                }

                if (this.m_LstOResult.Count > 0)
                {
                    OResult = this.m_LstOResult[this.m_LstOResult.Count - 1];
                    this.m_LstOResult.Clear();
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(this.m_OInterrupt);
            }
        }


        private void DrawObject(CDiaperFaultRecipe ORecipe, CDiaperFaultResult OResult)
        {
            try
            {
                Monitor.Enter(this.m_ODisplayInterrupt);
                this.m_ODisplayer.DrawingEnabled = false;


                if (ORecipe != null)
                {
                    this.m_ODrawRecipe = ORecipe;
                    this.ReadyRecipe();
                }


                this.m_ODisplayer.StaticGraphics.Clear();

                if (OResult != null)
                {
                    this.m_ODisplayer.Image = OResult.OImageInfo.OImage;
                }
                if (this.m_ODrawRecipe != null)
                {
                    if ((OResult != null) && (OResult.BInspected == true))
                    {
                        this.DrawBlobResult(this.m_ODrawRecipe, OResult);
                        this.DrawPatternResult(this.m_ODrawRecipe, OResult);
                        this.DrawMDResult(this.m_ODrawRecipe, OResult);
                        this.DrawCDResult(this.m_ODrawRecipe, OResult);
                    }
                    else
                    {
                        this.DrawBlobNoResult(this.m_ODrawRecipe);
                        this.DrawPatternNoResult(this.m_ODrawRecipe);
                        this.DrawMDNoResult(this.m_ODrawRecipe);
                        this.DrawCDNoResult(this.m_ODrawRecipe);
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                this.m_ODisplayer.DrawingEnabled = true;
                Monitor.Exit(this.m_ODisplayInterrupt);
            }
        }


        private void ReadyRecipe()
        {
            try
            {
                this.m_ODrawRecipe.LoadROI();

                foreach (CBlobRecipe _Item in this.m_ODrawRecipe.ArrOBlob)
                {
                    if (_Item.BEnabled == false) continue;

                    CTextAttach OCurrent = new CTextAttach();
                    OCurrent.StrTag = "BLOB" + _Item.I32Index + " CURRENT";
                    OCurrent.OText.Alignment = CogGraphicLabelAlignmentConstants.TopCenter;
                    OCurrent.OText.BackgroundColor = CogColorConstants.Yellow;
                    OCurrent.ELineAlignment = EATTACH_LINEALIGNMENT.TOP;
                    OCurrent.EAlignment = EATTACH_ALIGNMENT.CENTER;
                    OCurrent.F64AdjustY = 10;
                    _Item.OROI.AddAttach(OCurrent);

                    CTextAttach ODiffer = new CTextAttach();
                    ODiffer.StrTag = "BLOB" + _Item.I32Index + " DIFFER";
                    ODiffer.OText.Alignment = CogGraphicLabelAlignmentConstants.TopCenter;
                    ODiffer.OText.BackgroundColor = CogColorConstants.Green;
                    ODiffer.ELineAlignment = EATTACH_LINEALIGNMENT.TOP;
                    ODiffer.EAlignment = EATTACH_ALIGNMENT.CENTER;
                    ODiffer.F64AdjustY = 60;
                    _Item.OROI.AddAttach(ODiffer);
                }

                foreach (CPatternRecipe _Item in this.m_ODrawRecipe.ArrOPattern)
                {
                    if (_Item.BEnabled == false) continue;

                    CTextAttach OScore = new CTextAttach();
                    OScore.OText.Alignment = CogGraphicLabelAlignmentConstants.TopCenter;
                    OScore.StrTag = "PATTERN" + _Item.I32Index + " SCORE";
                    _Item.OROI.AddAttach(OScore);
                }

                for (int _Index = 0; _Index < this.m_ODrawRecipe.ArrOMD.Length; _Index++)
                {
                    if (this.m_ODrawRecipe.ArrOMD[_Index].BEnabled == false)
                    {
                        this.m_ArrOMDMarker[_Index].Visible = false;
                        continue;
                    }
                    else
                    {
                        this.m_ArrOMDMarker[_Index].Visible = true;

                        CTextAttach ODiffer = new CTextAttach();
                        ODiffer.OText.Alignment = CogGraphicLabelAlignmentConstants.TopCenter;
                        ODiffer.F64AdjustY = -20;
                        ODiffer.StrTag = "MD" + this.m_ODrawRecipe.ArrOMD + " DIFFER";
                        this.m_ODrawRecipe.ArrOMD[_Index].OROI.AddAttach(ODiffer);
                    }
                }

                for (int _Index = 0; _Index < this.m_ODrawRecipe.ArrOCD.Length; _Index++)
                {
                    if (this.m_ODrawRecipe.ArrOCD[_Index].BEnabled == false)
                    {
                        this.m_ArrOCDMarker[_Index].Visible = false;
                        continue;
                    }
                    else
                    {
                        this.m_ArrOCDMarker[_Index].Visible = true;

                        CTextAttach ODiffer = new CTextAttach();
                        ODiffer.OText.Alignment = CogGraphicLabelAlignmentConstants.TopCenter;
                        ODiffer.F64AdjustY = -20;
                        ODiffer.StrTag = "CD" + this.m_ODrawRecipe.ArrOCD + " DIFFER";
                        this.m_ODrawRecipe.ArrOCD[_Index].OROI.AddAttach(ODiffer);
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void DrawBlobResult(CDiaperFaultRecipe ORecipe, CDiaperFaultResult OResult)
        {
            try
            {
                string StrCurrent = string.Empty;
                string StrDiffer = string.Empty;

                foreach (CBlobRecipe _Item1 in ORecipe.ArrOBlob)
                {
                    if (_Item1.BEnabled == false) continue;

                    if (_Item1.StrMD.Equals(CDiaperFaultRecipe.NONE) == false)
                    {
                        this.m_I32MD = Convert.ToInt32(_Item1.StrMD);

                        foreach (CFollowResult _Item2 in OResult.ArrOMD)
                        {
                            if (_Item2.I32Index != this.m_I32MD) continue;

                            _Item1.OROI.F64AdjustX = _Item2.F64Differ;
                            break;
                        }
                    }
                    if (_Item1.StrCD.Equals(CDiaperFaultRecipe.NONE) == false)
                    {
                        this.m_I32CD = Convert.ToInt32(_Item1.StrCD);

                        foreach (CFollowResult _Item2 in OResult.ArrOCD)
                        {
                            if (_Item2.I32Index != this.m_I32CD) continue;

                            _Item1.OROI.F64AdjustY = _Item2.F64Differ;
                            break;
                        }
                    }
                    _Item1.OROI.Refresh();
                    _Item1.OROI.Follow();

                    this.m_ODisplayer.StaticGraphics.Add(_Item1.OROI.OGraphic, "BLOB" + _Item1.I32Index);

                    StrCurrent = "BLOB" + _Item1.I32Index + " CURRENT";
                    StrDiffer = "BLOB" + _Item1.I32Index + " DIFFER";
                    foreach (CBlobResult _Item2 in OResult.ArrOBlob)
                    {
                        if (_Item1.I32Index != _Item2.I32Index) continue;

                        foreach (CTextAttach _Item3 in _Item1.OROI.LstOAttach)
                        {
                            if (_Item3.StrTag == StrCurrent)
                            {
                                _Item3.OText.Text = "B" + _Item1.I32Index + "_(" + _Item2.I32CurrentThreshold + ")";
                            }
                            else if (_Item3.StrTag == StrDiffer)
                            {
                                if (_Item1.EPolarity == Cognex.VisionPro.Blob.CogBlobSegmentationPolarityConstants.DarkBlobs)
                                {
                                    _Item3.OText.Text = "B" + _Item1.I32Index + "_D" + (_Item2.I32CurrentThreshold - _Item2.I32AverageThreshold);
                                }
                                else
                                {
                                    _Item3.OText.Text = "B" + _Item1.I32Index + "_W" + (_Item2.I32CurrentThreshold - _Item2.I32AverageThreshold);
                                }
                            }
                            this.m_ODisplayer.StaticGraphics.Add(_Item3.OText, _Item3.StrTag);
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void DrawPatternResult(CDiaperFaultRecipe ORecipe, CDiaperFaultResult OResult)
        {
            try
            {
                string StrScore = string.Empty;

                foreach (CPatternRecipe _Item1 in ORecipe.ArrOPattern)
                {
                    if (_Item1.BEnabled == false) continue;

                    if (_Item1.StrMD.Equals(CDiaperFaultRecipe.NONE) == false)
                    {
                        this.m_I32MD = Convert.ToInt32(_Item1.StrMD);

                        foreach (CFollowResult _Item2 in OResult.ArrOMD)
                        {
                            if (_Item2.I32Index != this.m_I32MD) continue;

                            _Item1.OROI.F64AdjustX = _Item2.F64Differ;
                            break;
                        }
                    }
                    if (_Item1.StrCD.Equals(CDiaperFaultRecipe.NONE) == false)
                    {
                        this.m_I32CD = Convert.ToInt32(_Item1.StrCD);

                        foreach (CFollowResult _Item2 in OResult.ArrOCD)
                        {
                            if (_Item2.I32Index != this.m_I32CD) continue;

                            _Item1.OROI.F64AdjustY = _Item2.F64Differ;
                            break;
                        }
                    }
                    _Item1.OROI.Refresh();
                    _Item1.OROI.Follow();

                    this.m_ODisplayer.StaticGraphics.Add(_Item1.OROI.OGraphic, "PATTERN" + _Item1.I32Index);

                    StrScore = "PATTERN" + _Item1.I32Index + " SCORE";
                    foreach (CPatternResult _Item2 in OResult.ArrOPattern)
                    {
                        if (_Item1.I32Index != _Item2.I32Index) continue;

                        foreach (CTextAttach _Item3 in _Item1.OROI.LstOAttach)
                        {
                            if (_Item3.StrTag != StrScore) continue;

                            _Item3.OText.Text = "P" + _Item1.I32Index + "_S(" + Math.Round(_Item2.F64Score * 100) + ")";
                            this.m_ODisplayer.StaticGraphics.Add(_Item3.OText, _Item3.StrTag);
                            break;
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void DrawMDResult(CDiaperFaultRecipe ORecipe, CDiaperFaultResult OResult)
        {
            try
            {
                string StrDiffer = string.Empty;

                for (int _Index1 = 0; _Index1 < ORecipe.ArrOMD.Length; _Index1++)
                {
                    if (ORecipe.ArrOMD[_Index1].BEnabled == false) continue;

                    StrDiffer = "MD" + ORecipe.ArrOMD[_Index1].I32Index + " DIFFER";
                    foreach (CFollowResult _Item2 in OResult.ArrOMD)
                    {
                        if (ORecipe.ArrOMD[_Index1].I32Index != _Item2.I32Index) continue;
                        if ((_Item2.BInspected == false) || (_Item2.BOK == false)) continue;

                        foreach (CTextAttach _Item3 in ORecipe.ArrOMD[_Index1].OROI.LstOAttach)
                        {
                            if (_Item3.StrTag == StrDiffer) continue;

                            _Item3.OText.Text = "MD" + ORecipe.ArrOMD[_Index1].I32Index + "_(" + Math.Round(_Item2.F64Differ) + ")";
                            this.m_ODisplayer.StaticGraphics.Add(_Item3.OText, _Item3.StrTag);

                            this.m_ArrOMDMarker[_Index1].X = OResult.ArrOMD[_Index1].F64X;
                            this.m_ArrOMDMarker[_Index1].Y = OResult.ArrOMD[_Index1].F64Y;
                            this.m_ODisplayer.StaticGraphics.Add(this.m_ArrOMDMarker[_Index1], "MD" + ORecipe.ArrOMD[_Index1].I32Index + " Marker");
                        }
                    }

                    this.m_ODisplayer.StaticGraphics.Add(ORecipe.ArrOMD[_Index1].OROI.OGraphic, "MD" + ORecipe.ArrOMD[_Index1].I32Index);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void DrawCDResult(CDiaperFaultRecipe ORecipe, CDiaperFaultResult OResult)
        {
            try
            {
                string StrDiffer = string.Empty;

                for (int _Index1 = 0; _Index1 < ORecipe.ArrOCD.Length; _Index1++)
                {
                    if (ORecipe.ArrOCD[_Index1].BEnabled == false) continue;

                    StrDiffer = "CD" + ORecipe.ArrOCD[_Index1].I32Index + " DIFFER";
                    foreach (CFollowResult _Item2 in OResult.ArrOCD)
                    {
                        if (ORecipe.ArrOCD[_Index1].I32Index != _Item2.I32Index) continue;
                        if ((_Item2.BInspected == false) || (_Item2.BOK == false)) continue;

                        foreach (CTextAttach _Item3 in ORecipe.ArrOCD[_Index1].OROI.LstOAttach)
                        {
                            if (_Item3.StrTag == StrDiffer) continue;

                            _Item3.OText.Text = "CD" + ORecipe.ArrOCD[_Index1].I32Index + "_(" + Math.Round(_Item2.F64Differ) + ")";
                            this.m_ODisplayer.StaticGraphics.Add(_Item3.OText, _Item3.StrTag);

                            this.m_ArrOCDMarker[_Index1].X = OResult.ArrOCD[_Index1].F64X;
                            this.m_ArrOCDMarker[_Index1].Y = OResult.ArrOCD[_Index1].F64Y;
                            this.m_ODisplayer.StaticGraphics.Add(this.m_ArrOCDMarker[_Index1], "CD" + ORecipe.ArrOCD[_Index1].I32Index + " Marker");
                        }
                    }

                    this.m_ODisplayer.StaticGraphics.Add(ORecipe.ArrOCD[_Index1].OROI.OGraphic, "CD" + ORecipe.ArrOCD[_Index1].I32Index);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void DrawBlobNoResult(CDiaperFaultRecipe ORecipe)
        {
            try
            {
                string StrCurrent = string.Empty;
                string StrDiffer = string.Empty;

                foreach (CBlobRecipe _Item1 in ORecipe.ArrOBlob)
                {
                    if (_Item1.BEnabled == false) continue;

                    _Item1.OROI.F64AdjustX = 0;
                    _Item1.OROI.F64AdjustY = 0;
                    _Item1.OROI.Refresh();
                    _Item1.OROI.Follow();
                    this.m_ODisplayer.StaticGraphics.Add(_Item1.OROI.OGraphic, "BLOB" + _Item1.I32Index);

                    StrCurrent = "BLOB" + _Item1.I32Index + " CURRENT";
                    foreach (CTextAttach _Item3 in _Item1.OROI.LstOAttach)
                    {
                        if (_Item3.StrTag != StrCurrent) continue;

                        _Item3.OText.Text = "B" + _Item1.I32Index;
                        this.m_ODisplayer.StaticGraphics.Add(_Item3.OText, _Item3.StrTag);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void DrawPatternNoResult(CDiaperFaultRecipe ORecipe)
        {
            try
            {
                string StrScore = string.Empty;

                foreach (CPatternRecipe _Item1 in ORecipe.ArrOPattern)
                {
                    if (_Item1.BEnabled == false) continue;

                    _Item1.OROI.F64AdjustX = 0;
                    _Item1.OROI.F64AdjustY = 0;
                    _Item1.OROI.Refresh();
                    _Item1.OROI.Follow();
                    this.m_ODisplayer.StaticGraphics.Add(_Item1.OROI.OGraphic, "PATTERN" + _Item1.I32Index);

                    StrScore = "PATTERN" + _Item1.I32Index + " SCORE";
                    foreach (CTextAttach _Item3 in _Item1.OROI.LstOAttach)
                    {
                        if (_Item3.StrTag != StrScore) continue;

                        _Item3.OText.Text = "P" + _Item1.I32Index;
                        this.m_ODisplayer.StaticGraphics.Add(_Item3.OText, _Item3.StrTag);
                        break;
                    }
                    break;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void DrawMDNoResult(CDiaperFaultRecipe ORecipe)
        {
            try
            {
                string StrDiffer = string.Empty;

                for (int _Index1 = 0; _Index1 < ORecipe.ArrOMD.Length; _Index1++)
                {
                    if (ORecipe.ArrOMD[_Index1].BEnabled == false) continue;

                    this.m_ODisplayer.StaticGraphics.Add(ORecipe.ArrOMD[_Index1].OROI.OGraphic, "MD" + ORecipe.ArrOMD[_Index1].I32Index);

                    StrDiffer = "MD" + ORecipe.ArrOMD[_Index1].I32Index + " DIFFER";
                    foreach (CTextAttach _Item3 in ORecipe.ArrOMD[_Index1].OROI.LstOAttach)
                    {
                        if (_Item3.StrTag == StrDiffer) continue;

                        _Item3.OText.Text = "MD" + ORecipe.ArrOMD[_Index1].I32Index;
                        this.m_ODisplayer.StaticGraphics.Add(_Item3.OText, _Item3.StrTag);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void DrawCDNoResult(CDiaperFaultRecipe ORecipe)
        {
            try
            {
                string StrDiffer = string.Empty;

                for (int _Index1 = 0; _Index1 < ORecipe.ArrOCD.Length; _Index1++)
                {
                    if (ORecipe.ArrOCD[_Index1].BEnabled == false) continue;

                    this.m_ODisplayer.StaticGraphics.Add(ORecipe.ArrOCD[_Index1].OROI.OGraphic, "CD" + ORecipe.ArrOCD[_Index1].I32Index);

                    StrDiffer = "CD" + ORecipe.ArrOCD[_Index1].I32Index + " DIFFER";
                    foreach (CTextAttach _Item3 in ORecipe.ArrOCD[_Index1].OROI.LstOAttach)
                    {
                        if (_Item3.StrTag == StrDiffer) continue;

                        _Item3.OText.Text = "CD" + ORecipe.ArrOCD[_Index1].I32Index;
                        this.m_ODisplayer.StaticGraphics.Add(_Item3.OText, _Item3.StrTag);
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void DrawCenterLine(bool BVisible, double F64X, double F64Y)
        {
            try
            {
                Monitor.Enter(this.m_ODisplayInterrupt);

                if (BVisible == true)
                {
                    this.m_OLineX.Y = F64Y;
                    this.m_OLineY.X = F64X;
                }
                this.m_OLineX.Visible = BVisible;
                this.m_OLineY.Visible = BVisible;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(this.m_ODisplayInterrupt);
            }
        }


        public void Dispose()
        {
            try
            {
                this.EndWork();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
    }
}
