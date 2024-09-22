using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DouduckLib.MipmapMaker {
    [CreateAssetMenu]
    public class MipmapMaker : ScriptableObject {
        public List<Texture2D> sources;
    }
}