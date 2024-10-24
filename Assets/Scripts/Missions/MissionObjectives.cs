using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MissionObjectives", menuName = "Mission/Objectives/Objective", order = 1)]
public class MissionObjectives : ScriptableObject
{ 
    public List<MissionObjective> objectives;
    
    public bool IsComplete => index >= objectives.Count;

    private int index = 0;

    public void Restart()
    {
        index = 0;

        foreach (MissionObjective objective in objectives)
        {
            objective.Restart();
        }
    }   
    
    public MissionObjective GetCurrentObjective()
    {
        return objectives[index];
    }
    
    public void AdvanceToNextObjective()
    {
        index++;
    }
    
    public void AdvanceObjective(int amount)
    {
        GetCurrentObjective().Update(amount);
    }
    
    public void SetCurrentProgress(int amount)
    {
        GetCurrentObjective().SetProgress(amount);
    }
}

[Serializable]
public class MissionObjective
{
    [SerializeField] private int reward;
    [SerializeField] private int objective;
    
    private int progress;

    public int Progress => progress;
    public int Objective => objective;
    public int Reward => reward;
    
    public bool IsComplete => progress >= objective;
    
    public void Restart()
    {
        progress = 0;
    }
    
    public void Update(int amount)
    {
        progress += amount;
    }
    
    public void SetProgress(int amount)
    {
        progress = amount;
    }
}