using System;
using UnityEditor;
using UnityEngine;

namespace KarlBanan.EditorLayout
{
    /// <summary>
    /// Draws a <see cref="Vector3Int"/> field where each component is edited with an integer slider.
    /// </summary>
    public class Vector3IntSliderField : VectorSliderField<Vector3Int>
    {
        private readonly Vector3Int minValue;
        private readonly Vector3Int maxValue;


        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3IntSliderField"/> class.
        /// </summary>
        /// <param name="content">The content used as the field label.</param>
        /// <param name="value">The current field value.</param>
        /// <param name="minValue">The minimum slider value for each component.</param>
        /// <param name="maxValue">The maximum slider value for each component.</param>
        /// <param name="setValue">The callback used to assign the changed value.</param>
        /// <param name="sliderLayout">The layout direction used for the component sliders.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public Vector3IntSliderField(
            GUIContent content,
            Vector3Int value,
            int minValue,
            int maxValue,
            Action<Vector3Int> setValue,
            VectorSliderLayout sliderLayout = VectorSliderLayout.Horizontal,
            float spacing = 4f,
            Func<bool> canDisplay = null,
            ElementLayout? elementLayout = null,
            LabelSettings? labelSettings = null)
            : base(content, value, setValue, new[] { "X", "Y", "Z" }, sliderLayout, spacing, canDisplay, elementLayout, labelSettings)
        {
            this.minValue = new Vector3Int(minValue, minValue, minValue);
            this.maxValue = new Vector3Int(maxValue, maxValue, maxValue);
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3IntSliderField"/> class using a text label.
        /// </summary>
        /// <param name="label">The text used as the field label.</param>
        /// <param name="value">The current field value.</param>
        /// <param name="minValue">The minimum slider value for each component.</param>
        /// <param name="maxValue">The maximum slider value for each component.</param>
        /// <param name="setValue">The callback used to assign the changed value.</param>
        /// <param name="sliderLayout">The layout direction used for the component sliders.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public Vector3IntSliderField(
            string label,
            Vector3Int value,
            int minValue,
            int maxValue,
            Action<Vector3Int> setValue,
            VectorSliderLayout sliderLayout = VectorSliderLayout.Horizontal,
            float spacing = 4f,
            Func<bool> canDisplay = null,
            ElementLayout? elementLayout = null,
            LabelSettings? labelSettings = null)
            : base(new GUIContent(label), value, setValue, new[] { "X", "Y", "Z" }, sliderLayout, spacing, canDisplay, elementLayout, labelSettings)
        {
            this.minValue = new Vector3Int(minValue, minValue, minValue);
            this.maxValue = new Vector3Int(maxValue, maxValue, maxValue);
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3IntSliderField"/> class.
        /// </summary>
        /// <param name="content">The content used as the field label.</param>
        /// <param name="value">The current field value.</param>
        /// <param name="minValue">The minimum slider value for each component.</param>
        /// <param name="maxValue">The maximum slider value for each component.</param>
        /// <param name="setValue">The callback used to assign the changed value.</param>
        /// <param name="sliderLayout">The layout direction used for the component sliders.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public Vector3IntSliderField(
            GUIContent content,
            Vector3Int value,
            Vector3Int minValue,
            Vector3Int maxValue,
            Action<Vector3Int> setValue,
            VectorSliderLayout sliderLayout = VectorSliderLayout.Horizontal,
            float spacing = 4f,
            Func<bool> canDisplay = null,
            ElementLayout? elementLayout = null,
            LabelSettings? labelSettings = null)
            : base(content, value, setValue, new[] { "X", "Y", "Z" }, sliderLayout, spacing, canDisplay, elementLayout, labelSettings)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3IntSliderField"/> class.
        /// </summary>
        /// <param name="label">The text used as the field label.</param>
        /// <param name="value">The current field value.</param>
        /// <param name="minValue">The minimum slider value for each component.</param>
        /// <param name="maxValue">The maximum slider value for each component.</param>
        /// <param name="setValue">The callback used to assign the changed value.</param>
        /// <param name="sliderLayout">The layout direction used for the component sliders.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public Vector3IntSliderField(
            string label,
            Vector3Int value,
            Vector3Int minValue,
            Vector3Int maxValue,
            Action<Vector3Int> setValue,
            VectorSliderLayout sliderLayout = VectorSliderLayout.Horizontal,
            float spacing = 4f,
            Func<bool> canDisplay = null,
            ElementLayout? elementLayout = null,
            LabelSettings? labelSettings = null)
            : base(new GUIContent(label), value, setValue, new[] { "X", "Y", "Z" }, sliderLayout, spacing, canDisplay, elementLayout, labelSettings)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }


        /// <inheritdoc/>
        protected override Vector3Int DrawComponentSlider(Rect sliderRect, Vector3Int currentValue, int index)
        {
            switch (index)
            {
                case 0:
                    currentValue.x = EditorGUI.IntSlider(sliderRect, GUIContent.none, currentValue.x, minValue.x, maxValue.x);
                    break;
                case 1:
                    currentValue.y = EditorGUI.IntSlider(sliderRect, GUIContent.none, currentValue.y, minValue.y, maxValue.y);
                    break;
                case 2:
                    currentValue.z = EditorGUI.IntSlider(sliderRect, GUIContent.none, currentValue.z, minValue.z, maxValue.z);
                    break;
            }
            return currentValue;
        }
    }
}