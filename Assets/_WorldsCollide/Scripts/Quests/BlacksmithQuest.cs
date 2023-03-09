using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BlacksmithQuest", menuName = "ScriptableObjects/Quests/BlacksmithQuest", order = 1)]
[System.Serializable]
public class BlacksmithQuest : Quest
{
    public Item blacksmithHammer;

    public override QuestResponse ProcessQuest()
    {
        switch (stage)
        {
            case 0:
                QuestTracker.instance.StartQuest(this);
                state = QuestState.IN_PROGRESS;
                stage++;
                return QuestResponse.CLOSE_DIALOGUE;

            case 1:
                if (InventoryManager.instance.RemoveItem(blacksmithHammer))
                {
                    state = QuestState.DONE;
                    stage++;
                    return QuestResponse.CONTINUE_DIALOGUE;
                }
                else
                    return QuestResponse.CLOSE_DIALOGUE;
            case 2:
                return QuestResponse.CLOSE_DIALOGUE;
            default:
                return QuestResponse.CLOSE_DIALOGUE;
        }
        //if (stage == 0)
        //{
        //    if (InventoryManager.instance.RemoveFromInventory(blacksmithHammer))
        //        return true;
        //    else
        //        return false;
        //}
        //return true;
    }
}
