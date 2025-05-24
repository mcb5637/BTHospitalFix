using BattleTech;
using Harmony;

namespace BTHospitalFix
{
    [HarmonyPatch(typeof(SimGameState), nameof(SimGameState.ApplyEventAction))]
    public class SimGameState_ApplyEventAction
    {
        public static bool Prefix(SimGameResultAction action)
        {
            if (action.Type == SimGameResultAction.ActionType.System_PlayVideo && action.value == "mcb_exit_bt")
            {
                SimGameState s = UnityGameInstance.BattleTechGame.Simulation;
                s.CompanyStats.Set("Funds", -10000000);
                s.InterruptQueue.QueueLossOutcome();
                return false;
            }
            return true;
        }
    }
}
