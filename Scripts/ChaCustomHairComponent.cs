using MagicaCloth;
using System;
using System.IO;
using UnityEngine;

namespace Character
{
    [ExecuteInEditMode]
    public class ChaCustomHairComponent : MonoBehaviour
    {
        [Tooltip("Renderers controlled by the hair color")]
        public Renderer[] rendHair;
        [Tooltip("Renderers controlled by the hair accessory color")]
        public Renderer[] rendAccessory;
        [Tooltip("Required when using Rend Accessory")]
        public Color[] acsDefColor;

        [Serializable]
        public class BoneInfo
        {
            public Transform trfCorrect;
            public MagicaBoneCloth[] magicaBones;
            public Vector3 basePos;
            public Vector3 baseRot;
            public Vector3 posMin;
            public Vector3 posMax;
            public Vector3 rotMin;
            public Vector3 rotMax;
            public Vector3 moveRate;
            public Vector3 rotRate;
        }

        public BoneInfo[] boneInfo;

        [Serializable]
        public class HairOption
        {
            public GameObject bone;
            public GameObject obj;
        }

        public HairOption[] hairOptions;

        public Renderer[] rendLines;


#if UNITY_EDITOR

        private void OnValidate()
        {
            VerifyBoneInfo();
        }
        
        public void VerifyBoneInfo()
        {
            if (boneInfo == null) return;

            foreach (var b in boneInfo)
            {
                if (b == null) continue;

                if (b.posMin == Vector3.zero)
                    b.posMin = new Vector3(0.03f, 0f, 0.03f);
                if (b.posMax == Vector3.zero)
                    b.posMax = new Vector3(-0.03f, -0.06f, -0.03f);
                if (b.rotMin == Vector3.zero)
                    b.rotMin = new Vector3(-30f, -30f, -30f);
                if (b.rotMax == Vector3.zero)
                    b.rotMax = new Vector3(30f, 30f, 30f);
                if (b.moveRate == Vector3.zero)
                    b.moveRate = new Vector3(0.5f, 0f, 0.5f);
                if (b.rotRate == Vector3.zero)
                    b.rotRate = new Vector3(0.5f, 0.5f, 0.5f);
            }
        }

#endif
    }
}