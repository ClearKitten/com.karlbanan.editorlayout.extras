using UnityEditor;
using UnityEngine;

namespace KarlBanan.EditorLayout.Samples
{
    [CustomEditor(typeof(ExtrasUsageDemo))]
    public sealed class ExtrasUsageDemoEditor : Editor
    {
        private ExtrasUsageDemo demo;

        private void OnEnable()
        {
            demo = (ExtrasUsageDemo)target;
        }

        public override void OnInspectorGUI()
        {
            if (demo == null)
            {
                demo = (ExtrasUsageDemo)target;
            }

            DrawHeader();

            EditorGUILayout.Space(8f);

            DrawPrimitiveFields();

            EditorGUILayout.Space(8f);

            DrawSliderFields();

            EditorGUILayout.Space(8f);

            DrawColorAndObjectFields();

            EditorGUILayout.Space(8f);

            DrawVectorFields();

            EditorGUILayout.Space(8f);

            DrawVectorSliderFields();

            EditorGUILayout.Space(12f);

            DrawButtons();
        }

        private new void DrawHeader()
        {
            EditorGUILayout.LabelField("KarlBanan Editor Layout Extras", EditorStyles.boldLabel);
            EditorGUILayout.HelpBox(
                "This sample shows every ready-made field included in the Extras package. " +
                "The component only stores data; the custom editor draws everything using Editor Layout fields.",
                MessageType.Info
            );
        }

        private void DrawPrimitiveFields()
        {
            EditorGUILayout.LabelField("Primitive Fields", EditorStyles.boldLabel);

            EditorDraw.FixedRow(
                LayoutSettings.StretchLastSettings,
                new ToggleField(
                    "Toggle",
                    demo.toggleValue,
                    value => SetValue("Change Toggle", () => demo.toggleValue = value)
                ),
                new EnumField<ExtrasUsageDemo.DemoMode>(
                    "Mode",
                    demo.enumValue,
                    value => SetValue("Change Mode", () => demo.enumValue = value)
                )
            );

            EditorDraw.FixedRow(
                LayoutSettings.StretchLastSettings,
                new IntField(
                    "Int",
                    demo.intValue,
                    value => SetValue("Change Int", () => demo.intValue = value)
                ),
                new FloatField(
                    "Float",
                    demo.floatValue,
                    value => SetValue("Change Float", () => demo.floatValue = value)
                ),
                new DoubleField(
                    "Double",
                    demo.doubleValue,
                    value => SetValue("Change Double", () => demo.doubleValue = value)
                )
            );

            EditorDraw.FixedRow(
                LayoutSettings.StretchLastSettings,
                new TextField(
                    "Text",
                    demo.textValue,
                    value => SetValue("Change Text", () => demo.textValue = value)
                )
            );

            EditorDraw.FixedRow(
                new LayoutSettings(
                    spacing: 4f,
                    paddingLeft: 0f,
                    paddingRight: 0f,
                    paddingTop: 0f,
                    paddingBottom: 0f,
                    stretchLast: true,
                    height: 72f
                ),
                new TextAreaField(
                    "Text Area",
                    demo.textAreaValue,
                    value => SetValue("Change Text Area", () => demo.textAreaValue = value),
                    elementLayout: new ElementLayout(220f, 420f, 72f, 72f, true, false)
                )
            );
        }

        private void DrawSliderFields()
        {
            EditorGUILayout.LabelField("Slider Fields", EditorStyles.boldLabel);

            EditorDraw.FixedRow(
                LayoutSettings.StretchLastSettings,
                new IntSliderField(
                    "Int Slider",
                    demo.intSliderValue,
                    0,
                    100,
                    value => SetValue("Change Int Slider", () => demo.intSliderValue = value)
                ),
                new FloatSliderField(
                    "Float Slider",
                    demo.floatSliderValue,
                    0f,
                    1f,
                    value => SetValue("Change Float Slider", () => demo.floatSliderValue = value)
                )
            );
        }

        private void DrawColorAndObjectFields()
        {
            EditorGUILayout.LabelField("Color and Object Fields", EditorStyles.boldLabel);

            EditorDraw.FixedRow(
                LayoutSettings.StretchLastSettings,
                new ColorField(
                    "Color",
                    demo.colorValue,
                    showEyedropper: true,
                    showAlpha: true,
                    setValue: value => SetValue("Change Color", () => demo.colorValue = value)
                ),
                new ObjectField(
                    "Object",
                    demo.objectValue,
                    allowSceneObjects: true,
                    setValue: value => SetValue("Change Object", () => demo.objectValue = value),
                    type: typeof(Object)
                )
            );
        }

        private void DrawVectorFields()
        {
            EditorGUILayout.LabelField("Vector Fields", EditorStyles.boldLabel);

            EditorDraw.FixedRow(
                LayoutSettings.StretchLastSettings,
                new Vector2Field(
                    "Vector2",
                    demo.vector2Value,
                    value => SetValue("Change Vector2", () => demo.vector2Value = value)
                ),
                new Vector2IntField(
                    "Vector2Int",
                    demo.vector2IntValue,
                    value => SetValue("Change Vector2Int", () => demo.vector2IntValue = value)
                )
            );

            EditorDraw.FixedRow(
                LayoutSettings.StretchLastSettings,
                new Vector3Field(
                    "Vector3",
                    demo.vector3Value,
                    value => SetValue("Change Vector3", () => demo.vector3Value = value)
                ),
                new Vector3IntField(
                    "Vector3Int",
                    demo.vector3IntValue,
                    value => SetValue("Change Vector3Int", () => demo.vector3IntValue = value)
                )
            );
        }

        private void DrawVectorSliderFields()
        {
            EditorGUILayout.LabelField("Vector Slider Fields", EditorStyles.boldLabel);

            EditorGUILayout.LabelField("Horizontal", EditorStyles.miniBoldLabel);

            EditorDraw.EvenRow(
                LayoutSettings.StretchLastSettings,
                new Vector3SliderField(
                    "Vector3 Slider",
                    demo.vector3SliderValue,
                    0f,
                    1f,
                    value => SetValue("Change Vector3 Slider", () => demo.vector3SliderValue = value)
                )
            );

            EditorDraw.EvenRow(
                LayoutSettings.StretchLastSettings,
                new Vector3IntSliderField(
                    "Vector3Int Slider",
                    demo.vector3IntSliderValue,
                    0,
                    100,
                    value => SetValue("Change Vector3Int Slider", () => demo.vector3IntSliderValue = value)
                )
            );

            EditorDraw.EvenRow(
                LayoutSettings.StretchLastSettings,
                new Vector2SliderField(
                    "Vector2 Slider",
                    demo.vector2SliderValue,
                    0f,
                    1f,
                    value => SetValue("Change Vector2 Slider", () => demo.vector2SliderValue = value)
                )
            );

            EditorDraw.EvenRow(
                LayoutSettings.StretchLastSettings,
                new Vector2IntSliderField(
                    "Vector2Int Slider",
                    demo.vector2IntSliderValue,
                    0,
                    100,
                    value => SetValue("Change Vector2Int Slider", () => demo.vector2IntSliderValue = value)
                )
            );


            EditorGUILayout.Space(4f);
            EditorGUILayout.LabelField("Vertical", EditorStyles.miniBoldLabel);

            EditorDraw.EvenRow(
                new LayoutSettings(
                    spacing: 8f,
                    paddingLeft: 0f,
                    paddingRight: 0f,
                    paddingTop: 0f,
                    paddingBottom: 0f,
                    stretchLast: true,
                    height: 78f
                ),
                new Vector3SliderField(
                    "Vector3 Vertical",
                    demo.vector3SliderValue,
                    0f,
                    1f,
                    value => SetValue("Change Vector3 Vertical Slider", () => demo.vector3SliderValue = value),
                    sliderLayout: VectorSliderLayout.Vertical,
                    elementLayout: new ElementLayout(220f, 320f, 78f, 78f, true, false)
                ),
                new Vector3IntSliderField(
                    "Vector3Int Vertical",
                    demo.vector3IntSliderValue,
                    0,
                    100,
                    value => SetValue("Change Vector3Int Vertical Slider", () => demo.vector3IntSliderValue = value),
                    sliderLayout: VectorSliderLayout.Vertical,
                    elementLayout: new ElementLayout(220f, 320f, 78f, 78f, true, false)
                )
            );
        }

        private void DrawButtons()
        {
            EditorGUILayout.LabelField("Buttons", EditorStyles.boldLabel);

            EditorDraw.FixedRow(
                LayoutSettings.StretchLastSettings,
                new InspectorButton(
                    "Randomize Values",
                    () => SetValue("Randomize Values", RandomizeValues),
                    elementLayout: new ElementLayout(120f, 160f, 24f, 24f, true, false)
                ),
                new InspectorButton(
                    "Reset Values",
                    () => SetValue("Reset Values", demo.ResetValues),
                    elementLayout: new ElementLayout(120f, 160f, 24f, 24f, true, false)
                )
            );
        }

        private void SetValue(string undoName, System.Action applyValue)
        {
            Undo.RecordObject(demo, undoName);
            applyValue?.Invoke();
            EditorUtility.SetDirty(demo);
        }

        private void RandomizeValues()
        {
            demo.toggleValue = Random.value > 0.5f;
            demo.intValue = Random.Range(0, 100);
            demo.floatValue = Random.Range(0f, 1f);
            demo.doubleValue = Random.Range(0.0f, 100.0f);
            demo.textValue = $"Random {Random.Range(0, 999)}";
            demo.textAreaValue = $"Generated text\nValue: {Random.Range(0, 999)}";
            demo.enumValue = (ExtrasUsageDemo.DemoMode)Random.Range(0, 3);

            demo.intSliderValue = Random.Range(0, 101);
            demo.floatSliderValue = Random.Range(0f, 1f);

            demo.colorValue = Random.ColorHSV();
            demo.objectValue = null;

            demo.vector2Value = Random.insideUnitCircle * 10f;
            demo.vector2IntValue = new Vector2Int(Random.Range(0, 10), Random.Range(0, 10));
            demo.vector3Value = Random.insideUnitSphere * 10f;
            demo.vector3IntValue = new Vector3Int(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));

            demo.vector2SliderValue = new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f));
            demo.vector2IntSliderValue = new Vector2Int(Random.Range(0, 101), Random.Range(0, 101));
            demo.vector3SliderValue = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            demo.vector3IntSliderValue = new Vector3Int(Random.Range(0, 101), Random.Range(0, 101), Random.Range(0, 101));
        }
    }
}