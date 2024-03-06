using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName ="Item", menuName = "Asset/MyAsset")]
public class Assistance : ScriptableObject
{
    [SerializeField] private int power;
    public int Power => power;

}
