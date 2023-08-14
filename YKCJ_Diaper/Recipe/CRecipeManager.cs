using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Common;
using Daekhon.Common;
using System.Data;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.Caliper;

namespace YKCJ_Diaper
{
    public class CRecipeManager : IDisposable
    {
        #region SIGNLE TON
        protected static CRecipeManager Src_It = null;
        public static CRecipeManager It
        {
            get
            {
                CRecipeManager OResult = null;

                try
                {
                    if (CRecipeManager.Src_It == null)
                    {
                        CRecipeManager.Src_It = new CRecipeManager();
                    }

                    OResult = CRecipeManager.Src_It;
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }

                return OResult;
            }
        }
        #endregion


        #region VARIABLE
        private List<CDiaperFaultRecipe> m_LstORecipe = null;
        #endregion


        #region PROPERTIES
        public List<CDiaperFaultRecipe> LstORecipe
        {
            get { return this.m_LstORecipe; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        protected CRecipeManager()
        {
            try
            {
                this.m_LstORecipe = new List<CDiaperFaultRecipe>();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        ~CRecipeManager()
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
        public bool Load()
        {
            bool BResult = false;

            try
            {
                this.LoadRecipeList();
                this.LoadBlobList();
                this.LoadPatternList();
                this.LoadFollowList();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return BResult;
        }


        private void LoadRecipeList()
        {
            try
            {
                DataTable ODataSource = CDB.It[CDB.TABLE_RECIPE_LIST].Select();


                foreach (DataRow _Item in ODataSource.Rows)
                {
                    this.m_LstORecipe.Add(new CDiaperFaultRecipe(_Item[CDB.RECIPE_LIST_NAME].ToString()));
                }
                

                if (ODataSource != null)
                {
                    ODataSource.Dispose();
                    ODataSource = null;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void LoadBlobList()
        {
            try
            {
                CogBlobSegmentationPolarityConstants EPolarity = CogBlobSegmentationPolarityConstants.DarkBlobs;
                EIO EIOSignal = EIO.NONE;
                double[] ArrF64Value = null;

                DataTable ODataSource = CDB.It[CDB.TABLE_BLOB_LIST].Select();
                foreach (DataRow _Item1 in ODataSource.Rows)
                {
                    foreach (CDiaperFaultRecipe _Item2 in this.m_LstORecipe)
                    {
                        if ((string)_Item1[CDB.BLOB_LIST_RECIPE] != _Item2.StrName) continue;
                        

                        foreach (CBlobRecipe _Item3 in _Item2.ArrOBlob)
                        {
                            if ((int)_Item1[CDB.BLOB_LIST_INDEX] != _Item3.I32Index) continue;

                            EPolarity = (CogBlobSegmentationPolarityConstants)Enum.Parse
                            (
                                typeof(CogBlobSegmentationPolarityConstants),
                                (string)_Item1[CDB.BLOB_LIST_POLARITY]
                            );

                            if ((string)_Item1[CDB.BLOB_LIST_IO] != CDiaperFaultRecipe.NONE)
                            {
                                EIOSignal = (EIO)Enum.Parse(typeof(EIO), (string)_Item1[CDB.BLOB_LIST_IO]);
                            }
                            else EIOSignal = EIO.NONE;

                            ArrF64Value = new double[(int)_Item1[CDB.BLOB_LIST_ROI_VALUE_COUNT]];
                            for (int _Index = 0; _Index < ArrF64Value.Length; _Index++)
                            {
                                ArrF64Value[_Index] = (double)_Item1[CDB.BLOB_LIST_ROI_VALUE + _Index];
                            }


                            _Item3.StrDescription = _Item1[CDB.BLOB_LIST_DESCRIPTION].ToString();
                            _Item3.BEnabled = (bool)_Item1[CDB.BLOB_LIST_ENABLED];
                            _Item3.EPolarity = EPolarity;
                            _Item3.OThreshold = CThresholdFactory.GetThreshold((string)_Item1[CDB.BLOB_LIST_THRESHOLD_TYPE]);
                            _Item3.OThreshold.I32Value = (int)_Item1[CDB.BLOB_LIST_THRESHOLD_VALUE];
                            _Item3.I32MinSize = (int)_Item1[CDB.BLOB_LIST_MIN_SIZE];
                            _Item3.I32Offset = (int)_Item1[CDB.BLOB_LIST_OFFSET];
                            _Item3.EIOSignal = EIOSignal;
                            _Item3.OROI = CROIFactory.GetROI((string)_Item1[CDB.BLOB_LIST_ROI_KIND], ArrF64Value);
                            _Item3.StrMD = _Item1[CDB.BLOB_LIST_FOLLOW_MD].ToString();
                            _Item3.StrCD = _Item1[CDB.BLOB_LIST_FOLLOW_CD].ToString();
                            _Item3.StrAlignmentTarget = _Item1[CDB.BLOB_LIST_ALIGNMENT_TARGET].ToString();
                            _Item3.StrAlignmentIndex = _Item1[CDB.BLOB_LIST_ALIGNMENT_INDEX].ToString();
                            _Item3.StrAlignmentSource = _Item1[CDB.BLOB_LIST_ALIGNMENT_SOURCE].ToString();
                            break;
                        }                        

                        break;
                    }
                }

                if (ODataSource != null)
                {
                    ODataSource.Dispose();
                    ODataSource = null;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void LoadPatternList()
        {
            try
            {
                EIO EIOSignal = EIO.NONE;

                DataTable ODataSource = CDB.It[CDB.TABLE_PATTERN_LIST].Select();
                foreach (DataRow _Item1 in ODataSource.Rows)
                {
                    foreach (CDiaperFaultRecipe _Item2 in this.m_LstORecipe)
                    {
                        if ((string)_Item1[CDB.PATTERN_LIST_RECIPE] != _Item2.StrName) continue;
                        
                        foreach (CPatternRecipe _Item3 in _Item2.ArrOPattern)
                        {
                            if ((int)_Item1[CDB.PATTERN_LIST_INDEX] != _Item3.I32Index) continue;

                            if ((string)_Item1[CDB.PATTERN_LIST_IO] != CDiaperFaultRecipe.NONE)
                            {
                                EIOSignal = (EIO)Enum.Parse(typeof(EIO), (string)_Item1[CDB.PATTERN_LIST_IO]);
                            }
                            else EIOSignal = EIO.NONE;

                            _Item3.StrDescription = _Item1[CDB.PATTERN_LIST_DESCRIPTION].ToString();
                            _Item3.BEnabled = (bool)_Item1[CDB.PATTERN_LIST_ENABLED];
                            _Item3.I32MinScore = (int)_Item1[CDB.PATTERN_LIST_MIN_SCORE];
                            _Item3.EIOSignal = EIOSignal;
                            _Item3.OROI.F64X = (double)_Item1[CDB.PATTERN_LIST_ROI_X];
                            _Item3.OROI.F64Y = (double)_Item1[CDB.PATTERN_LIST_ROI_Y];
                            _Item3.OROI.F64Width = (double)_Item1[CDB.PATTERN_LIST_ROI_WIDTH];
                            _Item3.OROI.F64Height = (double)_Item1[CDB.PATTERN_LIST_ROI_HEIGHT];
                            _Item3.StrMD = _Item1[CDB.PATTERN_LIST_FOLLOW_MD].ToString();
                            _Item3.StrCD = _Item1[CDB.PATTERN_LIST_FOLLOW_CD].ToString();
                            break;
                        }
                        break;
                    }
                }

                if (ODataSource != null)
                {
                    ODataSource.Dispose();
                    ODataSource = null;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void LoadFollowList()
        {
            try
            {
                CogCaliperPolarityConstants EPolarity = CogCaliperPolarityConstants.DontCare;
                ECALIPER_PRIORITY EPriority = ECALIPER_PRIORITY.MostThreshold;

                DataTable ODataSource = CDB.It[CDB.TABLE_FOLLOW_LIST].Select();
                foreach (DataRow _Item1 in ODataSource.Rows)
                {
                    foreach (CDiaperFaultRecipe _Item2 in this.m_LstORecipe)
                    {
                        if ((string)_Item1[CDB.FOLLOW_LIST_RECIPE] != _Item2.StrName) continue;

                        if ((string)_Item1[CDB.FOLLOW_LIST_KIND] == EFOLLOW.MD.ToString())
                        {
                            foreach (CFollowRecipe _Item3 in _Item2.ArrOMD)
                            {
                                if ((int)_Item1[CDB.FOLLOW_LIST_INDEX] != _Item3.I32Index) continue;

                                EPolarity = (CogCaliperPolarityConstants)Enum.Parse
                                (
                                    typeof(CogCaliperPolarityConstants),
                                    (string)_Item1[CDB.FOLLOW_LIST_POLARITY]
                                );
                                EPriority = (ECALIPER_PRIORITY)Enum.Parse
                                (
                                    typeof(ECALIPER_PRIORITY),
                                    (string)_Item1[CDB.FOLLOW_LIST_PRIORITY]
                                );

                                _Item3.BEnabled = (bool)_Item1[CDB.FOLLOW_LIST_ENABLED];
                                _Item3.StrDescription = _Item1[CDB.FOLLOW_LIST_DESCRIPTION].ToString();
                                _Item3.EPolarity = EPolarity;
                                _Item3.I32ContrastThreshold = (int)_Item1[CDB.FOLLOW_LIST_CONTRAST_THRESHOLD];
                                _Item3.I32HalfPixel = (int)_Item1[CDB.FOLLOW_LIST_HALF_PIXEL];
                                _Item3.EPriority = EPriority;
                                _Item3.OROI.F64CenterX = (double)_Item1[CDB.FOLLOW_LIST_ROI_CENTER_X];
                                _Item3.OROI.F64CenterY = (double)_Item1[CDB.FOLLOW_LIST_ROI_CENTER_Y];
                                _Item3.OROI.F64LengthX = (double)_Item1[CDB.FOLLOW_LIST_ROI_LENGTH_X];
                                _Item3.OROI.F64LengthY = (double)_Item1[CDB.FOLLOW_LIST_ROI_LENGTH_Y];
                                _Item3.OROI.F64Rotation = (double)_Item1[CDB.FOLLOW_LIST_ROI_ROTATION];
                                _Item3.OROI.F64Skew = (double)_Item1[CDB.FOLLOW_LIST_ROI_SKEW];
                                _Item3.F64StandardPosition = (double)_Item1[CDB.FOLLOW_LIST_STANDARD_POSITION];
                                break;
                            }
                        }
                        else
                        {
                            foreach (CFollowRecipe _Item3 in _Item2.ArrOCD)
                            {
                                if ((int)_Item1[CDB.FOLLOW_LIST_INDEX] != _Item3.I32Index) continue;

                                EPolarity = (CogCaliperPolarityConstants)Enum.Parse
                                (
                                    typeof(CogCaliperPolarityConstants),
                                    (string)_Item1[CDB.FOLLOW_LIST_POLARITY]
                                );
                                EPriority = (ECALIPER_PRIORITY)Enum.Parse
                                (
                                    typeof(ECALIPER_PRIORITY),
                                    (string)_Item1[CDB.FOLLOW_LIST_PRIORITY]
                                );

                                _Item3.BEnabled = (bool)_Item1[CDB.FOLLOW_LIST_ENABLED];
                                _Item3.StrDescription = _Item1[CDB.FOLLOW_LIST_DESCRIPTION].ToString();
                                _Item3.EPolarity = EPolarity;
                                _Item3.I32ContrastThreshold = (int)_Item1[CDB.FOLLOW_LIST_CONTRAST_THRESHOLD];
                                _Item3.I32HalfPixel = (int)_Item1[CDB.FOLLOW_LIST_HALF_PIXEL];
                                _Item3.EPriority = EPriority;
                                _Item3.OROI.F64CenterX = (double)_Item1[CDB.FOLLOW_LIST_ROI_CENTER_X];
                                _Item3.OROI.F64CenterY = (double)_Item1[CDB.FOLLOW_LIST_ROI_CENTER_Y];
                                _Item3.OROI.F64LengthX = (double)_Item1[CDB.FOLLOW_LIST_ROI_LENGTH_X];
                                _Item3.OROI.F64LengthY = (double)_Item1[CDB.FOLLOW_LIST_ROI_LENGTH_Y];
                                _Item3.OROI.F64Rotation = (double)_Item1[CDB.FOLLOW_LIST_ROI_ROTATION];
                                _Item3.OROI.F64Skew = (double)_Item1[CDB.FOLLOW_LIST_ROI_SKEW];
                                _Item3.F64StandardPosition = (double)_Item1[CDB.FOLLOW_LIST_STANDARD_POSITION];
                                break;
                            }
                        }

                        break;
                    }
                }

                if (ODataSource != null)
                {
                    ODataSource.Dispose();
                    ODataSource = null;
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
                if (this.m_LstORecipe != null)
                {
                    for (int _Index = 0; _Index < this.m_LstORecipe.Count; _Index++)
                    {
                        this.m_LstORecipe[_Index].Dispose();
                    }
                    this.m_LstORecipe.Clear();
                    this.m_LstORecipe = null;
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
