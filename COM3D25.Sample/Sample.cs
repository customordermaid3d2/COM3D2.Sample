using BepInEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

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
        private Rect rect;
        private int winNum=10;
        private Vector2 scrollPosition;

        private void Awake()
        {
            Logger.LogMessage("Awake");
            rect = new Rect(10, 10, 100, 300);
        }

        private void OnGUI()
        {
            rect = GUILayout.Window(winNum, rect, WindowFunction, "Sample");
        }

        private void WindowFunction(int id)
        {
            GUI.enabled = true;
            scrollPosition = GUILayout.BeginScrollView(scrollPosition);
            if (GUILayout.Button("test"))
            {
                Logger.LogMessage("test");
            }
            GUILayout.EndScrollView();
            GUI.DragWindow(); // 창을 잡고 이동 가능            
        }
    }
}
