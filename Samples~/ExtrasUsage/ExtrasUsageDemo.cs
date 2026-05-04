using UnityEngine;

namespace KarlBanan.EditorLayout.Samples
{
    public sealed class ExtrasUsageDemo : MonoBehaviour
    {
        public enum DemoMode
        {
            Basic,
            Advanced,
            Experimental
        }

        [Header("Primitive Values")]
        public bool toggleValue = true;
        public int intValue = 5;
        public float floatValue = 0.5f;
        public double doubleValue = 10.5;
        public string textValue = "Hello Editor Layout!";
        [TextArea(3, 6)] public string textAreaValue = "This is a multiline text area.";
        public DemoMode enumValue = DemoMode.Basic;

        [Header("Sliders")]
        public int intSliderValue = 25;
        public float floatSliderValue = 0.75f;

        [Header("Colors and Objects")]
        public Color colorValue = new(0.25f, 0.65f, 1f, 1f);
        public Object objectValue;

        [Header("Vectors")]
        public Vector2 vector2Value = new(1f, 2f);
        public Vector2Int vector2IntValue = new(1, 2);
        public Vector3 vector3Value = new(1f, 2f, 3f);
        public Vector3Int vector3IntValue = new(1, 2, 3);

        [Header("Vector Sliders")]
        public Vector2 vector2SliderValue = new(0.25f, 0.75f);
        public Vector2Int vector2IntSliderValue = new(25, 75);
        public Vector3 vector3SliderValue = new(0.25f, 0.5f, 0.75f);
        public Vector3Int vector3IntSliderValue = new(25, 50, 75);

        public void ResetValues()
        {
            toggleValue = true;
            intValue = 5;
            floatValue = 0.5f;
            doubleValue = 10.5d;
            textValue = "Hello Editor Layout!";
            textAreaValue = "This is a multi-line text area.";
            enumValue = DemoMode.Basic;

            intSliderValue = 25;
            floatSliderValue = 0.75f;

            colorValue = new Color(0.25f, 0.65f, 1f, 1f);
            objectValue = null;

            vector2Value = new Vector2(1f, 2f);
            vector2IntValue = new Vector2Int(1, 2);
            vector3Value = new Vector3(1f, 2f, 3f);
            vector3IntValue = new Vector3Int(1, 2, 3);

            vector2SliderValue = new Vector2(0.25f, 0.75f);
            vector2IntSliderValue = new Vector2Int(25, 75);
            vector3SliderValue = new Vector3(0.25f, 0.5f, 0.75f);
            vector3IntSliderValue = new Vector3Int(25, 50, 75);
        }
    }

}