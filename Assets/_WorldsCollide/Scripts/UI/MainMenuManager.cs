using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WorldsCollide.MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        public void Play()
        {
            SceneManager.LoadScene(1);
        }
    }
}

