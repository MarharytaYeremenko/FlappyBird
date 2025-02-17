using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenLogicScript : MonoBehaviour
{
    void Start()
    {
       
    }

    public void startGame(string scenename)
    {
        scenename = "SampleScene";
        SceneManager.LoadScene(scenename);
    }
}
