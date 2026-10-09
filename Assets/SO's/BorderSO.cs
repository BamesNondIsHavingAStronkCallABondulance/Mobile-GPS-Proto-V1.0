using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BorderSO", menuName = "Scriptable Objects/BorderSO")]
public class BorderSO : ScriptableObject
{
    public List<string> latitudeList = new();
    public List<string> longitudeList = new();
}
