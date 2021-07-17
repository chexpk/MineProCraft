using System;

[Serializable]
public class InventoryItem
{
    public Item item;
    public bool isExist = false;
    public int count = 0;
    public InventoryCell cell;
    public StringEvent changedEvent = new StringEvent();

    public void Render()
    {
        cell.Render(this);
    }

    public void Increase()
    {
        count++;
        SetExist();
        Render();
        changedEvent.Invoke("increase");
    }

    public void Decrease()
    {
        count--;
        SetExist();
        if (!isExist)
        {
            ClearInventoryItem();
        }
        else
        {
            Render();
            changedEvent.Invoke("decrease");
        }
    }

    public void SetCell(InventoryCell cell)
    {
        this.cell = cell;
        Render();
    }

    public void UnselectCell()
    {
        cell.DeactivateCellFrame();
    }

    public void Select()
    {
        cell.ActivateCellFrame();
    }

    public bool AddInventoryItem(InventoryItem inventoryItem)
    {
        if (inventoryItem == this) return false;
        if (!inventoryItem.isExist) return false;
        if (item != inventoryItem.item && isExist) return false;

        item = inventoryItem.item;
        count += inventoryItem.count;
        isExist = true;
        Render();
        inventoryItem.ClearSource();

        changedEvent.Invoke("moveto");

        return true;
    }

    void ClearSource()
    {
        item = null;
        isExist = false;
        count = 0;
        Render();
        changedEvent.Invoke("movefrom");
    }

    public void ClearInventoryItem()
    {
        //TODO вставить новые поля item

        item = null;
        isExist = false;
        count = 0;
        Render();
        changedEvent.Invoke("clear");
    }

    void SetExist()
    {
        if (count > 0)
        {
            isExist = true;
        }
        else
        {
            isExist = false;
        }
    }
}
