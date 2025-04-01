using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject _player;
    private GameDirector _gameDirector;

    private const float ScreenX = 10.4f;
    private const float MoveX = .3f;
    
    private void Start()
    {
        _gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        if (_gameDirector is not null && !_gameDirector.isGameOver)
        {
            MovementByGetKeyDown();
        }
    }

    private void MovementByGetKeyDown()
    {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
            && _player.transform.position.x >= -ScreenX)
        {
            _player.transform.Translate(-MoveX, 0f, 0f);
        }
        else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) 
                 &&  _player.transform.position.x <= ScreenX)
        {
            _player.transform.Translate(MoveX, 0f, 0f);
        }
    }
}
