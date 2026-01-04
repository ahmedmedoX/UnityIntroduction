using UnityEngine;
using UnityEngine.UI;

public class InventoryUI_Script : MonoBehaviour
{
    public uint Number_of_Items = 1;
    public GameObject Inventory_Panel;
    public GameObject Inventory_Layout;
    public GameObject ItemUI;
    bool is_InventoryActive = false;
    void Start()
    {
        GameObject item_Obj;
        for(int i = 0; i < Number_of_Items; i++)
        {
            item_Obj = Instantiate(ItemUI, Inventory_Layout.transform);
        }
    }
    public void OnClick()
    {
        is_InventoryActive = !is_InventoryActive;
        Inventory_Panel.SetActive(is_InventoryActive);
    }
}