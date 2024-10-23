using UnityEngine;

public class PickupMission : MissionBase
{
    int previousCoinAmount;

    public override void Created()
    {
        float[] maxValues = { 1000, 2000, 3000, 4000 };
        int chosen = Random.Range(0, maxValues.Length);

        max = maxValues[chosen];
        reward = chosen + 1;
        progress = 0;
    }

    public override string GetMissionDesc()
    {
        return "Pickup " + max + " fishbones";
    }

    public override MissionType GetMissionType()
    {
        return MissionType.PICKUP;
    }

    public override void RunStart(TrackManager manager)
    {
        previousCoinAmount = 0;
    }

    public override void Update(TrackManager manager)
    {
        int coins = manager.characterController.coins - previousCoinAmount;
        progress += coins;

        previousCoinAmount = manager.characterController.coins;
    }
}