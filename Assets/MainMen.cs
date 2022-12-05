using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMen : MonoBehaviour
{
    public void ExitButton(){
        Application.Quit();
        Debug.Log("application closed");
    }

    public void StartButton(){
        SceneManager.LoadScene("AtomicPresets");
    }
}
