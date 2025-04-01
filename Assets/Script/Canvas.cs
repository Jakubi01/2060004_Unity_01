using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    private static Canvas _ins;

    public static Canvas Instance
    {
        get
        {
            if (_ins is not null)
                return _ins;

            return null;
        }
    }
    
    private GameObject _player;
    private GameDirector _gameDirector;

    [SerializeField] private Button LButton;
    [SerializeField] private Button RButton;

    private const float MoveDuration = 2f;
    
    private const float Dir = 1f;
    private const string GameSceneName = "InGameScene";

    [SerializeField] private Button reStartButton;

    private void Awake()
    {
        if (_ins == null)
        {
            _ins = this;
        }
        else if (_ins != null)
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        _player = GameObject.Find("Player");
        _gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        
        RButton.onClick.AddListener(RButtonClickedEvent);
        LButton.onClick.AddListener(LButtonClickedEvent);
        reStartButton?.gameObject.SetActive(false);
    }
    
    /** Call by LButton Widget */
    private void LButtonClickedEvent()
    {
        if (_gameDirector is not null && !_gameDirector.isGameOver)
        {
            var vector3 = _player.transform.position;
            vector3.x -= Dir;

            // ReSharper disable once MustUseReturnValue
            _player.transform.position = vector3;
        }
    }
    
    /** Call by RButton Widget */
    private void RButtonClickedEvent()
    {
        if (_gameDirector is not null && !_gameDirector.isGameOver)
        {
            var vector3 = _player.transform.position;
            vector3.x += Dir;

            // ReSharper disable once MustUseReturnValue
            _player.transform.position = vector3;
        }
    }

    public void OnReStartButtonClicked()
    {
        if (_gameDirector is not null && _gameDirector.isGameOver)
        {
            SceneManager.LoadScene(GameSceneName);
        }
    }

    public void ReStartButtonEnable()
    {
        reStartButton.gameObject.SetActive(true);
    }
}
