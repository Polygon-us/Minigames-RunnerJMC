using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "UserModelSO", menuName = "Models/UserModelSO")]
public class UserModel : ScriptableObject
{
    public string username = string.Empty;
    public int distance = 0;

    public void Clear()
    {
        username = string.Empty;
        distance = 0;
    }

    public void SetData(LoginDetails data)
    {
        username = data.username;

        var leaderboard = data.leaderboard.FirstOrDefault(entry => GameConfiguration.GameType.ToString() == entry.gameType);

        if (leaderboard == null)
            return;

        distance = leaderboard.distance;
    }
}