using UnityEngine;

public class OnButtonClicked : MonoBehaviour
{
    private GameObject _player;
    private const float Dir = 1f;

    private void Start()
    {
        _player = GameObject.Find("Player");
    }
    
    /** Call by LButton Widget */
    public void LButtonClickedEvent()
    {
        var vector3 = _player.transform.position;
        vector3.x = vector3.x - Dir;
        _player.transform.position = vector3;
    }
    
    /** Call by RButton Widget */
    public void RButtonClickedEvent()
    {
        var  vector3 = _player.transform.position;
        vector3.x = vector3.x + Dir;
        _player.transform.position = vector3;
    }
}
