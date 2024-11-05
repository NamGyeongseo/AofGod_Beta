using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "Furniture Data", menuName = "Scriptable Object/FurnitureData",order = int.MaxValue)]
public class FurnitureData : ScriptableObject
{
    [SerializeField]
    private string furnitureName;
    public string FurnitureName { get { return furnitureName; } }
    [SerializeField]
    private int workRange;
    public int WorkRange { get { return workRange; } }



}
