using UnityEngine;

[CreateAssetMenu]
public class Order : ScriptableObject
{
    public string nameOrder;
    public string description;
    public int price;
    public float time;
    public WayPosition orderWay;
}