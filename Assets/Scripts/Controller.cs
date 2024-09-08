using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class Controller : MonoBehaviour
{
    public TMP_Text onofftext;
    public string url = "http://192.168.67.130:5005/led"; // Replace with your actual API endpoint

    private void Start()
    {
        
    }

    public void button1()
    {
        Debug.Log("Button clicked");

        if (onofftext.text == "ON")
        {
            onofftext.text = "OFF";
            StartCoroutine(SendPostRequest("off"));
        }
        else
        {
            onofftext.text = "ON";
            StartCoroutine(SendPostRequest("on"));
        }
    }

    private IEnumerator SendPostRequest(string action)
    {
        // Create an instance of ActionData with the appropriate action
        ActionData actionData = new ActionData(action);
        string jsonData = JsonUtility.ToJson(actionData);
        
        Debug.Log(jsonData);

        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Request successful: " + request.downloadHandler.text);
            }
            else
            {
                Debug.Log("Request failed: " + request.error);
            }
        }
    }
}

[System.Serializable]
public class ActionData
{
    public string action;

    public ActionData(string action)
    {
        this.action = action;
    }
}
