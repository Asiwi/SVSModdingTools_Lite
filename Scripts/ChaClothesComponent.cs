using UnityEngine;
using System;
using MagicaCloth;


namespace Character
{
    [ExecuteInEditMode]
    public class ChaClothesComponent : MonoBehaviour
    {
        [Header("Normal Parts")]
        [Tooltip("Renderers affected by the first set of MainTex and ColorMask textures configured in the list file")]
        public Renderer[] rendNormal01;
        [Tooltip("Renderers affected by the second set of MainTex and ColorMask textures configured in the list file")]
        public Renderer[] rendNormal02;
        [Tooltip("Renderers affected by the second set of MainTex and ColorMask textures configured in the list file")]
        public Renderer[] rendNormal03;

        [Tooltip("Whether to show the first color picker")]
        public bool useColorN01 = true;
        [Tooltip("Whether to show the second color picker")]
        public bool useColorN02 = false;
        [Tooltip("Whether to show the third color picker")]
        public bool useColorN03 = false;
        [Tooltip("Whether to show the fourth color picker")]
        public bool useColorN04 = false;

   
        public bool useColorA01 = false;

        public bool useColorA02 = false;

        public bool useColorA03 = false;

        public bool useColorA04 = false;

        [Header("Decorative Part (Uniform)")]
        [Tooltip("Decoration parts used on the jacket or sailor uniform types")]
        public Renderer rendAccessory;

        [Header("Emblem Parts")]
        [Tooltip("Renderer which uses the first emblem")]
        public Renderer rendEmblem01;

        public Renderer[] exRendEmblem01;

        [Header("Emblem Parts 2")]
        [Tooltip("Renderer which uses the second emblem")]
        public Renderer rendEmblem02;

        public Renderer[] exRendEmblem02;

        [Header("Default Colors")]
        [Tooltip("Default value for the first color")]
        public Color defMainColor01 = Color.white;
        [Tooltip("Default value for the second color")]
        public Color defMainColor02 = Color.white;
        [Tooltip("Default value for the third color")]
        public Color defMainColor03 = Color.white;
        [Tooltip("Default value for the third color")]
        public Color defMainColor04 = Color.white;

        [Header("Default Color (Decorative Part)")]
        [Tooltip("Default value for the decoration color")]
        public Color defAccessoryColor = Color.white;

        [Header("Optional Parts")]
        [Tooltip("Renderers which can be toggled off by the first option checkbox")]
        public GameObject[] objOpt01;
        [Tooltip("Renderers which can be toggled off by the second option checkbox")]
        public GameObject[] objOpt02;

        public GameObject[] objSleeves01;
        public GameObject[] objSleeves02;
        public GameObject[] objSleeves03;

        [Serializable]
        public class Pattern
        {
            public int _id = -1;
            public Color _color = Color.white;
            public Vector2 _tiling = new Vector2(0.5f, 0.5f);
            public Vector2 _offset = new Vector2(0.5f, 0.5f);
            public float _rotate = 0.5f;
        }
        public Pattern pattern01 = new Pattern { _id = 0};
        public Pattern pattern02 = new Pattern();
        public Pattern pattern03 = new Pattern();
        public Pattern pattern04 = new Pattern();

        [Serializable]
        public class Paint
        {
            public int _id = 0;
            public Color _color = Color.white;
            public Vector4 _initLayout = Vector4.zero;
            public Vector3 _center = Vector3.zero;
            public Vector3 _move = Vector3.zero;
        }
        public Paint paint01 = new Paint();
        public Paint paint02 = new Paint();
        public Paint paint03 = new Paint();

        public MagicaBoneCloth[] _magicaBones;

    }

}
