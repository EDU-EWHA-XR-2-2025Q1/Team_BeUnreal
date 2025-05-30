using System.Collections;
using System.Collections.Generic;
using TMPro; //text mesh pro
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene_Change : MonoBehaviour
{
    public TextMeshProUGUI routeTextField;  // Text (TMP)_Information 연결

    public void OnClick_LoadScene(Object SceneObject)
    {
        Debug.Log(SceneObject.name);

        string currentScene = SceneManager.GetActiveScene().name;
        SceneTracker.PreviousSceneName = currentScene;

        Debug.Log("Saved previous scene: " + currentScene);
        Debug.Log("Loading scene: " + SceneObject.name);

        // 추가: 텍스트 내용 저장
        if (routeTextField != null)
        {
            SceneTracker.RouteText = routeTextField.text;
            Debug.Log("Saved Route Text: " + SceneTracker.RouteText);
        }

        SceneManager.LoadScene(SceneObject.name);
    }

    // Status 씬에서 이전 씬으로 돌아가기
    public void ReturnToPreviousScene()
    {
        if (!string.IsNullOrEmpty(SceneTracker.PreviousSceneName))
        {
            Debug.Log("Returning to: " + SceneTracker.PreviousSceneName);
            SceneManager.LoadScene(SceneTracker.PreviousSceneName);
        }
        else
        {
            Debug.LogWarning("No previous scene recorded.");
        }
    }
}