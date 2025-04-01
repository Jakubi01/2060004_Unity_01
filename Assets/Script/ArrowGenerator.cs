using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ArrowGenerator : MonoBehaviour
{
    [SerializeField]
    private  GameObject arrowPrefab;
    
    private const float Span = .5f;
    private const int RandomNumber = 10;
    private const int ArrowSpawnY = 7;

    private void Start()
    {
        StartCoroutine(SpawnArrow());
    }

    /** 주석 */
    IEnumerator SpawnArrow()
    {
        while(true)
        {
            var go = Instantiate(arrowPrefab);
            var px = Random.Range(-RandomNumber, RandomNumber);
            go.transform.position = new Vector3(px, ArrowSpawnY, 0);
            
            yield return new WaitForSeconds(Span);
        }
        // ReSharper disable once IteratorNeverReturns
    }
}
