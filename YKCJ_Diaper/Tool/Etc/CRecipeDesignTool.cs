using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.Caliper;
using Jhjo.Common;
using Daekhon.Common;

namespace YKCJ_Diaper
{
    public class CRecipeDesignTool
    {
        #region VARIABLE
        private CDiaperFaultRecipe m_ORecipe = null;
        private CogCaliperTool m_OMDCDTool = null;

        private CogDisplay m_OCdpImage = null;
        private CogPointMarker m_OCenterLine = null;
        private IRecipe m_OFocusedRecipe = null;
        private bool m_BDisplayAll = true;
        #endregion


        #region PROPERTIES
        public CDiaperFaultRecipe ORecipe
        {
            get { return this.m_ORecipe; }
            set
            {
                this.m_ORecipe = value;
                this.m_OFocusedRecipe = null;
            }
        }


        public CogCaliperTool OMDCDTool
        {
            get { return this.m_OMDCDTool; }
        }


        public CogDisplay OCdpImage
        {
            get { return this.m_OCdpImage; }
        }


        public CogPointMarker OCenterLine
        {
            get { return this.m_OCenterLine; }
        }


        public bool BDisplayAll
        {
            get { return this.m_BDisplayAll; }
            set { this.m_BDisplayAll = value; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CRecipeDesignTool(CogDisplay OCdpImage)
        {
            try
            {
                this.m_OCdpImage = OCdpImage;

                this.m_OMDCDTool = new CogCaliperTool();
                this.m_OMDCDTool.RunParams.MaxResults = 1;

                this.m_OCenterLine = new CogPointMarker();
                this.m_OCenterLine.X = 100;
                this.m_OCenterLine.Y = 100;
                this.m_OCenterLine.Color = CogColorConstants.Red;
                this.m_OCenterLine.SelectedColor = CogColorConstants.Red;
                this.m_OCenterLine.DragColor = CogColorConstants.Red;
                this.m_OCenterLine.SizeInScreenPixels = 50;
                this.m_OCenterLine.Visible = false;
                this.m_OCenterLine.Interactive = true;
                this.m_OCenterLine.GraphicDOFEnable = CogPointMarkerDOFConstants.All;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion


        #region EVENT
        private void OROI_DraggingStopped(object sender, Cognex.VisionPro.CogDraggingEventArgs e)
        {
            try
            {
                this.m_OCdpImage.DrawingEnabled = false;


                if (e.DragGraphic == null) return;
                if (e.DragGraphic.GetType() == typeof(CogGraphicLabel)) return;


                string[] ArrStrInfo = e.DragGraphic.TipText.Split('\\');
                int I32Index = Convert.ToInt32(ArrStrInfo[1]);
                CogRectangle OBound = ((ICogRegion)e.DragGraphic).EnclosingRectangle(CogCopyShapeConstants.All);

                if (ArrStrInfo[0] == "BLOB")
                {
                    for (int _Index = 0; _Index < this.m_ORecipe.ArrOBlob.Length; _Index++)
                    {
                        if (this.m_ORecipe.ArrOBlob[_Index].I32Index != I32Index) continue;

                        this.m_ORecipe.ArrOBlob[_Index].StrAlignmentTarget = CDiaperFaultRecipe.NONE;
                        this.m_ORecipe.ArrOBlob[_Index].StrAlignmentIndex = CDiaperFaultRecipe.NONE;
                        this.m_ORecipe.ArrOBlob[_Index].StrAlignmentSource = CDiaperFaultRecipe.NONE;

                        this.m_ORecipe.ArrOBlob[_Index].OROI.ResetAttach(OBound);
                        this.DoAlignment(this.m_ORecipe.ArrOBlob[_Index], OBound);
                        break;
                    }
                }
                else if (ArrStrInfo[0] == "PATTERN")
                {
                    foreach (CPatternRecipe _Item in this.m_ORecipe.ArrOPattern)
                    {
                        if (_Item.I32Index != I32Index) continue;

                        _Item.OROI.ResetAttach(OBound);
                        break;
                    }
                }
                else if (ArrStrInfo[0] == "MD")
                {
                    foreach (CFollowRecipe _Item in this.m_ORecipe.ArrOMD)
                    {
                        if (_Item.I32Index != I32Index) continue;

                        _Item.OROI.ResetAttach(OBound);
                        break;
                    }
                }
                else if (ArrStrInfo[0] == "CD")
                {
                    foreach (CFollowRecipe _Item in this.m_ORecipe.ArrOCD)
                    {
                        if (_Item.I32Index != I32Index) continue;

                        _Item.OROI.ResetAttach(OBound);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
            finally
            {
                this.m_OCdpImage.DrawingEnabled = true;
            }
        }
        #endregion


        #region FUNCTION
        public void Refresh()
        {
            try
            {
                if (this.m_ORecipe == null) return;
                this.m_OCdpImage.StaticGraphics.Clear();
                this.m_OCdpImage.InteractiveGraphics.Clear();

                this.m_OCdpImage.InteractiveGraphics.Add(this.m_OCenterLine, "CenterLine", true);


                if (this.m_BDisplayAll == true)
                {
                    foreach (CBlobRecipe _Item1 in this.m_ORecipe.ArrOBlob)
                    {
                        if (_Item1.BEnabled == false) continue;

                        if (_Item1.OROI.BDisplayed == false)
                        {
                            CTextAttach OAttach = new CTextAttach();
                            OAttach.OText.Text = "B" + _Item1.I32Index;
                            OAttach.OText.Color = CogColorConstants.Blue;
                            OAttach.StrTag = "BLOB No" + _Item1.I32Index;

                            _Item1.OROI.BDisplayed = true;
                            _Item1.OROI.OGraphic.Interactive = true;
                            _Item1.OROI.OGraphic.GraphicDOFEnableBase = CogGraphicDOFConstants.All;
                            _Item1.OROI.OGraphic.TipText = "BLOB\\" + _Item1.I32Index.ToString();
                            _Item1.OROI.OGraphic.DraggingStopped += new CogDraggingStoppedEventHandler(this.OROI_DraggingStopped);
                            _Item1.OROI.AddAttach(OAttach);
                        }


                        _Item1.OROI.OGraphic.Color = CogColorConstants.Blue;
                        _Item1.OROI.OGraphic.SelectedColor = CogColorConstants.Blue;
                        this.m_OCdpImage.InteractiveGraphics.Add(_Item1.OROI.OGraphic, "BLOB" + _Item1.I32Index, true);

                        foreach (IAttach _Item2 in _Item1.OROI.LstOAttach)
                        {
                            _Item2.OGraphic.Color = CogColorConstants.Blue;
                            this.m_OCdpImage.InteractiveGraphics.Add(_Item2.OGraphic, _Item2.StrTag, true);
                        }
                    }

                    foreach (CPatternRecipe _Item1 in this.m_ORecipe.ArrOPattern)
                    {
                        if (_Item1.BEnabled == false) continue;

                        if (_Item1.OROI.BDisplayed == false)
                        {
                            CTextAttach OAttach = new CTextAttach();
                            OAttach.OText.Text = "P" + _Item1.I32Index;
                            OAttach.OText.Color = CogColorConstants.Green;
                            OAttach.StrTag = "Pattern No" + _Item1.I32Index;

                            _Item1.OROI.BDisplayed = true;
                            _Item1.OROI.OGraphic.Interactive = true;
                            _Item1.OROI.OGraphic.GraphicDOFEnableBase = CogGraphicDOFConstants.All;
                            _Item1.OROI.OGraphic.TipText = "PATTERN\\" + _Item1.I32Index.ToString();
                            _Item1.OROI.OGraphic.DraggingStopped += new CogDraggingStoppedEventHandler(this.OROI_DraggingStopped);
                            _Item1.OROI.AddAttach(OAttach);
                        }


                        _Item1.OROI.OGraphic.Color = CogColorConstants.Green;
                        _Item1.OROI.OGraphic.SelectedColor = CogColorConstants.Green;
                        this.m_OCdpImage.InteractiveGraphics.Add(_Item1.OROI.OGraphic, "PATTERN" + _Item1.I32Index, true);

                        foreach (IAttach _Item2 in _Item1.OROI.LstOAttach)
                        {
                            _Item2.OGraphic.Color = CogColorConstants.Green;
                            this.m_OCdpImage.InteractiveGraphics.Add(_Item2.OGraphic, _Item2.StrTag, true);
                        }
                    }

                    foreach (CFollowRecipe _Item1 in this.m_ORecipe.ArrOMD)
                    {
                        if (_Item1.BEnabled == false) continue;

                        if (_Item1.OROI.BDisplayed == false)
                        {
                            CTextAttach OAttach = new CTextAttach();
                            OAttach.OText.Text = "MD" + _Item1.I32Index;
                            OAttach.OText.Color = CogColorConstants.Yellow;
                            OAttach.StrTag = "MD No" + _Item1.I32Index;

                            _Item1.OROI.BDisplayed = true;
                            _Item1.OROI.OGraphic.Interactive = true;
                            ((CogRectangleAffine)_Item1.OROI.OGraphic).GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size;
                            _Item1.OROI.OGraphic.TipText = "MD\\" + _Item1.I32Index.ToString();
                            _Item1.OROI.OGraphic.DraggingStopped += new CogDraggingStoppedEventHandler(this.OROI_DraggingStopped);
                            _Item1.OROI.AddAttach(OAttach);
                        }


                        _Item1.OROI.OGraphic.Color = CogColorConstants.Yellow;
                        _Item1.OROI.OGraphic.SelectedColor = CogColorConstants.Yellow;
                        this.m_OCdpImage.InteractiveGraphics.Add(_Item1.OROI.OGraphic, "MD" + _Item1.I32Index, true);

                        foreach (IAttach _Item2 in _Item1.OROI.LstOAttach)
                        {
                            _Item2.OGraphic.Color = CogColorConstants.Yellow;
                            this.m_OCdpImage.InteractiveGraphics.Add(_Item2.OGraphic, _Item2.StrTag, true);
                        }
                    }

                    foreach (CFollowRecipe _Item1 in this.m_ORecipe.ArrOCD)
                    {
                        if (_Item1.BEnabled == false) continue;

                        if (_Item1.OROI.BDisplayed == false)
                        {
                            CTextAttach OAttach = new CTextAttach();
                            OAttach.OText.Text = "CD" + _Item1.I32Index;
                            OAttach.OText.Color = CogColorConstants.Yellow;
                            OAttach.StrTag = "CD No" + _Item1.I32Index;

                            _Item1.OROI.BDisplayed = true;
                            _Item1.OROI.OGraphic.Interactive = true;
                            ((CogRectangleAffine)_Item1.OROI.OGraphic).GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size;
                            _Item1.OROI.OGraphic.TipText = "CD\\" + _Item1.I32Index.ToString();
                            _Item1.OROI.OGraphic.DraggingStopped += new CogDraggingStoppedEventHandler(this.OROI_DraggingStopped);
                            _Item1.OROI.AddAttach(OAttach);
                        }


                        _Item1.OROI.OGraphic.Color = CogColorConstants.Yellow;
                        _Item1.OROI.OGraphic.SelectedColor = CogColorConstants.Yellow;
                        this.m_OCdpImage.InteractiveGraphics.Add(_Item1.OROI.OGraphic, "CD" + _Item1.I32Index, true);

                        foreach (IAttach _Item2 in _Item1.OROI.LstOAttach)
                        {
                            _Item2.OGraphic.Color = CogColorConstants.Yellow;
                            this.m_OCdpImage.InteractiveGraphics.Add(_Item2.OGraphic, _Item2.StrTag, true);
                        }
                    }
                }

                if (this.m_OFocusedRecipe != null)
                {
                    if (this.m_BDisplayAll == true)
                    {
                        if (this.m_OFocusedRecipe.GetType() == typeof(CBlobRecipe))
                        {
                            CBlobRecipe ORecipe = (CBlobRecipe)this.m_OFocusedRecipe;
                            ORecipe.OROI.OGraphic.Color = CogColorConstants.Red;
                            ORecipe.OROI.OGraphic.SelectedColor = CogColorConstants.Red;

                            foreach (IAttach _Item in ORecipe.OROI.LstOAttach)
                            {
                                _Item.OGraphic.Color = CogColorConstants.Red;
                            }
                        }
                        else if (this.m_OFocusedRecipe.GetType() == typeof(CPatternRecipe))
                        {
                            CPatternRecipe ORecipe = (CPatternRecipe)this.m_OFocusedRecipe;
                            ORecipe.OROI.OGraphic.Color = CogColorConstants.Red;
                            ORecipe.OROI.OGraphic.SelectedColor = CogColorConstants.Red;

                            foreach (IAttach _Item in ORecipe.OROI.LstOAttach)
                            {
                                _Item.OGraphic.Color = CogColorConstants.Red;
                            }
                        }
                        else if (this.m_OFocusedRecipe.GetType() == typeof(CFollowRecipe))
                        {
                            CFollowRecipe ORecipe = (CFollowRecipe)this.m_OFocusedRecipe;
                            ORecipe.OROI.OGraphic.Color = CogColorConstants.Red;
                            ORecipe.OROI.OGraphic.SelectedColor = CogColorConstants.Red;

                            foreach (IAttach _Item in ORecipe.OROI.LstOAttach)
                            {
                                _Item.OGraphic.Color = CogColorConstants.Red;
                            }
                        }
                    }
                    else
                    {
                        if (this.m_OFocusedRecipe.GetType() == typeof(CBlobRecipe))
                        {
                            CBlobRecipe ORecipe = (CBlobRecipe)this.m_OFocusedRecipe;
                            if (ORecipe.BEnabled == false) return;

                            if (ORecipe.OROI.BDisplayed == false)
                            {
                                CTextAttach OAttach = new CTextAttach();
                                OAttach.OText.Text = "B" + ORecipe.I32Index;
                                OAttach.OText.Color = CogColorConstants.Blue;
                                OAttach.StrTag = "BLOB No" + ORecipe.I32Index;

                                ORecipe.OROI.BDisplayed = true;
                                ORecipe.OROI.OGraphic.Interactive = true;
                                ORecipe.OROI.OGraphic.GraphicDOFEnableBase = CogGraphicDOFConstants.All;
                                ORecipe.OROI.OGraphic.TipText = "BLOB\\" + ORecipe.I32Index.ToString();
                                ORecipe.OROI.OGraphic.DraggingStopped += new CogDraggingStoppedEventHandler(this.OROI_DraggingStopped);
                                ORecipe.OROI.AddAttach(OAttach);
                            }

                            ORecipe.OROI.OGraphic.Color = CogColorConstants.Blue;
                            ORecipe.OROI.OGraphic.SelectedColor = CogColorConstants.Blue;
                            this.m_OCdpImage.InteractiveGraphics.Add(ORecipe.OROI.OGraphic, "BLOB" + ORecipe.I32Index, true);

                            foreach (IAttach _Item in ORecipe.OROI.LstOAttach)
                            {
                                _Item.OGraphic.Color = CogColorConstants.Blue;
                                this.m_OCdpImage.InteractiveGraphics.Add(_Item.OGraphic, _Item.StrTag, true);
                            }
                        }
                        else if (this.m_OFocusedRecipe.GetType() == typeof(CPatternRecipe))
                        {
                            CPatternRecipe ORecipe = (CPatternRecipe)this.m_OFocusedRecipe;
                            if (ORecipe.BEnabled == false) return;

                            if (ORecipe.OROI.BDisplayed == false)
                            {
                                CTextAttach OAttach = new CTextAttach();
                                OAttach.OText.Text = "P" + ORecipe.I32Index;
                                OAttach.OText.Color = CogColorConstants.Green;
                                OAttach.StrTag = "Pattern No" + ORecipe.I32Index;

                                ORecipe.OROI.BDisplayed = true;
                                ORecipe.OROI.OGraphic.Interactive = true;
                                ORecipe.OROI.OGraphic.GraphicDOFEnableBase = CogGraphicDOFConstants.All;
                                ORecipe.OROI.OGraphic.TipText = "PATTERN\\" + ORecipe.I32Index.ToString();
                                ORecipe.OROI.OGraphic.DraggingStopped += new CogDraggingStoppedEventHandler(this.OROI_DraggingStopped);
                                ORecipe.OROI.AddAttach(OAttach);
                            }


                            ORecipe.OROI.OGraphic.Color = CogColorConstants.Green;
                            ORecipe.OROI.OGraphic.SelectedColor = CogColorConstants.Green;
                            this.m_OCdpImage.InteractiveGraphics.Add(ORecipe.OROI.OGraphic, "PATTERN" + ORecipe.I32Index, true);

                            foreach (IAttach _Item in ORecipe.OROI.LstOAttach)
                            {
                                _Item.OGraphic.Color = CogColorConstants.Green;
                                this.m_OCdpImage.InteractiveGraphics.Add(_Item.OGraphic, _Item.StrTag, true);
                            }
                        }
                        else if (this.m_OFocusedRecipe.GetType() == typeof(CFollowRecipe))
                        {
                            CFollowRecipe ORecipe = (CFollowRecipe)this.m_OFocusedRecipe;
                            if (ORecipe.BEnabled == false) return;

                            if (ORecipe.EKind == EFOLLOW.MD)
                            {
                                if (ORecipe.OROI.BDisplayed == false)
                                {
                                    CTextAttach OAttach = new CTextAttach();
                                    OAttach.OText.Text = "MD" + ORecipe.I32Index;
                                    OAttach.OText.Color = CogColorConstants.Yellow;
                                    OAttach.StrTag = "MD No" + ORecipe.I32Index;

                                    ORecipe.OROI.BDisplayed = true;
                                    ORecipe.OROI.OGraphic.Interactive = true;
                                    ((CogRectangleAffine)ORecipe.OROI.OGraphic).GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size;
                                    ORecipe.OROI.OGraphic.TipText = "MD\\" + ORecipe.I32Index.ToString();
                                    ORecipe.OROI.OGraphic.DraggingStopped += new CogDraggingStoppedEventHandler(this.OROI_DraggingStopped);
                                    ORecipe.OROI.AddAttach(OAttach);
                                }


                                ORecipe.OROI.OGraphic.Color = CogColorConstants.Yellow;
                                ORecipe.OROI.OGraphic.SelectedColor = CogColorConstants.Yellow;
                                this.m_OCdpImage.InteractiveGraphics.Add(ORecipe.OROI.OGraphic, "MD" + ORecipe.I32Index, true);

                                foreach (IAttach _Item in ORecipe.OROI.LstOAttach)
                                {
                                    _Item.OGraphic.Color = CogColorConstants.Yellow;
                                    this.m_OCdpImage.InteractiveGraphics.Add(_Item.OGraphic, _Item.StrTag, true);
                                }
                            }
                            else if (ORecipe.EKind == EFOLLOW.CD)
                            {
                                if (ORecipe.OROI.BDisplayed == false)
                                {
                                    CTextAttach OAttach = new CTextAttach();
                                    OAttach.OText.Text = "CD" + ORecipe.I32Index;
                                    OAttach.OText.Color = CogColorConstants.Yellow;
                                    OAttach.StrTag = "CD No" + ORecipe.I32Index;

                                    ORecipe.OROI.BDisplayed = true;
                                    ORecipe.OROI.OGraphic.Interactive = true;
                                    ((CogRectangleAffine)ORecipe.OROI.OGraphic).GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size;
                                    ORecipe.OROI.OGraphic.TipText = "CD\\" + ORecipe.I32Index.ToString();
                                    ORecipe.OROI.OGraphic.DraggingStopped += new CogDraggingStoppedEventHandler(this.OROI_DraggingStopped);
                                    ORecipe.OROI.AddAttach(OAttach);
                                }


                                ORecipe.OROI.OGraphic.Color = CogColorConstants.Yellow;
                                ORecipe.OROI.OGraphic.SelectedColor = CogColorConstants.Yellow;
                                this.m_OCdpImage.InteractiveGraphics.Add(ORecipe.OROI.OGraphic, "CD" + ORecipe.I32Index, true);

                                foreach (IAttach _Item in ORecipe.OROI.LstOAttach)
                                {
                                    _Item.OGraphic.Color = CogColorConstants.Yellow;
                                    this.m_OCdpImage.InteractiveGraphics.Add(_Item.OGraphic, _Item.StrTag, true);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void Activate(IRecipe OTarget)
        {
            try
            {
                this.m_OFocusedRecipe = OTarget;

                if (this.m_BDisplayAll == true)
                {
                    if (this.m_OFocusedRecipe != null)
                    {
                        if (this.m_OFocusedRecipe.GetType() == typeof(CBlobRecipe))
                        {
                            CBlobRecipe ORecipe = (CBlobRecipe)this.m_OFocusedRecipe;
                            ORecipe.OROI.OGraphic.Color = CogColorConstants.Red;
                            ORecipe.OROI.OGraphic.SelectedColor = CogColorConstants.Red;

                            foreach (IAttach _Item in ORecipe.OROI.LstOAttach)
                            {
                                _Item.OGraphic.Color = CogColorConstants.Red;
                            }
                        }
                        else if (this.m_OFocusedRecipe.GetType() == typeof(CPatternRecipe))
                        {
                            CPatternRecipe ORecipe = (CPatternRecipe)this.m_OFocusedRecipe;
                            ORecipe.OROI.OGraphic.Color = CogColorConstants.Red;
                            ORecipe.OROI.OGraphic.SelectedColor = CogColorConstants.Red;

                            foreach (IAttach _Item in ORecipe.OROI.LstOAttach)
                            {
                                _Item.OGraphic.Color = CogColorConstants.Red;
                            }
                        }
                        else if (this.m_OFocusedRecipe.GetType() == typeof(CFollowRecipe))
                        {
                            CFollowRecipe ORecipe = (CFollowRecipe)this.m_OFocusedRecipe;
                            ORecipe.OROI.OGraphic.Color = CogColorConstants.Red;
                            ORecipe.OROI.OGraphic.SelectedColor = CogColorConstants.Red;

                            foreach (IAttach _Item in ORecipe.OROI.LstOAttach)
                            {
                                _Item.OGraphic.Color = CogColorConstants.Red;
                            }
                        }
                    }
                }
                else
                {
                    this.m_OCdpImage.StaticGraphics.Clear();
                    this.m_OCdpImage.InteractiveGraphics.Clear();

                    if (this.m_OFocusedRecipe != null)
                    {
                        if (this.m_OFocusedRecipe.GetType() == typeof(CBlobRecipe))
                        {
                            CBlobRecipe ORecipe = (CBlobRecipe)this.m_OFocusedRecipe;
                            if (ORecipe.BEnabled == false) return;

                            if (ORecipe.OROI.BDisplayed == false)
                            {
                                CTextAttach OAttach = new CTextAttach();
                                OAttach.OText.Text = "B" + ORecipe.I32Index;
                                OAttach.OText.Color = CogColorConstants.Blue;
                                OAttach.StrTag = "BLOB No" + ORecipe.I32Index;

                                ORecipe.OROI.BDisplayed = true;
                                ORecipe.OROI.OGraphic.Interactive = true;
                                ORecipe.OROI.OGraphic.GraphicDOFEnableBase = CogGraphicDOFConstants.All;
                                ORecipe.OROI.OGraphic.TipText = "BLOB\\" + ORecipe.I32Index.ToString();
                                ORecipe.OROI.OGraphic.DraggingStopped += new CogDraggingStoppedEventHandler(this.OROI_DraggingStopped);
                                ORecipe.OROI.AddAttach(OAttach);
                            }


                            ORecipe.OROI.OGraphic.Color = CogColorConstants.Blue;
                            ORecipe.OROI.OGraphic.SelectedColor = CogColorConstants.Blue;
                            this.m_OCdpImage.InteractiveGraphics.Add(ORecipe.OROI.OGraphic, "BLOB" + ORecipe.I32Index, true);

                            foreach (IAttach _Item in ORecipe.OROI.LstOAttach)
                            {
                                _Item.OGraphic.Color = CogColorConstants.Blue;
                                this.m_OCdpImage.InteractiveGraphics.Add(_Item.OGraphic, _Item.StrTag, true);
                            }
                        }
                        else if (this.m_OFocusedRecipe.GetType() == typeof(CPatternRecipe))
                        {
                            CPatternRecipe ORecipe = (CPatternRecipe)this.m_OFocusedRecipe;
                            if (ORecipe.BEnabled == false) return;

                            if (ORecipe.OROI.BDisplayed == false)
                            {
                                CTextAttach OAttach = new CTextAttach();
                                OAttach.OText.Text = "P" + ORecipe.I32Index;
                                OAttach.OText.Color = CogColorConstants.Green;
                                OAttach.StrTag = "Pattern No" + ORecipe.I32Index;

                                ORecipe.OROI.BDisplayed = true;
                                ORecipe.OROI.OGraphic.Interactive = true;
                                ORecipe.OROI.OGraphic.GraphicDOFEnableBase = CogGraphicDOFConstants.All;
                                ORecipe.OROI.OGraphic.TipText = "PATTERN\\" + ORecipe.I32Index.ToString();
                                ORecipe.OROI.OGraphic.DraggingStopped += new CogDraggingStoppedEventHandler(this.OROI_DraggingStopped);
                                ORecipe.OROI.AddAttach(OAttach);
                            }


                            ORecipe.OROI.OGraphic.Color = CogColorConstants.Green;
                            ORecipe.OROI.OGraphic.SelectedColor = CogColorConstants.Green;
                            this.m_OCdpImage.InteractiveGraphics.Add(ORecipe.OROI.OGraphic, "PATTERN" + ORecipe.I32Index, true);

                            foreach (IAttach _Item in ORecipe.OROI.LstOAttach)
                            {
                                _Item.OGraphic.Color = CogColorConstants.Green;
                                this.m_OCdpImage.InteractiveGraphics.Add(_Item.OGraphic, _Item.StrTag, true);
                            }
                        }
                        else if (this.m_OFocusedRecipe.GetType() == typeof(CFollowRecipe))
                        {
                            CFollowRecipe ORecipe = (CFollowRecipe)this.m_OFocusedRecipe;
                            if (ORecipe.BEnabled == false) return;

                            if (ORecipe.EKind == EFOLLOW.MD)
                            {
                                if (ORecipe.OROI.BDisplayed == false)
                                {
                                    CTextAttach OAttach = new CTextAttach();
                                    OAttach.OText.Text = "MD" + ORecipe.I32Index;
                                    OAttach.OText.Color = CogColorConstants.Yellow;
                                    OAttach.StrTag = "MD No" + ORecipe.I32Index;

                                    ORecipe.OROI.BDisplayed = true;
                                    ORecipe.OROI.OGraphic.Interactive = true;
                                    ((CogRectangleAffine)ORecipe.OROI.OGraphic).GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size;
                                    ORecipe.OROI.OGraphic.TipText = "MD\\" + ORecipe.I32Index.ToString();
                                    ORecipe.OROI.OGraphic.DraggingStopped += new CogDraggingStoppedEventHandler(this.OROI_DraggingStopped);
                                    ORecipe.OROI.AddAttach(OAttach);
                                }


                                ORecipe.OROI.OGraphic.Color = CogColorConstants.Yellow;
                                ORecipe.OROI.OGraphic.SelectedColor = CogColorConstants.Yellow;
                                this.m_OCdpImage.InteractiveGraphics.Add(ORecipe.OROI.OGraphic, "MD" + ORecipe.I32Index, true);

                                foreach (IAttach _Item in ORecipe.OROI.LstOAttach)
                                {
                                    _Item.OGraphic.Color = CogColorConstants.Yellow;
                                    this.m_OCdpImage.InteractiveGraphics.Add(_Item.OGraphic, _Item.StrTag, true);
                                }
                            }
                            else if (ORecipe.EKind == EFOLLOW.CD)
                            {
                                if (ORecipe.OROI.BDisplayed == false)
                                {
                                    CTextAttach OAttach = new CTextAttach();
                                    OAttach.OText.Text = "CD" + ORecipe.I32Index;
                                    OAttach.OText.Color = CogColorConstants.Yellow;
                                    OAttach.StrTag = "CD No" + ORecipe.I32Index;

                                    ORecipe.OROI.BDisplayed = true;
                                    ORecipe.OROI.OGraphic.Interactive = true;
                                    ((CogRectangleAffine)ORecipe.OROI.OGraphic).GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size;
                                    ORecipe.OROI.OGraphic.TipText = "CD\\" + ORecipe.I32Index.ToString();
                                    ORecipe.OROI.OGraphic.DraggingStopped += new CogDraggingStoppedEventHandler(this.OROI_DraggingStopped);
                                    ORecipe.OROI.AddAttach(OAttach);
                                }


                                ORecipe.OROI.OGraphic.Color = CogColorConstants.Yellow;
                                ORecipe.OROI.OGraphic.SelectedColor = CogColorConstants.Yellow;
                                this.m_OCdpImage.InteractiveGraphics.Add(ORecipe.OROI.OGraphic, "CD" + ORecipe.I32Index, true);

                                foreach (IAttach _Item in ORecipe.OROI.LstOAttach)
                                {
                                    _Item.OGraphic.Color = CogColorConstants.Yellow;
                                    this.m_OCdpImage.InteractiveGraphics.Add(_Item.OGraphic, _Item.StrTag, true);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void DeActivate()
        {
            try
            {
                if (this.m_BDisplayAll == true)
                {
                    if (this.m_OFocusedRecipe.GetType() == typeof(CBlobRecipe))
                    {
                        CBlobRecipe ORecipe = (CBlobRecipe)this.m_OFocusedRecipe;
                        ORecipe.OROI.OGraphic.Color = CogColorConstants.Blue;
                        ORecipe.OROI.OGraphic.SelectedColor = CogColorConstants.Blue;

                        foreach (IAttach _Item in ORecipe.OROI.LstOAttach)
                        {
                            _Item.OGraphic.Color = CogColorConstants.Blue;
                        }
                    }
                    else if (this.m_OFocusedRecipe.GetType() == typeof(CPatternRecipe))
                    {
                        CPatternRecipe ORecipe = (CPatternRecipe)this.m_OFocusedRecipe;
                        ORecipe.OROI.OGraphic.Color = CogColorConstants.Green;
                        ORecipe.OROI.OGraphic.SelectedColor = CogColorConstants.Green;

                        foreach (IAttach _Item in ORecipe.OROI.LstOAttach)
                        {
                            _Item.OGraphic.Color = CogColorConstants.Green;
                        }
                    }
                    else if (this.m_OFocusedRecipe.GetType() == typeof(CFollowRecipe))
                    {
                        CFollowRecipe ORecipe = (CFollowRecipe)this.m_OFocusedRecipe;
                        ORecipe.OROI.OGraphic.Color = CogColorConstants.Yellow;
                        ORecipe.OROI.OGraphic.SelectedColor = CogColorConstants.Yellow;

                        foreach (IAttach _Item in ORecipe.OROI.LstOAttach)
                        {
                            _Item.OGraphic.Color = CogColorConstants.Yellow;
                        }
                    }
                }
                else
                {
                    this.m_OCdpImage.StaticGraphics.Clear();
                    this.m_OCdpImage.InteractiveGraphics.Clear();
                }

                this.m_OFocusedRecipe = null;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void DoAlignment(CBlobRecipe OTarget, CogRectangle OBound)
        {
            try
            {
                foreach (CBlobRecipe _Item in this.m_ORecipe.ArrOBlob)
                {
                    if (_Item.StrAlignmentIndex != OTarget.I32Index.ToString()) continue;

                    _Item.OROI.Alignment(_Item.StrAlignmentTarget, _Item.StrAlignmentSource, OBound);
                    this.DoAlignment(_Item, _Item.OROI.OBound);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void MoveGraphic(string StrDirection, int I32Length)
        {
            try
            {
                foreach (CBlobRecipe _Item in this.m_ORecipe.ArrOBlob)
                {
                    if (_Item.BEnabled == false) continue;

                    _Item.OROI.Move(StrDirection, I32Length);
                }
                foreach (CPatternRecipe _Item in this.m_ORecipe.ArrOPattern)
                {
                    if (_Item.BEnabled == false) continue;

                    _Item.OROI.Move(StrDirection, I32Length);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public bool Validate()
        {
            bool BResult = false;

            try
            {
                foreach (CFollowRecipe _Item in this.m_ORecipe.ArrOMD)
                {
                    if (_Item.BEnabled == false) continue;

                    this.m_OMDCDTool.InputImage = (CogImage8Grey)this.m_OCdpImage.Image;
                    this.m_OMDCDTool.Region = (CogRectangleAffine)_Item.OROI.OGraphic;
                    this.m_OMDCDTool.RunParams.EdgeMode = CogCaliperEdgeModeConstants.SingleEdge;
                    this.m_OMDCDTool.RunParams.Edge0Polarity = _Item.EPolarity;
                    this.m_OMDCDTool.RunParams.ContrastThreshold = _Item.I32ContrastThreshold;
                    this.m_OMDCDTool.RunParams.FilterHalfSizeInPixels = _Item.I32HalfPixel;
                    if (_Item.EPriority == ECALIPER_PRIORITY.MostThreshold)
                    {
                        this.m_OMDCDTool.RunParams.SingleEdgeScorers.Clear();
                        this.m_OMDCDTool.RunParams.SingleEdgeScorers.Add(new CogCaliperScorerContrast());
                    }
                    else
                    {
                        this.m_OMDCDTool.RunParams.SingleEdgeScorers.Clear();

                        CogCaliperScorerPositionNeg OScorer = new CogCaliperScorerPositionNeg();
                        OScorer.SetXYParameters(-50000, 50000, 100000, 1, 0);
                        this.m_OMDCDTool.RunParams.SingleEdgeScorers.Add(OScorer);
                    }
                    this.m_OMDCDTool.Run();

                    if (this.m_OMDCDTool.Results.Count == 1) _Item.F64StandardPosition = this.m_OMDCDTool.Results[0].Edge0.PositionX;
                    else
                    {
                        CMsgBox.Warning("가로 맞춤" + _Item.I32Index + "에 대한 표준 위치를 찾을 수 없습니다.!");
                        return BResult;
                    }
                }

                foreach (CFollowRecipe _Item in this.m_ORecipe.ArrOCD)
                {
                    if (_Item.BEnabled == false) continue;

                    this.m_OMDCDTool.InputImage = (CogImage8Grey)this.m_OCdpImage.Image;
                    this.m_OMDCDTool.Region = (CogRectangleAffine)_Item.OROI.OGraphic;
                    this.m_OMDCDTool.RunParams.EdgeMode = CogCaliperEdgeModeConstants.SingleEdge;
                    this.m_OMDCDTool.RunParams.Edge0Polarity = _Item.EPolarity;
                    this.m_OMDCDTool.RunParams.ContrastThreshold = _Item.I32ContrastThreshold;
                    this.m_OMDCDTool.RunParams.FilterHalfSizeInPixels = _Item.I32HalfPixel;
                    if (_Item.EPriority == ECALIPER_PRIORITY.MostThreshold)
                    {
                        this.m_OMDCDTool.RunParams.SingleEdgeScorers.Clear();
                        this.m_OMDCDTool.RunParams.SingleEdgeScorers.Add(new CogCaliperScorerContrast());
                    }
                    else
                    {
                        this.m_OMDCDTool.RunParams.SingleEdgeScorers.Clear();

                        CogCaliperScorerPositionNeg OScorer = new CogCaliperScorerPositionNeg();
                        OScorer.SetXYParameters(-50000, 50000, 100000, 1, 0);
                        this.m_OMDCDTool.RunParams.SingleEdgeScorers.Add(OScorer);
                    }
                    this.m_OMDCDTool.Run();

                    if (this.m_OMDCDTool.Results.Count == 1) _Item.F64StandardPosition = this.m_OMDCDTool.Results[0].Edge0.PositionY;
                    else
                    {
                        CMsgBox.Warning("세로 맞춤" + _Item.I32Index + "에 대한 표준 위치를 찾을 수 없습니다.!");
                        return BResult;
                    }
                }

                BResult = true;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return BResult;
        }
        #endregion
    }
}
