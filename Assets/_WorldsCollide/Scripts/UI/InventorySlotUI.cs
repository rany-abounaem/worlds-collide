using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : SlotUI
{
    public override string GetSlotTooltip()
    {
        var __item = (Item)_slottable;
        return String.Format("{0}<br>Description: {1}", __item.GetName(), __item.GetDescription());
    }
}
