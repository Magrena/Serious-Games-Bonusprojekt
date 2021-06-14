using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    public void Quit()
    {
        SceneController.instance.Quit();
    }
    public void LoadScene(string sceneName)
    {
        SceneController.instance.LoadScene(sceneName);
    }
}
