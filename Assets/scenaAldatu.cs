using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class scenaAldatu : MonoBehaviour
{
    public void nextScene()
    {
        SceneManager.LoadScene("Scena01");
    }

    public void exit()
    {
        Application.Quit();
    }
}
