using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FirstNPCQuest", menuName = "ScriptableObjects/Quests/FirstNPCQuest", order = 1)]
[System.Serializable]
public class FirstNPCQuest : Quest
{

    public override QuestResponse ProcessQuest()
    {
        switch (stage)
        {
            case 0:
                QuestTracker.instance.StartQuest(this);
                state = QuestState.DONE;
                stage++;
                return QuestResponse.CLOSE_DIALOGUE;
            //case 1:
            //    if (InventoryManager.instance.RemoveFromInventory(blacksmithHammer))
            //    {
            //        state = QuestState.DONE;
            //        stage++;
            //        return QuestResponse.CONTINUE_DIALOGUE;
            //    }
            //    else
            //        return QuestResponse.CLOSE_DIALOGUE;
            //case 2:
            //    return QuestResponse.CLOSE_DIALOGUE;
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
