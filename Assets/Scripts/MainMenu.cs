using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ExitButton(){
        Application.Quit();
        Debug.Log("application closed");
    }

    public void onAtomicAudioVisualizationClicked(){
        SceneManager.LoadScene("AtomicAudioBeatSynchronization");
    }
    
    public void onMolecularStructureClicked(){
        SceneManager.LoadScene("MolecularStructure");
    }
    
    public void onObritalChemistryClicked(){
        SceneManager.LoadScene("OrbitalChemistry");
    }
}
