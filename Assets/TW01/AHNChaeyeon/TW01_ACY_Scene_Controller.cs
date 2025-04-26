using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TW01_ACY_Scene_Controller : MonoBehaviour
{
    public void OnClick_LoadScene(Object SceneObject)
    {
        SceneManager.LoadScene(SceneObject.name);
    }
}
