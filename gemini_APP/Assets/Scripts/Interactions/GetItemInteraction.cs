
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class GetItemInteraction : Interaction
{
    public string id;

    public string item_name;
    public PlayerInventory inventory;
    public bool takeItem = true;

    [TextArea]
    public List<string> haveItemDialog;
    [TextArea]
    public List<string> noItemDialog;

    private bool haveItem = false;

    public override GameObject trigger(DialogManager dialogManager)
    {
        var item = inventory.items.Find((item) => item.itemName.CompareTo(item_name) == 0);

        if (item)
        {
            haveItem = true;
            if (takeItem) {
                inventory.items.Remove(item);
            }
            dialogManager.startDialog(haveItemDialog);
        }
        else
        {
            dialogManager.startDialog(noItemDialog);
        }

        return dialogManager.gameObject;
    }

    public override bool checkOutput()
    {
        return haveItem;
    }

    public override Interaction InitDeserialize(InteractionData interactionData)
    {
        GetItemInteraction newInstance = new GetItemInteraction();
        GetItemInteractionData temp = (GetItemInteractionData) interactionData;
        newInstance.id = temp.id;
        newInstance.item_name = temp.item_name;
        newInstance.inventory = temp.inventory;
        newInstance.takeItem = temp.takeItem;
        newInstance.haveItemDialog = temp.haveItemDialog;
        newInstance.noItemDialog = temp.noItemDialog;
        return newInstance;
    }
}
