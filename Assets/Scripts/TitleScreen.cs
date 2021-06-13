using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void LoadSong(int song)
    {
        SceneManager.LoadScene(song);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
