using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class MissionUI : MonoBehaviour
{
    public RectTransform missionPlace;
    public AssetReference missionEntryPrefab;

    public IEnumerator Open()
    {
        gameObject.SetActive(true);

        foreach (Transform t in missionPlace)
            Addressables.ReleaseInstance(t.gameObject);

        foreach (var mission in MissionManager.Instance.missions)
        {
            AsyncOperationHandle op = missionEntryPrefab.InstantiateAsync();
            yield return op;
            if (op.Result == null || !(op.Result is GameObject))
            {
                Debug.LogWarning(string.Format("Unable to load mission entry {0}.", missionEntryPrefab.Asset.name));
                yield break;
            }

            MissionEntry entry = (op.Result as GameObject).GetComponent<MissionEntry>();
            entry.transform.SetParent(missionPlace, false);
            entry.FillWithMission(mission.mission, this);
        }
    }

    public void CallOpen()
    {
        gameObject.SetActive(true);
        StartCoroutine(Open());
    }

    public void Claim(MissionBase mission)
    {
        MissionManager.Instance.ClaimMission(mission);

        // Rebuild the UI with the new missions
        StartCoroutine(Open());
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}