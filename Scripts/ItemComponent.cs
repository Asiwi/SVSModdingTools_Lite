using UnityEngine;
using System;

namespace DigitalCraft
{
    [ExecuteInEditMode]
    public class ItemComponent : MonoBehaviour
    {
        [Serializable]
        public class Info
        {
            [Tooltip("Whether to use this color")]
            public bool useColor = true;
            [Tooltip("Default color")]
            public Color defColor = Color.white;
            [Tooltip("Whether to allow pattern texture usage")]
            public bool usePattern = true;
            [Tooltip("Default color of the pattern")]
            public Color defColorPattern = Color.white;
            [Tooltip("Whether the pattern is clamped (does not tile) by default")]
            public bool defClamp = true;
            [Tooltip("Default values which control pattern position and size.\nX: Horizontal position\nY: Vertical position\nZ: Horizontal scale\nW: Vertical scale")]
            public Vector4 defUV = Vector4.zero;
            [Tooltip("Default pattern rotation")]
            public float defRot;
        }

        [Serializable]
        public class MaterialInfo
        {
            public bool IsUsed = true;
            public bool IsColor1 = true;
            public bool IsColorAlpha1 = false;
            public bool IsPattern1 = true;
            public bool IsColor2 = true;
            public bool IsColorAlpha2 = false;
            public bool IsPattern2 = true;
            public bool IsColor3 = true;
            public bool IsColorAlpha3 = false;
            public bool IsPattern3 = true;
            public bool IsLamp = true;
            public bool IsEmissionColor = false;
            public bool IsEmissionPower = false;
            public bool IsAlpha = false;
            public bool IsGlass = false;
            public bool IsGlassAlpha = true;
            public bool IsLightCancel = true;
            public bool IsLineColor = true;
        }

        [Serializable]
        public class RendererInformation
        {
            public Renderer Renderer;
            public MaterialInfo[] Materials;

        }

        [Serializable]
        public class RendererInfo
        {
            public Renderer renderer;
            public bool[] materials;
            public bool[] emission;
            public bool[] emissionPower;
            public bool[] lightCancel;
        }

        [Serializable]
        public class AnimeInfo
        {
            public string name;
            public string state;
        }

        public RendererInformation[] rendererInfos;

        [Header("Normal Parts")]
        [Tooltip("All renderers of the object")]
        public Renderer[] rendNormal;

        public RendererInfo[] renderersNormal;

        [Header("Transparent Parts")]
        [Tooltip("Renderers affected by the alpha slider")]
        public Renderer[] rendAlpha;

        public RendererInfo[] renderersAlpha;

        [Header("Glass Parts")]
        [Tooltip("Glass renderers which have their own color picker")]
        public Renderer[] rendGlass;
        [Header("Configuration Info")]
        [Tooltip("Array of information about the colors, must contain exactly 3 elements")]
        public Info[] info;
        [Tooltip("Default shadow color")]
        public Color defShadow = Color.white;

        public bool defShadowOn = false;

        [Tooltip("Default value of the alpha slider")]
        public float alpha = 1f;
        [Tooltip("Default color of the glass renderers")]
        public Color defGlass = Color.white;
        [Tooltip("Default line color")]
        public Color defLineColor = new Vector4(0f,0f,0f,1f);
        [Tooltip("Default line width")]
        public float defLineWidth = 1f;
        [Tooltip("Default emission color")]
        public Color defEmissionColor = Color.white;
        [Tooltip("Default emission power")]
        public float defEmissionPower;
        [Tooltip("Default light cancel")]
        public float defLightCancel;

        public Transform ChildRoot;
        public bool IsScale = true;
        public bool IsAnime = false;
        public AnimeInfo[] animeInfos;
        public Transform[] FKBONE;

#if UNITY_EDITOR
        private void Awake()
        {
            VerifyInfo();
            VerifyRendererInfos();
        }

        // having Start() gives Inspector enable/disable checkbox for the script
        // needed because an exception in Awake() will disable the script


        private void OnValidate()
        {
            VerifyInfo();
            VerifyRendererInfos();
        }

        /// <summary>
        /// Verify that the Info array has exactly three elements
        /// </summary>
        public void VerifyInfo()
        {
            if (info == null)
            {
                var newInfo = new Info[3];
                for (int i = 0; i < 3; i++)
                {
                    newInfo[i] = new Info();
                    newInfo[i].useColor = false;
                }

                info = newInfo;
            }
            else if (info.Length != 3)
            {
                var newInfo = new Info[3];

                //Copy existing data, if present
                if (info.Length >= 1)
                    newInfo[0] = info[0];
                if (info.Length >= 2)
                    newInfo[1] = info[1];
                if (info.Length >= 3)
                    newInfo[2] = info[2];

                for (int i = 0; i < 3; i++)
                    if (newInfo[i] == null)
                    {
                        newInfo[i] = new Info();
                        newInfo[i].useColor = false;
                    }

                info = newInfo;
            }
        }
        public void VerifyRendererInfos()
        {
            // 确保rendererInfos数组至少有一个元素
            if (rendererInfos == null || rendererInfos.Length == 0)
            {
                rendererInfos = new RendererInformation[1];
                rendererInfos[0] = new RendererInformation();
            }

            // 使用for循环而不是foreach，这样我们可以修改数组元素
            for (int i = 0; i < rendererInfos.Length; i++)
            {
                if (rendererInfos[i] == null)
                {
                    rendererInfos[i] = new RendererInformation();
                }

                // 设置默认的MaterialInfo数组
                if (rendererInfos[i].Materials == null || rendererInfos[i].Materials.Length == 0)
                {
                    rendererInfos[i].Materials = new MaterialInfo[1];
                    rendererInfos[i].Materials[0] = new MaterialInfo()
                    {
                        IsUsed = true,
                        IsColor1 = true,
                        IsColorAlpha1 = false,
                        IsPattern1 = true,
                        IsColor2 = true,
                        IsColorAlpha2 = false,
                        IsPattern2 = true,
                        IsColor3 = true,
                        IsColorAlpha3 = false,
                        IsPattern3 = true,
                        IsLamp = true,
                        IsEmissionColor = false,
                        IsEmissionPower = false,
                        IsAlpha = false,
                        IsGlass = false,
                        IsGlassAlpha = true,
                        IsLightCancel = true,
                        IsLineColor = true
                    };
                }
            }
        }
#endif

    }
}
