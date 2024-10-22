using System;
using UnityREST;

public class RegisterHandler : BaseHandler
{
    public void Register(string fullName, string email, string phone, string username, bool acceptedTerms,
        Action<WebResult<object>> onRegister = null)
    {
        var payload = new RegisterPayload
        {
            fullName = fullName,
            email = email,
            phone = phone,
            username = username,
            acceptedTerms = acceptedTerms
        };

        RestApiManager.Instance.PostRequest("register", payload, onRegister);
    }
}

public class RegisterPayload
{
    public string fullName;
    public string email;
    public string phone;
    public string username;
    public bool acceptedTerms;
}
