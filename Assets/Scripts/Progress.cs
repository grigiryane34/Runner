using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;


public class Progress : MonoBehaviour
{

    private PrefsValue<int> coins = new PrefsValue<int>("Coins", 0);
    private PrefsValue<int> width = new PrefsValue<int>("Width", 0);
    private PrefsValue<int> height = new PrefsValue<int>("Height", 0);
    
    public int Coins 
    {
        get => coins.Value;
        set => coins.Value = value; 
    }
    public int Width
    {
        get => width.Value;
        set => width.Value = value;
    }
    public int Height
    {
        get => height.Value;
        set => height.Value = value;
    }

    public static Progress Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
