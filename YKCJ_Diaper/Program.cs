using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Cognex.VisionPro;
using Jhjo.Common;
using PylonC.NET;

namespace YKCJ_Diaper
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                bool BBlobExisted = CogMisc.IsLicensedFeatureEnabled("VxBlob");
                bool BCaliperExisted = CogMisc.IsLicensedFeatureEnabled("VxCaliper");
                if ((BBlobExisted == false) || (BCaliperExisted == false))
                {
                    CMsgBox.Warning("Cognex 동글 키를 컴퓨터에 연결하여 주세요.");
                    return;
                }


                Environment.SetEnvironmentVariable("PYLON_GIGE_HEARTBEAT", "1000" /*ms*/);
                Pylon.Initialize();


                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                frmLoad OWindow = new frmLoad();
                if (OWindow.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new frmMain());
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }
    }
}
