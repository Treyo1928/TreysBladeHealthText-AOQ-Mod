using System;
using System.IO;
using HarmonyLib;
using UnityEngine;
using TMPro;

namespace TreysBladeHealthText
{
    [HarmonyPatch(typeof(Blades), "Start")]
    public static class BladeStartPatch
    {
        public static GameObject leftHandText;
        public static GameObject rightHandText;
        static void Postfix(Blades __instance)
        {
            // Create the left hand text asset and bind it to the left hand
            leftHandText = new GameObject("LeftBladeHealthText");
            TextMeshPro leftTextComponent = leftHandText.AddComponent<TextMeshPro>();
            leftTextComponent.fontSize = 5;
            //leftHandText.transform.SetParent(PlayerManager.instance.leftHandAnchor);
            leftHandText.transform.SetParent(__instance.leftBlade.transform);
            leftTextComponent.alignment = TextAlignmentOptions.Center;
            leftHandText.transform.localScale = new Vector3(1, 1, 1);
            leftHandText.transform.localPosition = new Vector3(-1.5807f, 0.4134f, -0.8f);


            // Create the right hand text asset and bind it to the right hand
            rightHandText = new GameObject("RightBladeHealthText");
            TextMeshPro rightTextComponent = rightHandText.AddComponent<TextMeshPro>();
            rightTextComponent.fontSize = 5;
            rightHandText.transform.SetParent(__instance.rightBlade.transform);
            rightTextComponent.alignment = TextAlignmentOptions.Center;
            rightHandText.transform.localScale = new Vector3(1, 1, 1);
            rightHandText.transform.localPosition = new Vector3(-1.5807f, 0.4134f, -0.8f);
        }
    }
}
