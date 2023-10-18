using System;
using UnityEngine;

[Serializable]
public class Item
{
    public enum Type
    {
        Key,
    }

    public Type type;
    public Sprite sprite;
}
