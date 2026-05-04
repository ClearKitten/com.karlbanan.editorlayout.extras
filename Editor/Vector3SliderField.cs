using System;
using UnityEditor;
using UnityEngine;

namespace KarlBanan.EditorLayout
{
    /// <summary>
    /// Draws a <see cref="Vector3"/> field where each component is edited with a slider.
    /// </summary>
    public class Vector3SliderField : VectorSliderField<Vector3>
    {
        private readonly float minValue;
        private readonly float maxValue;


        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3SliderField"/> class.
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
        public Vector3SliderField(
            GUIContent content,
            Vector3 value,
            float minValue,
            float maxValue,
            Action<Vector3> setValue,
            VectorSliderLayout sliderLayout = VectorSliderLayout.Horizontal,
            Func<bool> canDisplay = null,
            ElementLayout? elementLayout = null,
            LabelSettings? labelSettings = null)
            : base(content, value, setValue, new[] { "X", "Y", "Z" }, sliderLayout, canDisplay, elementLayout, labelSettings)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3SliderField"/> class using a text label.
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
        public Vector3SliderField(
            string label,
            Vector3 value,
            float minValue,
            float maxValue,
            Action<Vector3> setValue,
            VectorSliderLayout sliderLayout = VectorSliderLayout.Horizontal,
            Func<bool> canDisplay = null,
            ElementLayout? elementLayout = null,
            LabelSettings? labelSettings = null)
            : base(new GUIContent(label), value, setValue, new[] { "X", "Y", "Z" }, sliderLayout, canDisplay, elementLayout, labelSettings)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }


        /// <inheritdoc/>
        protected override Vector3 DrawComponentSlider(Rect sliderRect, Vector3 currentValue, int index)
        {
            switch (index)
            {
                case 0:
                    currentValue.x = EditorGUI.Slider(sliderRect, GUIContent.none, currentValue.x, minValue, maxValue);
                    break;
                case 1:
                    currentValue.y = EditorGUI.Slider(sliderRect, GUIContent.none, currentValue.y, minValue, maxValue);
                    break;
                case 2:
                    currentValue.z = EditorGUI.Slider(sliderRect, GUIContent.none, currentValue.z, minValue, maxValue);
                    break;
            }
            return currentValue;
        }
    }
}