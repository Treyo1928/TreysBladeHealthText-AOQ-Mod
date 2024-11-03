using HarmonyLib;
using UnityEngine;
using TMPro;

namespace TreysBladeHealthText
{
    [HarmonyPatch(typeof(Blades), "Update")]
    public static class BladeUpdatePatch
    {
        static void Postfix(Blades __instance)
        {
            if (BladeStartPatch.leftHandText != null)
            {
                int leftBladeHealth = StaticVariables.leftBladeHealth;
                TextMeshPro leftHandTextComponent = BladeStartPatch.leftHandText.GetComponent<TextMeshPro>();
                if (leftBladeHealth > 4) leftHandTextComponent.color = Color.green;
                else if (leftBladeHealth > 2) leftHandTextComponent.color = Color.yellow;
                else leftHandTextComponent.color = Color.red;
                leftHandTextComponent.text = leftBladeHealth.ToString();
                BladeStartPatch.leftHandText.transform.LookAt(Camera.main.transform.position);
                BladeStartPatch.leftHandText.transform.Rotate(0, 180, 0);
            }

            if (BladeStartPatch.rightHandText != null)
            {
                int rightBladeHealth = StaticVariables.rightBladeHealth;
                TextMeshPro rightHandTextComponent = BladeStartPatch.rightHandText.GetComponent<TextMeshPro>();
                if (rightBladeHealth > 4) rightHandTextComponent.color = Color.green;
                else if (rightBladeHealth > 2) rightHandTextComponent.color = Color.yellow;
                else rightHandTextComponent.color = Color.red;
                rightHandTextComponent.text = rightBladeHealth.ToString();
                BladeStartPatch.rightHandText.transform.LookAt(Camera.main.transform.position);
                BladeStartPatch.rightHandText.transform.Rotate(0, 180, 0);
            }
        }
    }
}
