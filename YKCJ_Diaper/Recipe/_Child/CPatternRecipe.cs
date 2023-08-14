using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognex.VisionPro.PMAlign;
using Daekhon.Common;
using Jhjo.Common;
using Cognex.VisionPro;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace YKCJ_Diaper
{
    public class CPatternRecipe : IRecipe, IDisposable
    {
        #region VARIABLE
        private string m_StrName = string.Empty;
        private int m_I32Index = 0;
        
        private bool m_BEnabled = false;
        private string m_StrDescription = string.Empty;
        private int m_I32MinScore = 80;
        private EIO m_EIOSignal = EIO.NONE;
        private CROIRectangle m_OROI = null;
        private string m_StrMD = CDiaperFaultRecipe.NONE;
        private string m_StrCD = CDiaperFaultRecipe.NONE;

        private CogPMAlignTool m_OTool = null;
        #endregion


        #region PROPERTIES
        public string StrName
        {
            get { return this.m_StrName; }
            set { this.m_StrName = value; }
        }


        public int I32Index
        {
            get { return this.m_I32Index; }
        }


        public bool BEnabled
        {
            get { return this.m_BEnabled; }
            set { this.m_BEnabled = value; }
        }


        public string StrDescription
        {
            get { return this.m_StrDescription; }
            set { this.m_StrDescription = value; }
        }


        public int I32MinScore
        {
            get { return this.m_I32MinScore; }
            set { this.m_I32MinScore = value; }
        }


        public EIO EIOSignal
        {
            get { return this.m_EIOSignal; }
            set { this.m_EIOSignal = value; }
        }


        public CROIRectangle OROI
        {
            get { return this.m_OROI; }
            set { this.m_OROI = value; }
        }


        public string StrMD
        {
            get { return this.m_StrMD; }
            set { this.m_StrMD = value; }
        }


        public string StrCD
        {
            get { return this.m_StrCD; }
            set { this.m_StrCD = value; }
        }


        public CogPMAlignTool OTool
        {
            get { return this.m_OTool; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CPatternRecipe(string StrName, int I32Index)
        {
            try
            {
                this.m_StrName = StrName;
                this.m_I32Index = I32Index;
                this.m_OROI = new CROIRectangle();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public CPatternRecipe(CPatternRecipe OSource)
        {
            try
            {
                this.m_StrName = OSource.m_StrName;
                this.m_I32Index = OSource.m_I32Index;
                this.m_BEnabled = OSource.m_BEnabled;
                this.m_StrDescription = OSource.m_StrDescription;
                this.m_I32MinScore = OSource.m_I32MinScore;
                this.m_EIOSignal = OSource.m_EIOSignal;
                this.m_OROI = new CROIRectangle(OSource.m_OROI);
                this.m_StrMD = OSource.m_StrMD;
                this.m_StrCD = OSource.m_StrCD;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        ~CPatternRecipe()
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
        public void Create()
        {
            try
            {
                CogRectangle OTrainRegion = new CogRectangle();
                OTrainRegion.X = 0;
                OTrainRegion.Y = 0;
                OTrainRegion.Width = 200;
                OTrainRegion.Height = 200;
                OTrainRegion.Color = CogColorConstants.Magenta;
                OTrainRegion.SelectedColor = CogColorConstants.Magenta;
                OTrainRegion.Interactive = true;
                OTrainRegion.GraphicDOFEnable = CogRectangleDOFConstants.All;

                this.m_OTool = new CogPMAlignTool();
                this.m_OTool.Pattern.TrainRegion = OTrainRegion;
                this.m_OTool.Pattern.TrainMode = CogPMAlignTrainModeConstants.Image;
                this.m_OTool.RunParams.RunAlgorithm = CogPMAlignRunAlgorithmConstants.PatQuick;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void Load()
        {
            try
            {
                this.m_OROI.Create();
                this.m_OROI.OGraphic.Color = CogColorConstants.Green;
                this.m_OROI.OGraphic.SelectedColor = CogColorConstants.Green;


                this.m_OTool = (CogPMAlignTool)CogSerializer.LoadObjectFromFile
                (
                    ".\\RECIPE\\" + this.m_StrName + "\\PATTERN" + this.I32Index + ".vpp",
                    typeof(BinaryFormatter),
                    CogSerializationOptionsConstants.All
                );
                ((ICogGraphicInteractive)this.m_OTool.Pattern.TrainRegion).Interactive = true;
                ((ICogGraphicInteractive)this.m_OTool.Pattern.TrainRegion).GraphicDOFEnableBase = CogGraphicDOFConstants.All;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void LoadTool()
        {
            try
            {
                this.m_OTool = (CogPMAlignTool)CogSerializer.LoadObjectFromFile
                (
                    ".\\RECIPE\\" + this.m_StrName + "\\PATTERN" + this.I32Index + ".vpp",
                    typeof(BinaryFormatter),
                    CogSerializationOptionsConstants.All
                );
                ((ICogGraphicInteractive)this.m_OTool.Pattern.TrainRegion).Interactive = true;
                ((ICogGraphicInteractive)this.m_OTool.Pattern.TrainRegion).GraphicDOFEnableBase = CogGraphicDOFConstants.All;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void LoadROI()
        {
            try
            {
                this.m_OROI.Create();
                this.m_OROI.OGraphic.Color = CogColorConstants.Green;
                this.m_OROI.OGraphic.SelectedColor = CogColorConstants.Green;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void Save()
        {
            try
            {
                if (this.m_BEnabled == true)
                {
                    this.m_OROI.Reflect();
                }

                CogSerializer.SaveObjectToFile
                (
                    this.m_OTool,
                    ".\\RECIPE\\" + this.m_StrName + "\\PATTERN" + this.I32Index + ".vpp",
                    typeof(BinaryFormatter),
                    CogSerializationOptionsConstants.All
                );
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void Delete()
        {
            try
            {
                File.Delete(".\\RECIPE\\" + this.m_StrName + "\\PATTERN" + this.I32Index + ".vpp");
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void Copy(CPatternRecipe OSource, bool BCopyTool)
        {
            try
            {
                this.m_BEnabled = OSource.m_BEnabled;
                this.m_StrDescription = OSource.m_StrDescription;
                this.m_I32MinScore = OSource.m_I32MinScore;
                this.m_EIOSignal = OSource.m_EIOSignal;
                this.m_OROI.Copy(OSource.m_OROI);
                this.m_StrMD = OSource.m_StrMD;
                this.m_StrCD = OSource.m_StrCD;

                if (BCopyTool == true)
                {
                    if (this.m_OTool != null)
                    {
                        this.m_OTool.Dispose();
                        this.m_OTool = null;
                    }

                    this.m_OTool = new CogPMAlignTool(OSource.m_OTool);
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
                if (this.m_OTool != null)
                {
                    this.m_OTool.Dispose();
                    this.m_OTool = null;
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
