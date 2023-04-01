using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace RacePrototype
{
    public class MainMenu_Controllert : MonoBehaviour
    {

        [SerializeField] private Button _start;
        [SerializeField] private Button _tuning;
        [SerializeField] private Button _exit;


        private void OnEnable()
        {
            _start.onClick.AddListener(delegate { LoadScene(SceneExample.Drive); });
            _tuning.onClick.AddListener(delegate { LoadScene(SceneExample.Tuning); });
            _exit.onClick.AddListener(delegate { LoadScene(SceneExample.Exit); });
        }

        private void OnDisable()
        {
            _start.onClick.RemoveListener(delegate { LoadScene(SceneExample.Drive); });
            _tuning.onClick.RemoveListener(delegate { LoadScene(SceneExample.Tuning); });
            _exit.onClick.RemoveListener(delegate { LoadScene(SceneExample.Exit); });
        }

        private void LoadScene(SceneExample sceneExample)
        {
            if(sceneExample == SceneExample.Drive)
                SceneManager.LoadScene(1);
            if(sceneExample == SceneExample.Tuning)
                SceneManager.LoadScene(2);
            if(sceneExample == SceneExample.Exit)
            {
                Application.Quit();
                Debug.Log("Выход из приложения");
            }
                
        }
    }
}