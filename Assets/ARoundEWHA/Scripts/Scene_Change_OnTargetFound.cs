using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;
using System.Collections;

public class SceneChangerOnTargetFound : MonoBehaviour
{
    public string sceneNameToLoad = "";  

    private ObserverBehaviour observerBehaviour;
    private bool isSceneLoaded = false;


    [Range(10, 200)]
    public int fontSize = 50;
    public Color textColor = Color.black;
    public Color backgroundColor = Color.white;
    public float boxWidth = 800;
    public float boxHeight = 200;
    string message = "";


    public void OnTarget_Found(string _s)
    {
        message = _s;
    }

    public void OnTarget_Lost(string _s)
    {
        message = _s;
    }

    void OnGUI()
    {
        if (string.IsNullOrEmpty(message)) return;

        GUIStyle style = new GUIStyle(GUI.skin.box);
        style.fontSize = 50;
        style.normal.textColor = textColor;
        style.alignment = TextAnchor.MiddleCenter;
        style.normal.background = MakeTex(2, 2, backgroundColor);

        float x = (Screen.width - boxWidth) / 2;
        float y = (Screen.height - boxHeight) / 2;

        GUI.Box(new Rect(x, y, boxWidth, boxHeight), message, style);
    }

    Texture2D MakeTex(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < pix.Length; i++)
            pix[i] = col;

        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();

        return result;
    }
    
    void Start()
    {
        observerBehaviour = GetComponent<ObserverBehaviour>();

        if (observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        if (!isSceneLoaded &&
            (targetStatus.Status == Status.TRACKED || targetStatus.Status == Status.EXTENDED_TRACKED))
        {
            isSceneLoaded = true;
            StartCoroutine(LoadSceneWithDelay(0.5f));
        }
    }

    private IEnumerator LoadSceneWithDelay(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        SceneManager.LoadScene(sceneNameToLoad);
    }

}
