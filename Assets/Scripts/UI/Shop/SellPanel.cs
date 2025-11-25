using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] _sellButtons;
    private ISell[] _iSellButtons;

    private ISell[] GetSellInterfaces()
    {
        List<ISell> sellInterfaces = new List<ISell>();
        foreach (var obj in _sellButtons)
        {
            var sellComponent = obj.GetComponent<ISell>();
            if (sellComponent != null)
                sellInterfaces.Add(sellComponent);
        }
        return sellInterfaces.ToArray();
    }
    
    private void Awake()
    {
        _iSellButtons = GetSellInterfaces();
    }

    public void ClosePanel()
    {
        Destroy(gameObject);
    }
}
