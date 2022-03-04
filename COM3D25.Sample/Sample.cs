using BepInEx;
using BepInEx.Logging;
using COM3D2API;
using HarmonyLib;
using LillyUtill.MyWindowRect;
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
        //private Rect rect;
        //private int winNum=10;
        private Vector2 scrollPosition;
        WindowRectUtill windowRect;

        Harmony harmony;
        public static ManualLogSource log;

        private void Awake()
        {
            log = Logger;
            Logger.LogMessage("Awake");

            //rect = new Rect(10, 10, 100, 300);
            windowRect = new WindowRectUtill(
                Config,
                MyAttribute.PLAGIN_FULL_NAME,
                MyAttribute.PLAGIN_NAME,
                "SPL", // 최소화시 타이틀명
                ho: 100
                );

            harmony = Harmony.CreateAndPatchAll(typeof(SamplePatch));
        }

        private void Start()
        {
            Sample.log.LogMessage("Start");

            // 기어 메뉴 추가. 이 플러그인 기능 자체를 멈추려면 enabled 를 꺽어야함. 그러면 OnEnable(), OnDisable() 이 작동함
            SystemShortcutAPI.AddButton(
                MyAttribute.PLAGIN_FULL_NAME,
                new Action(delegate () { windowRect.IsGUIOn = !windowRect.IsGUIOn; }),
                MyAttribute.PLAGIN_NAME,
                Properties.Resources.icon);
        }

        private void OnGUI()
        {
            // UI창. 이거 없이 OnGUI 에서 WindowFunction 내용을 직접 구현해도 됨
            windowRect.WindowRect = GUILayout.Window(
                windowRect.winNum, windowRect.WindowRect, WindowFunction, "", GUI.skin.box);
        }

        private void WindowFunction(int id)
        {
            GUI.enabled = true; // 하위 GUI활성 가능. 커튼 클릭가능 같은것

            GUILayout.BeginHorizontal();
            GUILayout.Label(windowRect.windowName, GUILayout.Height(20));
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("-", GUILayout.Width(20), GUILayout.Height(20)))
            { windowRect.IsOpen = !windowRect.IsOpen; }
            if (GUILayout.Button("x", GUILayout.Width(20), GUILayout.Height(20)))
            { windowRect.IsGUIOn = false; }
            GUILayout.EndHorizontal();

            if (!windowRect.IsOpen)
            {   // 최소화시

            }
            else
            {   // 최대화시
                // 세로 스크롤 시작
                scrollPosition = GUILayout.BeginScrollView(scrollPosition);
                if (GUILayout.Button("test1")){Logger.LogMessage("test1");}
                GUI.enabled = false;
                if (GUILayout.Button("test2")){Logger.LogMessage("test2");}
                GUI.enabled = true;
                if (GUILayout.Button("test3")){Logger.LogMessage("test3");}
                GUILayout.EndScrollView();// 세로 스크롤 끝
            }
            GUI.enabled = true;
            GUI.DragWindow(); // 창을 잡고 이동 가능            
        }
    }
}
