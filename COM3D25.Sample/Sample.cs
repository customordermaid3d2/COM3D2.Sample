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
            // UI창. 이거 없이 OnGUI 에서 WindowFunction 내용을 직접 구현해도 됨
            rect = GUILayout.Window(winNum, rect, WindowFunction, "Sample");
        }

        private void WindowFunction(int id)
        {
            GUI.enabled = true; // 하위 GUI활성 가능. 커튼 클릭가능 같은것
            ;// 세로 스크롤 시작
            scrollPosition = GUILayout.BeginScrollView(scrollPosition);
            if (GUILayout.Button("test"))
            {
                Logger.LogMessage("test");
            }
            GUILayout.EndScrollView();// 세로 스크롤 끝
            GUI.DragWindow(); // 창을 잡고 이동 가능            
        }
    }
}
