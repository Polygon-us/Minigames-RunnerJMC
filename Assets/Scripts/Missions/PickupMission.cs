using UnityEngine;

[CreateAssetMenu(fileName = "PickupMission", menuName = "Mission/Pickup", order = 1)]
public class PickupMission : MissionBase
{
    int previousCoinAmount;

    public override string GetMissionDesc()
    {
        return $"Pickup {missionObjectives.GetCurrentObjective().Objective} fishbones";
    }

    public override void RunStart(TrackManager manager)
    {
        previousCoinAmount = 0;
    }

    public override void UpdateMission(TrackManager manager)
    {
        int coins = manager.characterController.coins - previousCoinAmount;
       
        missionObjectives.AdvanceObjective(coins);

        previousCoinAmount = manager.characterController.coins;
    }
}