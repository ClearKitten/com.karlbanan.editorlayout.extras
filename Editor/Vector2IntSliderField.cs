using System;
using UnityEditor;
using UnityEngine;

namespace KarlBanan.EditorLayout
{
    /// <summary>
    /// Draws a <see cref="Vector2Int"/> field where each component is edited with an integer slider.
    /// </summary>
    public class Vector2IntSliderField : VectorSliderField<Vector2Int>
    {
        private readonly Vector2Int minValue;
        private readonly Vector2Int maxValue;


        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2IntSliderField"/> class.
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
        public Vector2IntSliderField(
            GUIContent content,
            Vector2Int value,
            int minValue,
            int maxValue,
            Action<Vector2Int> setValue,
            VectorSliderLayout sliderLayout = VectorSliderLayout.Horizontal,
            float spacing = 4f,
            Func<bool> canDisplay = null,
            ElementLayout? elementLayout = null,
            LabelSettings? labelSettings = null)
            : base(content, value, setValue, new[] { "X", "Y" }, sliderLayout, spacing, canDisplay, elementLayout, labelSettings)
        {
            this.minValue = new Vector2Int(minValue, minValue);
            this.maxValue = new Vector2Int(maxValue, maxValue);
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2IntSliderField"/> class using a text label.
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
        public Vector2IntSliderField(
            string label,
            Vector2Int value,
            int minValue,
            int maxValue,
            Action<Vector2Int> setValue,
            VectorSliderLayout sliderLayout = VectorSliderLayout.Horizontal,
            float spacing = 4f,
            Func<bool> canDisplay = null,
            ElementLayout? elementLayout = null,
            LabelSettings? labelSettings = null)
            : base(new GUIContent(label), value, setValue, new[] { "X", "Y" }, sliderLayout, spacing, canDisplay, elementLayout, labelSettings)
        {
            this.minValue = new Vector2Int(minValue, minValue);
            this.maxValue = new Vector2Int(maxValue, maxValue);
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2IntSliderField"/> class using a text label.
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
        public Vector2IntSliderField(
            GUIContent content,
            Vector2Int value,
            Vector2Int minValue,
            Vector2Int maxValue,
            Action<Vector2Int> setValue,
            VectorSliderLayout sliderLayout = VectorSliderLayout.Horizontal,
            float spacing = 4f,
            Func<bool> canDisplay = null,
            ElementLayout? elementLayout = null,
            LabelSettings? labelSettings = null)
            : base(content, value, setValue, new[] { "X", "Y" }, sliderLayout, spacing, canDisplay, elementLayout, labelSettings)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2IntSliderField"/> class using a text label.
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
        public Vector2IntSliderField(
            string label,
            Vector2Int value,
            Vector2Int minValue,
            Vector2Int maxValue,
            Action<Vector2Int> setValue,
            VectorSliderLayout sliderLayout = VectorSliderLayout.Horizontal,
            float spacing = 4f,
            Func<bool> canDisplay = null,
            ElementLayout? elementLayout = null,
            LabelSettings? labelSettings = null)
            : base(new GUIContent(label), value, setValue, new[] { "X", "Y" }, sliderLayout, spacing, canDisplay, elementLayout, labelSettings)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }


        /// <inheritdoc/>
        protected override Vector2Int DrawComponentSlider(Rect sliderRect, Vector2Int currentValue, int index)
        {
            switch (index)
            {
                case 0:
                    currentValue.x = EditorGUI.IntSlider(sliderRect, GUIContent.none, currentValue.x, minValue.x, maxValue.x);
                    break;
                case 1:
                    currentValue.y = EditorGUI.IntSlider(sliderRect, GUIContent.none, currentValue.y, minValue.y, maxValue.y);
                    break;
            }
            return currentValue;
        }
    }
}