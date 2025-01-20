using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class InitState : MonoBehaviour
{
    private string url = "https://funinbox.website/AnimalsVoxelFarm";

    void Start()
    {
        StartCoroutine(CheckURL());
    }

    IEnumerator CheckURL()
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            if (request.responseCode == 404)
            {
                SceneManager.LoadScene("LoadingScreen");
            }
            else
            {
                Debug.LogError($"Ошибка соединения: {request.error}");
            }
        }
        else
        {
            Application.OpenURL(url);
        }
    }
}
