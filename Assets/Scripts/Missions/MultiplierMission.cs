using UnityEngine;

[CreateAssetMenu(fileName = "MultiplierMission", menuName = "Mission/Multiplier", order = 1)]
public class MultiplierMission : MissionBase
{
    public override bool HaveProgressBar()
    {
        return false;
    }

    public override string GetMissionDesc()
    {
        return $"Reach a x{missionObjectives.GetCurrentObjective().Objective} multiplier";
    }

    public override void RunStart(TrackManager manager)
    {
    }

    public override void UpdateMission(TrackManager manager)
    {
        if (manager.multiplier > missionObjectives.GetCurrentObjective().Objective)
            missionObjectives.SetCurrentProgress(manager.multiplier);
    }
}