using UnityEngine;

public class SingleRunMission : MissionBase
{
    public override void Created()
    {
        float[] maxValues = { 500, 1000, 1500, 2000 };
        int chosenVal = Random.Range(0, maxValues.Length);

        reward = chosenVal + 1;
        max = maxValues[chosenVal];
        progress = 0;
    }

    public override bool HaveProgressBar()
    {
        return false;
    }

    public override string GetMissionDesc()
    {
        return "Run " + ((int)max) + "m in a single run";
    }

    public override MissionType GetMissionType()
    {
        return MissionType.SINGLE_RUN;
    }

    public override void RunStart(TrackManager manager)
    {
        progress = 0;
    }

    public override void Update(TrackManager manager)
    {
        progress = manager.worldDistance;
    }
}