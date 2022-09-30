using DefaultNamespace;
using UnityEditor.U2D.Path;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Player", menuName = "Player parametersz", order = 0)]
public class PlayerParameters : ScriptableObject
{
    [FormerlySerializedAs("_data")]
    [SerializeField]
    private PlayerData _parameters;

    public PlayerData Parameters => _parameters;
}