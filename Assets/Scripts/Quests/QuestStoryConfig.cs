using UnityEngine;

[CreateAssetMenu(fileName = "QuestStoryConfig", menuName = "Quest system/Story Configuration")]
public class QuestStoryConfig : ScriptableObject
{
    [SerializeField]
    private QuestConfig[] _quests;

    [SerializeField]
    private QuestStoryType _storyType;

    public QuestConfig[] Quests => _quests;

    public QuestStoryType StoryType => _storyType;
}

public enum QuestStoryType
{
    Common,
    Reusable,
}