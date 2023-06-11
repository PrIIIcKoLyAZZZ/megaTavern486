using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] private int _level;
    [SerializeField] private GameObject _pause;
    private bool _isPaused = false;

    private void Start()
    {
        
    }

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_isPaused)
            {
                _pause.SetActive(true);
                _isPaused = true;
                Time.timeScale = 0f;
            }
            else
            {
                _pause.SetActive(false);
                _isPaused = false;
                Time.timeScale = 1f;
            }
        }
    }

    public void Restart()
    {
        Application.LoadLevel(_level);
        Time.timeScale = 1f;
    }
}
