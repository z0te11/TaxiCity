using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private GameObject _sellRegenPanel;
    [SerializeField] private GameObject _sellFuelPanel;
    private GameObject _currentPanel = null;

    private void InitializeSellPanel(GameObject sellPanel)
    {
        if (!sellPanel.GetComponent<SellPanel>()) return;
        if (_currentPanel != null) Destroy(_currentPanel);

        GameObject newSellPanel = Instantiate(sellPanel, this.transform.position, Quaternion.identity, this.transform);
        _currentPanel = newSellPanel;
    }

    public void OpenSellRegenPanel()
    {
        InitializeSellPanel(_sellRegenPanel);
    }

    public void OpenSellFuelPanel()
    {
        InitializeSellPanel(_sellFuelPanel);
    }
}
