using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public void startSelection()
    {
        SceneManager.LoadScene(1);
    }

    public void endGame()
    {
        SceneManager.LoadScene(0);
    }
}
