using UnityEngine;

public abstract class MissionBase : ScriptableObject
{
    protected MissionObjectives missionObjectives;
    
    public MissionObjectives MissionObjectives => missionObjectives;

    public bool IsComplete => missionObjectives.IsComplete;

	public virtual bool HaveProgressBar() { return true; }

    public virtual void Created(MissionObjectives objectives)
    {
        missionObjectives = objectives;
        missionObjectives.Restart();
    }

    public abstract string GetMissionDesc();
    public abstract void RunStart(TrackManager manager);
    public abstract void UpdateMission(TrackManager manager);
}