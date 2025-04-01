using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject _player;
    private const float ScreenX = 10.4f;
    private const float MoveX = .3f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _player = GameObject.Find("Player");
        GameObject.Find("GameDirector").GetComponent<Delegate>().OnCallBack();
    }

    // Update is called once per frame
    private void Update()
    {
        MovementByGetKeyDown();
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
