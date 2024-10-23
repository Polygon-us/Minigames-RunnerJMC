using System.IO;

public abstract class MissionBase
{
    // Mission type
    public enum MissionType
    {
        SINGLE_RUN,
        PICKUP,
        OBSTACLE_JUMP,
        SLIDING,
        MULTIPLIER,
        MAX
    }

    public float progress;
    public float max;
    public int reward;

    public bool isComplete { get { return (progress / max) >= 1.0f; } }

    public void Serialize(BinaryWriter w)
    {
        w.Write(progress);
        w.Write(max);
        w.Write(reward);
    } 

    public void Deserialize(BinaryReader r)
    {
        progress = r.ReadSingle();
        max = r.ReadSingle();
        reward = r.ReadInt32();
    }

	public virtual bool HaveProgressBar() { return true; }

    public abstract void Created();
    public abstract MissionType GetMissionType();
    public abstract string GetMissionDesc();
    public abstract void RunStart(TrackManager manager);
    public abstract void Update(TrackManager manager);

    public static MissionBase GetNewMissionFromType(MissionType type)
    {
        return type switch
        {
            MissionType.SINGLE_RUN => new SingleRunMission(),
            MissionType.PICKUP => new PickupMission(),
            MissionType.OBSTACLE_JUMP => new BarrierJumpMission(),
            MissionType.SLIDING => new SlidingMission(),
            MissionType.MULTIPLIER => new MultiplierMission(),
            _ => null
        };
    }
}