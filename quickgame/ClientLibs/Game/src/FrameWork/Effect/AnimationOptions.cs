//------------------------------------
using UnityEngine;
using xc;

public class AnimationOptions
{
    public string Name = "";//动作的名字
    public float Speed = 1;//动作的播放速度，对于移动动作来说，表示移动的速度，会随着移动属性而变化
    public float OriSpeed = 0;//动作的播放速度，对于移动动作来说，表示移动的速度

    public void Clone(AnimationOptions src)
    {
        Name = src.Name;
        Speed = src.Speed;
        OriSpeed = src.OriSpeed;
    }
}
