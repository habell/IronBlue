using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestItemConfig", menuName = "Quest system/Quest Item Config")]
public class QuestItemConfig : ScriptableObject
{
    [SerializeField]
    private int _questID;

    [SerializeField]
    private List<int> _questItemIDCollection;

    public List<int> QuestItemIDCollection => _questItemIDCollection;

    public int QuestID => _questID;
}