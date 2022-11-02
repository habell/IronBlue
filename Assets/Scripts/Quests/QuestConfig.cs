using UnityEngine;

[CreateAssetMenu(fileName = "QuestConfig", menuName = "Quest system/Quest Config")]
public class QuestConfig : ScriptableObject
{
    [SerializeField]
    private int _questID;
    
    [SerializeField]
    private QuestType _questType;

    public int QuestID => _questID;

    public QuestType Type => _questType;
}

public enum QuestType
{
    Switch
}