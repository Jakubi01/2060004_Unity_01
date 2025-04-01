using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    [SerializeField]
    private GameObject hpGauge;

    private const int TargetFrameRate = 60;
    private const float HpGaugeDuration = .1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Application.targetFrameRate = TargetFrameRate;
    }

    public void DecreaseHp()
    {
        if (hpGauge == null) return;
        hpGauge.GetComponent<Image>().fillAmount -= HpGaugeDuration;
    }
}
