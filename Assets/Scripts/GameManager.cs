using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    void GameOver()
    {
        _isGameOver = true;
    }

    public void GameOverSequence()
    {
        GameOver();

        if (_isGameOver == true)
        {
            SceneManager.LoadScene(0);
        }
    }


}
