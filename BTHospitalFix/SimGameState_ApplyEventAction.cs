using BattleTech;
using Harmony;

namespace BTHospitalFix
{
    [HarmonyPatch(typeof(SimGameState), nameof(SimGameState.ApplyEventAction))]
    public class SimGameState_ApplyEventAction
    {
        public static bool Prefix(SimGameState __instance, SimGameResultAction action)
        {
            if (action.Type == SimGameResultAction.ActionType.System_PlayVideo && action.value == "mcb_exit_bt")
            {
                __instance.CompanyStats.Set("Funds", -10000000);
                __instance.InterruptQueue.QueueLossOutcome();
                return false;
            }
            return true;
        }
    }
}
