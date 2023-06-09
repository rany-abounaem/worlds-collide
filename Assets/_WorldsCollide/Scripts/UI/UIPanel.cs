using UnityEngine;
using UnityEngine.EventSystems;

public abstract class UIPanel : MonoBehaviour
{
    public virtual void Setup (Player player)
    {

    }
    public virtual void Open()
    {
        RefreshPage();
    }

    protected virtual void RefreshPage()
    {

    }

}
