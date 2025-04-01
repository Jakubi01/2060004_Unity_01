using UnityEngine;

public class Delegate : MonoBehaviour
{
    public delegate void OnCallBackSignature();
    public OnCallBackSignature OnCallBack;

    private void Start()
    {
        OnCallBack = PrintObjectName;
    }
    
    private void PrintObjectName()
    {
        Debug.Log(gameObject.name);
    }
}
