using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private GameObject _player;
    private GameObject _gameDirector;
    private const float R1 = 0.5f;
    private const float R2 = 1.0f;
    private const float ArrowMoveY = -.1f;
    private const float KillY = -4f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _player = GameObject.Find("Player");
        _gameDirector = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    private void Update()
    {
        ArrowMovement();
        CollisionCheck();
    }

    private void ArrowMovement()
    {
        transform.Translate(0f, ArrowMoveY, 0f);
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void CollisionCheck()
    {
        if (transform.position.y < KillY)
        {
            Destroy(gameObject);
            Debug.Log("ss");
        }

        var p1 = transform.position;
        var p2 = _player.transform.position;
        Vector2 dir = p1 - p2;
        var d = dir.magnitude;

        if (!(d < R1 + R2)) 
            return;
        
        Destroy(gameObject);
        _gameDirector?.GetComponent<GameDirector>().DecreaseHp();
    }
}
