using UnityEngine;

[CreateAssetMenu(fileName = "SingleRunMission", menuName = "Mission/SingleRun", order = 1)]
public class SingleRunMission : MissionBase
{
    public override bool HaveProgressBar()
    {
        return false;
    }

    public override string GetMissionDesc()
    {
        return $"Run {missionObjectives.GetCurrentObjective().Objective}m in a single run";
    }

    public override void RunStart(TrackManager manager)
    {
        // progress = 0;
    }

    public override void UpdateMission(TrackManager manager)
    {
        missionObjectives.AdvanceObjective((int)manager.worldDistance);
    }
}