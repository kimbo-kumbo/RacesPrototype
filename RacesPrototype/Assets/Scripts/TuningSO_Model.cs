using UnityEngine;


[CreateAssetMenu(fileName = "Tunning", menuName = "New Tuning", order = 51)]
public class TuningSO_Model : ScriptableObject
{
    //[SerializeField, Range(0, 20)] private float speedMove;
    [SerializeField, Range(200, 500)] private float _damperAvto;
    [SerializeField, Range(5f, 60f)] private int _maxSteerAngle;

    public int MaxSteerAngle { get { return _maxSteerAngle; } set { _maxSteerAngle = value; } }
    public float DamperAvto { get { return _damperAvto; } set { _damperAvto = value; } }
}