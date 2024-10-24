using System;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public List<MissionAndData> missions = new List<MissionAndData>();

    private static MissionManager _instance;

    public static MissionManager Instance
    {
        get
        {
            if (!_instance)
                _instance = Resources.Load<MissionManager>("MissionManager");
            return _instance;
        }
    }

    // Mission management

    // Will add missions until we reach 2 missions.
    // public void CheckMissionsCount()
    // {
    //     while (missions.Count < 2)
    //         AddMission();
    // }
    //
    public void AddMission()
    {
        foreach (var mission in missions)
        {
            mission.mission.Created(mission.objectives);
        }
    }

    public void StartRunMissions(TrackManager manager)
    {
        for (int i = 0; i < missions.Count; ++i)
        {
            missions[i].mission.RunStart(manager);
        }
    }

    public void UpdateMissions(TrackManager manager)
    {
        for (int i = 0; i < missions.Count; ++i)
        {
            missions[i].mission.UpdateMission(manager);
        }
    }

    public bool AnyMissionComplete()
    {
        for (int i = 0; i < missions.Count; ++i)
        {
            if (missions[i].mission.IsComplete) return true;
        }

        return false;
    }

    public void ClaimMission(MissionBase mission)
    {
        missions.RemoveAll(eachMission => eachMission.mission == mission);

        // CheckMissionsCount();
    }
}

[Serializable]
public class MissionAndData
{
    public MissionBase mission;
    public MissionObjectives objectives;
}