using BepInEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace COM3D2.Sample
{
    class MyAttribute
    {
        public const string PLAGIN_NAME = "Sample";
        public const string PLAGIN_VERSION = "22.3.4";
        public const string PLAGIN_FULL_NAME = "COM3D2.Sample.Plugin";
    }

    // 버전 규칙 잇음. 반드시 2~4개의 숫자구성으로 해야함. 미준수시 못읽어들임
    [BepInPlugin(
        MyAttribute.PLAGIN_FULL_NAME, 
        MyAttribute.PLAGIN_NAME, 
        MyAttribute.PLAGIN_VERSION)]
    public class Sample : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogMessage("Awake");
        }
    }
}
