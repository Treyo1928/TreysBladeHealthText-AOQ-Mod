using HarmonyLib;
using UnityEngine;
using TMPro;

namespace TreysBladeHealthText
{
    [HarmonyPatch(typeof(NetworkBlades), "Update")]
    public static class NetworkBladeUpdatePatch
    {
        static void Prefix(Blades __instance)
        {
            if (NetworkBladeStartPatch.leftHandText != null)
            {
                int leftBladeHealth = StaticVariables.leftBladeHealth;
                TextMeshPro leftHandTextComponent = NetworkBladeStartPatch.leftHandText.GetComponent<TextMeshPro>();
                if (leftBladeHealth > 4) leftHandTextComponent.color = Color.green;
                else if (leftBladeHealth > 2) leftHandTextComponent.color = Color.yellow;
                else leftHandTextComponent.color = Color.red;
                leftHandTextComponent.text = leftBladeHealth.ToString();
                NetworkBladeStartPatch.leftHandText.transform.LookAt(Camera.main.transform.position);
                NetworkBladeStartPatch.leftHandText.transform.Rotate(0, 180, 0);
                Plugin.PluginLogger.LogInfo("leftHealth: " + leftBladeHealth.ToString());
                Plugin.PluginLogger.LogInfo("leftPosition: " + NetworkBladeStartPatch.leftHandText.transform.position.ToString());
            }
            else NetworkBladeStartPatch.CreateLeftText();

            if (NetworkBladeStartPatch.rightHandText != null)
            {
                int rightBladeHealth = StaticVariables.rightBladeHealth;
                TextMeshPro rightHandTextComponent = NetworkBladeStartPatch.rightHandText.GetComponent<TextMeshPro>();
                if (rightBladeHealth > 4) rightHandTextComponent.color = Color.green;
                else if (rightBladeHealth > 2) rightHandTextComponent.color = Color.yellow;
                else rightHandTextComponent.color = Color.red;
                rightHandTextComponent.text = rightBladeHealth.ToString();
                NetworkBladeStartPatch.rightHandText.transform.LookAt(Camera.main.transform.position);
                NetworkBladeStartPatch.rightHandText.transform.Rotate(0, 180, 0);
            }
            else NetworkBladeStartPatch.CreateRightText();
        }
    }
}
