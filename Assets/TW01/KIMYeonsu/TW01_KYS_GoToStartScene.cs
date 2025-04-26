using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TW01_KYS_GoToStartScene : MonoBehaviour
{
    public void LoadStartScene()
    {
        SceneManager.LoadScene("TW01_StartScene");
    }
}
