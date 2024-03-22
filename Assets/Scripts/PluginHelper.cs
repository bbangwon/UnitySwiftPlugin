using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using TMPro;

public class PluginHelper : MonoBehaviour
{
    #if UNITY_IOS
    [DllImport("__Internal")]
    private static extern int _addTwoNumberInIOS(int a, int b);
    #endif

    [SerializeField]
    private TextMeshProUGUI _resultText;
    
    void Start()
    {
        AddTwoNumber();
    }

    public void AddTwoNumber()
    {
        #if UNITY_IOS
        int result = _addTwoNumberInIOS(10, 20);
        _resultText.text = "Result: " + result;
        Debug.Log(result);
        #else
        Debug.Log("This is not iOS platform");
        #endif
    }
}
