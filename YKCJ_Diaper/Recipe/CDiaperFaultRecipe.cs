using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Common;
using Daekhon.Common;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using Cognex.VisionPro;
using System.Drawing;

namespace YKCJ_Diaper
{
    public class CDiaperFaultRecipe : IRecipe, IDisposable
    {
        #region CONST
        public const int BLOB_COUNT = 15;
        public const int PATTERN_COUNT = 4;
        public const int MD_COUNT = 5;
        public const int CD_COUNT = 5;

        public const string NONE = "없음";
        #endregion


        #region VARIABLE
        private string m_StrName = string.Empty;
        private CogImage8Grey m_OImage = null;

        private CBlobRecipe[] m_ArrOBlob = null;
        private CPatternRecipe[] m_ArrOPattern = null;
        private CFollowRecipe[] m_ArrOMD = null;
        private CFollowRecipe[] m_ArrOCD = null;
        #endregion


        #region PROPERTIES
        public string StrName
        {
            get { return this.m_StrName; }
            set { this.m_StrName = value; }
        }


        public CogImage8Grey OImage
        {
            get { return this.m_OImage; }
            set { this.m_OImage = value; }
        }


        public CBlobRecipe[] ArrOBlob
        {
            get { return this.m_ArrOBlob; }
            set { this.m_ArrOBlob = value; }
        }


        public CPatternRecipe[] ArrOPattern
        {
            get { return this.m_ArrOPattern; }
            set { this.m_ArrOPattern = value; }
        }


        public CFollowRecipe[] ArrOMD
        {
            get { return this.m_ArrOMD; }
            set { this.m_ArrOMD = value; }
        }


        public CFollowRecipe[] ArrOCD
        {
            get { return this.m_ArrOCD; }
            set { this.m_ArrOCD = value; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CDiaperFaultRecipe(string StrName)
        {
            try
            {
                this.m_StrName = StrName;

                if (File.Exists(".\\RECIPE\\" + StrName + "\\Image.bmp") == true)
                {
                    Bitmap OSource = (Bitmap)Bitmap.FromFile(".\\RECIPE\\" + StrName + "\\Image.bmp");
                    this.m_OImage = new CogImage8Grey(OSource);
                    OSource.Dispose();
                    OSource = null;
                }


                this.m_ArrOBlob = new CBlobRecipe[CDiaperFaultRecipe.BLOB_COUNT];
                for (int _Index = 0; _Index < CDiaperFaultRecipe.BLOB_COUNT; _Index++)
                {
                    this.m_ArrOBlob[_Index] = new CBlobRecipe(StrName, _Index + 1);
                }
                
                this.m_ArrOPattern = new CPatternRecipe[CDiaperFaultRecipe.PATTERN_COUNT];
                for (int _Index = 0; _Index < CDiaperFaultRecipe.PATTERN_COUNT; _Index++)
                {
                    this.m_ArrOPattern[_Index] = new CPatternRecipe(StrName, _Index + 1);
                }
                
                this.m_ArrOMD = new CFollowRecipe[CDiaperFaultRecipe.MD_COUNT];
                for (int _Index = 0; _Index < CDiaperFaultRecipe.MD_COUNT; _Index++)
                {
                    this.m_ArrOMD[_Index] = new CFollowRecipe(StrName, EFOLLOW.MD, _Index + 1);
                }
                
                this.m_ArrOCD = new CFollowRecipe[CDiaperFaultRecipe.CD_COUNT];
                for (int _Index = 0; _Index < CDiaperFaultRecipe.CD_COUNT; _Index++)
                {
                    this.m_ArrOCD[_Index] = new CFollowRecipe(StrName, EFOLLOW.CD, _Index + 1);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public CDiaperFaultRecipe(CDiaperFaultRecipe OSource)
        {
            try
            {
                this.m_StrName = OSource.m_StrName;
                if (OSource.m_OImage != null)
                {
                    this.m_OImage = new CogImage8Grey(OSource.m_OImage);
                }


                this.m_ArrOBlob = new CBlobRecipe[CDiaperFaultRecipe.BLOB_COUNT];
                for (int _Index = 0; _Index < CDiaperFaultRecipe.BLOB_COUNT; _Index++)
                {
                    this.m_ArrOBlob[_Index] = new CBlobRecipe(OSource.m_ArrOBlob[_Index]);
                }

                this.m_ArrOPattern = new CPatternRecipe[CDiaperFaultRecipe.PATTERN_COUNT];
                for (int _Index = 0; _Index < CDiaperFaultRecipe.PATTERN_COUNT; _Index++)
                {
                    this.m_ArrOPattern[_Index] = new CPatternRecipe(OSource.m_ArrOPattern[_Index]);
                }

                this.m_ArrOMD = new CFollowRecipe[CDiaperFaultRecipe.MD_COUNT];
                for (int _Index = 0; _Index < CDiaperFaultRecipe.MD_COUNT; _Index++)
                {
                    this.m_ArrOMD[_Index] = new CFollowRecipe(OSource.m_ArrOMD[_Index]);
                }

                this.m_ArrOCD = new CFollowRecipe[CDiaperFaultRecipe.CD_COUNT];
                for (int _Index = 0; _Index < CDiaperFaultRecipe.CD_COUNT; _Index++)
                {
                    this.m_ArrOCD[_Index] = new CFollowRecipe(OSource.m_ArrOCD[_Index]);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        ~CDiaperFaultRecipe()
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
                foreach (CPatternRecipe _Item in this.m_ArrOPattern)
                {
                    _Item.Create();
                }
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
                foreach (CBlobRecipe _Item in this.m_ArrOBlob)
                {
                    _Item.Load();
                }
                foreach (CPatternRecipe _Item in this.m_ArrOPattern)
                {
                    _Item.Load();
                }
                foreach (CFollowRecipe _Item in this.m_ArrOMD)
                {
                    _Item.Load();
                }
                foreach (CFollowRecipe _Item in this.m_ArrOCD)
                {
                    _Item.Load();
                }
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
                foreach (CPatternRecipe _Item in this.m_ArrOPattern)
                {
                    _Item.LoadTool();
                }
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
                foreach (CBlobRecipe _Item in this.m_ArrOBlob)
                {
                    _Item.Load();
                }
                foreach (CPatternRecipe _Item in this.m_ArrOPattern)
                {
                    _Item.LoadROI();
                }
                foreach (CFollowRecipe _Item in this.m_ArrOMD)
                {
                    _Item.Load();
                }
                foreach (CFollowRecipe _Item in this.m_ArrOCD)
                {
                    _Item.Load();
                }
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
                Directory.CreateDirectory(".\\RECIPE\\" + StrName);

                CImageSaveTool.It.ChangeImage(".\\RECIPE\\" + StrName + "\\Image.bmp", this.m_OImage);


                foreach (CBlobRecipe _Item in this.m_ArrOBlob)
                {
                    _Item.Save();
                }
                foreach (CPatternRecipe _Item in this.m_ArrOPattern)
                {
                    _Item.Save();
                }
                foreach (CFollowRecipe _Item in this.m_ArrOMD)
                {
                    _Item.Save();
                }
                foreach (CFollowRecipe _Item in this.m_ArrOCD)
                {
                    _Item.Save();
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void Copy(CDiaperFaultRecipe OSource)
        {
            try
            {
                this.m_OImage = new CogImage8Grey(OSource.m_OImage);

                for (int _Index = 0; _Index < CDiaperFaultRecipe.BLOB_COUNT; _Index++)
                {
                    this.m_ArrOBlob[_Index].Copy(OSource.m_ArrOBlob[_Index]);
                }
                for (int _Index = 0; _Index < CDiaperFaultRecipe.PATTERN_COUNT; _Index++)
                {
                    this.m_ArrOPattern[_Index].Copy(OSource.m_ArrOPattern[_Index], false);
                }
                for (int _Index = 0; _Index < CDiaperFaultRecipe.MD_COUNT; _Index++)
                {
                    this.m_ArrOMD[_Index].Copy(OSource.m_ArrOMD[_Index]);
                }
                for (int _Index = 0; _Index < CDiaperFaultRecipe.CD_COUNT; _Index++)
                {
                    this.m_ArrOCD[_Index].Copy(OSource.m_ArrOCD[_Index]);
                }

                Directory.CreateDirectory(".\\RECIPE\\" + StrName);
                FileSystem.CopyDirectory
                (
                    ".\\RECIPE\\" + OSource.m_StrName,
                    ".\\RECIPE\\" + StrName
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
                Directory.Delete(".\\RECIPE\\" + StrName, true);
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
                for (int _Index = 0; _Index < CDiaperFaultRecipe.PATTERN_COUNT; _Index++)
                {
                    this.m_ArrOPattern[_Index].Dispose();
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
