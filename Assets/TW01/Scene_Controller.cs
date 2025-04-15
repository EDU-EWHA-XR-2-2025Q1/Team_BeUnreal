using System.Collections;
using System.Collections.Generic;
using TMPro; //text mesh pro
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene_Controller : MonoBehaviour
{
    public void OnClick_LoadScene(Object SceneObject)
    {
        Debug.Log(SceneObject.name);
        SceneManager.LoadScene(SceneObject.name);
    }
}