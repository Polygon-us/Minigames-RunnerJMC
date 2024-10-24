using UnityEngine;
using UnityEngine.UI;

public class MissionEntry : MonoBehaviour
{
    public Text descText;
    public Text rewardText;
    public Button claimButton;
    public Text progressText;
	public Image background;

	public Color notCompletedColor;
	public Color completedColor;

    public void FillWithMission(MissionBase mission, MissionUI owner)
    {
        descText.text = mission.GetMissionDesc();
        rewardText.text = mission.MissionObjectives.GetCurrentObjective().Reward.ToString();

        if (mission.IsObjectiveComplete)
        {
            claimButton.gameObject.SetActive(true);
            progressText.gameObject.SetActive(false);

			background.color = completedColor;

			progressText.color = Color.white;
			descText.color = Color.white;
			rewardText.color = Color.white;

			claimButton.onClick.AddListener(delegate { owner.Claim(mission); } );
        }
        else
        {
            claimButton.gameObject.SetActive(false);
            progressText.gameObject.SetActive(true);

			background.color = notCompletedColor;

			progressText.color = Color.black;
			descText.color = completedColor;

			progressText.text = $"{mission.MissionObjectives.GetCurrentObjective().Progress} / {mission.MissionObjectives.GetCurrentObjective().Objective}";
        }
    }
}
