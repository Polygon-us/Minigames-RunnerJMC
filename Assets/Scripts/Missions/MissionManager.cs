using System;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public List<MissionAndData> missions = new();

    private static MissionManager _instance;

    public static MissionManager Instance
    {
        get
        {
            if (_instance)
                return _instance;
            
            _instance = FindFirstObjectByType<MissionManager>();
        
            if (!_instance)
                _instance = Instantiate(Resources.Load<MissionManager>("MissionManager"));
            
            DontDestroyOnLoad(_instance.gameObject);
            
            return _instance;
        }
    }

    // Will add missions until we reach 2 missions.
    public void StartMissions()
    {
        foreach (var mission in missions)
        {
            mission.mission.Created(mission.objectives);
        }
    }

    public void StartRunMissions(TrackManager manager)
    {
        foreach (var mission in missions)
        {
            mission.mission.RunStart(manager);
        }
    }

    public void UpdateMissions(TrackManager manager)
    {
        foreach (var mission in missions)
        {
            mission.mission.UpdateMission(manager);
        }
    }

    public bool AnyMissionComplete()
    {
        return missions.Exists(eachMission => eachMission.mission.AreAllObjectivesComplete);
    }

    public void ClaimMission(MissionBase mission)
    {
        if (!mission.AreAllObjectivesComplete)
            mission.MissionObjectives.AdvanceToNextObjective();
        else
            missions.RemoveAll(eachMission => eachMission.mission == mission);
    }
}

[Serializable]
public class MissionAndData
{
    public MissionBase mission;
    public MissionObjectives objectives;
}