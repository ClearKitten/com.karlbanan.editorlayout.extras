using System;
using UnityEditor;
using UnityEngine;

namespace KarlBanan.EditorLayout
{
    /// <summary>
    /// Draws a <see cref="Vector2"/> field where each component is edited with a slider.
    /// </summary>
    public class Vector2SliderField : VectorSliderField<Vector2>
    {
        private readonly Vector2 minValue;
        private readonly Vector2 maxValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2SliderField"/> class.
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
        public Vector2SliderField(
            GUIContent content,
            Vector2 value,
            float minValue,
            float maxValue,
            Action<Vector2> setValue,
            VectorSliderLayout sliderLayout = VectorSliderLayout.Horizontal,
            float spacing = 4f,
            Func<bool> canDisplay = null,
            ElementLayout? elementLayout = null,
            LabelSettings? labelSettings = null)
            : base(content, value, setValue, new[] {"X", "Y"}, sliderLayout, spacing, canDisplay, elementLayout, labelSettings)
        {
            this.minValue = new Vector2(minValue, minValue);
            this.maxValue = new Vector2(maxValue, maxValue);
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2SliderField"/> class using a text label.
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
        public Vector2SliderField(
            string label,
            Vector2 value,
            float minValue,
            float maxValue,
            Action<Vector2> setValue,
            VectorSliderLayout sliderLayout = VectorSliderLayout.Horizontal,
            float spacing = 4f,
            Func<bool> canDisplay = null,
            ElementLayout? elementLayout = null,
            LabelSettings? labelSettings = null)
            : base(new GUIContent(label), value, setValue, new[] { "X", "Y" }, sliderLayout, spacing, canDisplay, elementLayout, labelSettings)
        {
            this.minValue = new Vector2(minValue, minValue);
            this.maxValue = new Vector2(maxValue, maxValue);
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2SliderField"/> class using a text label.
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
        public Vector2SliderField(
            GUIContent content,
            Vector2 value, 
            Vector2 minValue,
            Vector2 maxValue,
            Action<Vector2> setValue,
            VectorSliderLayout sliderLayout = VectorSliderLayout.Horizontal,
            float spacing = 4f,
            Func<bool> canDisplay = null,
            ElementLayout? elementLayout = null,
            LabelSettings? labelSettings = null)
            : base(content, value, setValue, new[] { "X", "Y"}, sliderLayout, spacing, canDisplay, elementLayout, labelSettings)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2SliderField"/> class using a text label.
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
        public Vector2SliderField(
            string label,
            Vector2 value,
            Vector2 minValue,
            Vector2 maxValue,
            Action<Vector2> setValue,
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
        protected override Vector2 DrawComponentSlider(Rect sliderRect, Vector2 currentValue, int index)
        {
            switch (index)
            {
                case 0:
                    currentValue.x = EditorGUI.Slider(sliderRect, GUIContent.none, currentValue.x, minValue.x, maxValue.x);
                    break;
                case 1:
                    currentValue.y = EditorGUI.Slider(sliderRect, GUIContent.none, currentValue.y, minValue.y, maxValue.y);
                    break;
            }
            return currentValue;
        }
    }
}