using System;
using UnityEngine;
using XNode;

[Serializable]
public struct Connection {}
public class DialogSegment : Node
{
    public Sprite portrait;

    [Input]
    public Connection input;

     [Output]

    public Connection output;

    public override object GetValue(NodePort port)
    {
        return null;
    }
}
