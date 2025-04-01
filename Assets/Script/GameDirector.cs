using Unity.Mathematics.Geometry;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    [SerializeField]
    private GameObject hpGauge;

    private const int TargetFrameRate = 60;
    private const float HpGaugeDuration = .1f;

    public bool isGameOver = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Application.targetFrameRate = TargetFrameRate;
        Time.timeScale = 1f;
    }

    public void DecreaseHp()
    {
        if (hpGauge == null) return;
        hpGauge.GetComponent<Image>().fillAmount -= HpGaugeDuration;

        if (hpGauge.GetComponent<Image>().fillAmount <= 0)
        {
            Canvas.Instance.ReStartButtonEnable();
            Time.timeScale = 0f;
            isGameOver = true;
        }
    }
}
