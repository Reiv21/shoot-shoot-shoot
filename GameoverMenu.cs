using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverMenu : MonoBehaviour
{
    public void Menu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public void PlayAgain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
