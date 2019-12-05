using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace xc
{
    public class IconInfo
    {
        public string MainTexturePath = "";
        public Rect IconRect = new Rect();
    }
    public class WXIconAsset
    {
        public Dictionary<uint, Rect> IconList = new Dictionary<uint, Rect> ();
        public Dictionary<string, List<uint>> MainTexIconList = new Dictionary<string, List<uint>> ();
        public Material material;
        public Shader shader;
    }
}



