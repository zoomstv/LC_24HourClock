using HarmonyLib;
using TMPro;

namespace _24HourClock.Patches
{
    [HarmonyPatch(typeof(HUDManager))]
    internal class HUDManagerPatch
    {
        public static HUDManagerPatch Instance;

        private static TextMeshProUGUI clockNumber;

        void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
        }

        [HarmonyPatch("SetClock")]
        [HarmonyPostfix]
        static void SetClockPatch(float timeNormalized, float numberOfHours, bool createNewLine = true)
        {
            clockNumber = HUDManager.Instance.clockNumber;

            int minutes = (int)(timeNormalized * (60f * numberOfHours)) + 360;

            int hours = minutes / 60;
            minutes = minutes % 60;

            string timeString = hours.ToString("00") + ":" + minutes.ToString("00");

            clockNumber.text = timeString;
        }
    }
}
