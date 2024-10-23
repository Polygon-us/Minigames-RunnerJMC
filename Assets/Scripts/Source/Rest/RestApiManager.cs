using System;
using Newtonsoft.Json;
using UnityEngine;
using UnityREST;

[DefaultExecutionOrder(-200)]
public class RestApiManager : APIManager
{
    [SerializeField] private GameConfiguration gameConfig;

    private static RestApiManager _instance;

    public static RestApiManager Instance
    {
        get
        {
            if (_instance)
                return _instance;

            GameObject go = Resources.Load<GameObject>("Prefabs/RestApi");

            _instance = go.GetComponent<RestApiManager>();

            return _instance;
        }
    }

    protected override void Awake()
    {
        if (!_instance)
        {
            _instance = this;
            transform.SetParent(null);

            DontDestroyOnLoad(_instance.gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        base.Awake();
    }

    public void SetAuthToken(string token)
    {
        Transport.SetAuthToken(token);
    }

    public void GetRequest<T>(string endpoint, Action<WebResult<T>> callback = null, string[] args = null)
    {
        StartRequest(endpoint, path => Transport.GET(PathWithArgs(path, args), callback));
    }

    public void PostRequest<T>(string endpoint, object data, Action<WebResult<T>> callback = null, string[] args = null)
    {
        StartRequest(endpoint, path => Transport.POST(PathWithArgs(path, args), JsonConvert.SerializeObject(data), callback));
    }

    public void PatchRequest<T>(string endpoint, object data, Action<WebResult<T>> callback)
    {
        StartRequest(endpoint, path => Transport.PATCH(path, JsonConvert.SerializeObject(data), callback));
    }

    public static string GetErrorResponse(string json)
    {
        return JsonConvert.DeserializeObject<ErrorResponse>(json).error;
    }

    private void OnDestroy()
    {
        Transport?.SignOut();
    }

    private static string PathWithArgs(string path, string[] args)
    {
        return path + (args != null ? $"?{string.Join("&", args)}" : "");
    }
}

[Serializable]
public class ErrorResponse
{
    public string error;
}