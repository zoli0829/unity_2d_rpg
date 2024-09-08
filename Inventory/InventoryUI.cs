using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : Singleton<InventoryUI>
{
    [Header("Config")]
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private InventorySlot slotPrefab;
    [SerializeField] private Transform container;

    public InventorySlot CurrentSlot { get; set; }

    private List<InventorySlot> slotList = new List<InventorySlot>();

    protected override void Awake()
    {
        base.Awake();
        InitInventory();
    }

    private void InitInventory()
    {
        for (int i = 0; i < Inventory.Instance.InventorySize; i++)
        {
            InventorySlot slot = Instantiate(slotPrefab, container);
            slot.Index = i;
            slotList.Add(slot);
        }
    }

    public void UseItem()
    {
        if (CurrentSlot == null) return;
        Inventory.Instance.UseItem(CurrentSlot.Index);
    }

    public void RemoveItem()
    {
        if (CurrentSlot == null) return;
        Inventory.Instance.RemoveItem(CurrentSlot.Index);
    }

    public void DrawItem(InventoryItem item, int index)
    {
        InventorySlot slot = slotList[index];
        if(item == null)
        {
            slot.ShowSlotInformation(false);
            return;
        }

        slot.ShowSlotInformation(true);
        slot.UpdateSlot(item);
    }

    public void OpenCloseInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }

    private void SlotSelectedCallback(int slotIndex)
    {
        CurrentSlot = slotList[slotIndex];
    }

    private void OnEnable()
    {
        InventorySlot.OnSlotSelectedEvent += SlotSelectedCallback;
    }

    private void OnDisable() 
    {
        InventorySlot.OnSlotSelectedEvent -= SlotSelectedCallback;
    }
}
