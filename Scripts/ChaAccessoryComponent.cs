using UnityEngine;
namespace Character
{
    [ExecuteInEditMode]
    public class ChaAccessoryComponent : MonoBehaviour
    {
        [Header("Normal Parts")]
        [Tooltip("Renderers affected by the main three color pickers")]
        public Renderer[] rendNormal;
        [Tooltip("Whether to show the first color picker")]
        public bool useColor01 = true;
        [Tooltip("Default color")]
        public Color defColor01 = Color.white;
        [Tooltip("Whether to show the second color picker")]
        public bool useColor02;
        [Tooltip("Default color")]
        public Color defColor02 = Color.white;
        [Tooltip("Whether to show the third color picker")]
        public bool useColor03;
        [Tooltip("Default color")]
        public Color defColor03 = Color.white;

        public ChaClothesComponent.Pattern pattern01 = new ChaClothesComponent.Pattern { _id = 0};
        public ChaClothesComponent.Pattern pattern02 = new ChaClothesComponent.Pattern();
        public ChaClothesComponent.Pattern pattern03 = new ChaClothesComponent.Pattern();

        [Header("Transparent Parts")]
        [Tooltip("Renderers affected by the fourth color picker which allows for transparency")]
        public Renderer[] rendAlpha;

        [Tooltip("Default color of the transparent parts")]
        public Color defColor04 = Color.white;

        [Header("Hair Parts")]
        [Tooltip("Renderers which will automatically match the primary hair color")]
        public Renderer[] rendHair;
     
        [HideInInspector]
        public bool noOutline;

        public Transform[] FKBone;

        public float FKSize = 1;

    }
}