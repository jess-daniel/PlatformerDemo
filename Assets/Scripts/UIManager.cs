using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _coinText;
    [SerializeField] private Text _livesText;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        _coinText.text = "Coins: " + 0;
    }

    // update coin display
    public void UpdateCoinDisplay(int coins)
    {
        _coinText.text = $"Coins: {coins}";
    }

    public void UpdateLivesDisplay(int lives)
    {
        _livesText.text = $"Lives: {lives}";
    }
}
