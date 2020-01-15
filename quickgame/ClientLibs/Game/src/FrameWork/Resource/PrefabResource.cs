//************************************
//  PrefabReource.cs
//  The PrefabResource is the encapsulation of an request prefab resource, it contains the prefab.
//  Created by leon @INCEPTION .
//  Last modify 14-12-19 : refactor
//************************************

using UnityEngine;
using System.Collections;
using xc;

namespace SGameEngine
{
    //  The PrefabResource is the encapsulation of an request prefab resource, it contains the prefab.
    // you need not care about the release, because resouceloder will find the destroyed gameobject and release all ref count this gameobject holds.
    public class PrefabResource
    {
        public UnityEngine.GameObject obj_;
    }
}
