using UnityEngine;

public delegate void TooltipCallback(GameObject raiser, string str);
public delegate void GameObjectCallback(GameObject gameObj);

[CreateAssetMenu(fileName = "TooltipChannel", menuName = "ScriptableObjects/UI/Tooltip")]
public class TooltipChannel : ScriptableObject
{
    public event TooltipCallback OnTooltipRequest;
    public event GameObjectCallback OnTooltipCancel;

    public void Raise(GameObject raiser, string str)
    {
        OnTooltipRequest?.Invoke(raiser, str);
    }

    public void Cancel(GameObject canceler)
    {
        OnTooltipCancel?.Invoke(canceler);
    }
}
