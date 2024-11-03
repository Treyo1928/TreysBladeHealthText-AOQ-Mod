using System;
using System.IO;
using System.Collections;
using HarmonyLib;
using UnityEngine;
using TMPro;

namespace TreysBladeHealthText
{
    [HarmonyPatch(typeof(NetworkBlades), "Start")]
    public static class NetworkBladeStartPatch
    {
        public static GameObject leftHandText;
        public static GameObject rightHandText;
        static void Prefix(Blades __instance)
        {
            CreateLeftText();

            CreateRightText();
        }
        public static void CreateLeftText()
        {
            try
            {
                // Create the left hand text asset and bind it to the left hand
                leftHandText = new GameObject("LeftBladeHealthText");
                TextMeshPro leftTextComponent = leftHandText.AddComponent<TextMeshPro>();
                leftTextComponent.fontSize = 5;
                //leftHandText.transform.SetParent(PlayerManager.instance.leftHandAnchor);
                leftHandText.transform.SetParent(GameObject.Find("OVRPlayerController").transform.Find("OVRCameraRig").transform.Find("TrackingSpace").transform.Find("LeftHandAnchor").transform.Find("LeftWeapon").transform.Find("AoT-Sword-Left").transform.Find("Blade-Partial"));
                leftTextComponent.alignment = TextAlignmentOptions.Center;
                leftHandText.transform.localScale = new Vector3(1, 1, 1);
                leftHandText.transform.localPosition = new Vector3(-1.5807f, 0.4134f, -0.8f);
            }
            catch (Exception e)
            {
                Plugin.PluginLogger.LogInfo("Failed to Create LeftText: " + e.ToString());
                leftHandText = null;
            }
        }

        public static void CreateRightText()
        {
            try
            {
                // Create the right hand text asset and bind it to the right hand
                rightHandText = new GameObject("RightBladeHealthText");
                TextMeshPro rightTextComponent = rightHandText.AddComponent<TextMeshPro>();
                rightTextComponent.fontSize = 5;
                rightHandText.transform.SetParent(GameObject.Find("OVRPlayerController").transform.Find("OVRCameraRig").transform.Find("TrackingSpace").transform.Find("RightHandAnchor").transform.Find("RightWeapon").transform.Find("AoT-Sword-Right").transform.Find("Blade-Partial"));
                rightTextComponent.alignment = TextAlignmentOptions.Center;
                rightHandText.transform.localScale = new Vector3(1, 1, 1);
                rightHandText.transform.localPosition = new Vector3(-1.5807f, 0.4134f, -0.8f);
            }
            catch (Exception e)
            {
                Plugin.PluginLogger.LogInfo("Failed to Create RightText: " + e.ToString());
                rightHandText = null;
            }
}
    }
}
