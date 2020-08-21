using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _gravity = 1f;
    [SerializeField] private float _jumpHeight = 10.0f;
    [SerializeField] private int _coins = 0;
    [SerializeField] private int _lives = 3;
    [SerializeField] private GameObject _respawnPoint;
    private UIManager _uiManager;
    private GameManager _gameManager;
    private CharacterController _controller;
    private float _yVelocity;
    private bool _canDoubleJump = false;
    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uiManager == null)
        {
            Debug.LogError("Player::UIManager is null");
        }

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (_gameManager == null)
        {
            Debug.LogError("Player::GameManager is null");
        }

        _controller = GetComponent<CharacterController>();

        if (_controller == null)
        {
            Debug.LogError("Player::Controller is null");
        }

        _uiManager.UpdateLivesDisplay(_lives);

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float yPos = transform.position.y;
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(horizontalInput, 0, 0);

        Vector3 velocity = direction * _speed;

        if (_controller.isGrounded == true)
        {
            // maybe jump here
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {
            if (_canDoubleJump == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _yVelocity += _jumpHeight;
                    _canDoubleJump = false;
                }
            }
            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;

        _controller.Move(velocity * Time.deltaTime);

        if (yPos <= -8f)
        {
            PlayerDeath();
            transform.position = _respawnPoint.transform.position;
        }
    }

    public void AddCoin()
    {
        _coins++;

        _uiManager.UpdateCoinDisplay(_coins);
    }

    void PlayerDeath()
    {
        _lives--;

        _uiManager.UpdateLivesDisplay(_lives);

        if (_lives < 1)
        {
            _gameManager.GameOverSequence();
        }
    }
}
