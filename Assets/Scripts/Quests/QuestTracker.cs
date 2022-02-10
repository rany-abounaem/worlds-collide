using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestTracker : MonoBehaviour
{
    public static QuestTracker instance;

    public List<Quest> quests;
    public UnityEvent questsUpdated;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

    }

    public void StartQuest(Quest quest)
    {
        quests.Add(quest);
        questsUpdated.Invoke();
    }

    //public void CompleteQuest(int id)
    //{
    //    if (quests[id])
    //    {
    //        Quest quest = quests[id];
    //        quest.state = QuestState.DONE;
    //        quests.RemoveAt(id);
    //        questsUpdated.Invoke();
    //    }  

    //}
}
