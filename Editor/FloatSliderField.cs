using System;
using UnityEditor;
using UnityEngine;

namespace KarlBanan.EditorLayout
{
    /// <summary>
    /// Draws a <see cref="float"/> slider field as an inspector element.
    /// </summary>
    public class FloatSliderField : InspectorField<float>
    {
        private readonly float minValue;
        private readonly float maxValue;


        /// <summary>
        /// Initializes a new instance of the <see cref="FloatSliderField"/> class.
        /// </summary>
        /// <param name="content">The content used as the field label.</param>
        /// <param name="value">The current field value.</param>
        /// <param name="minValue">The minimum slider value.</param>
        /// <param name="maxValue">The maximum slider value.</param>
        /// <param name="setValue">The callback used to assign the changed value.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public FloatSliderField(
            GUIContent content, 
            float value, 
            float minValue,
            float maxValue,
            Action<float> setValue, 
            Func<bool> canDisplay = null, 
            ElementLayout? elementLayout = null, 
            LabelSettings? labelSettings = null) 
            : base(content, value, setValue, canDisplay, elementLayout, labelSettings) 
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="FloatSliderField"/> class using a text label.
        /// </summary>
        /// <param name="label">The text used as the field label.</param>
        /// <param name="value">The current field value.</param>
        /// <param name="minValue">The minimum slider value.</param>
        /// <param name="maxValue">The maximum slider value.</param>
        /// <param name="setValue">The callback used to assign the changed value.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public FloatSliderField(
            string label, 
            float value, 
            float minValue,
            float maxValue,
            Action<float> setValue, 
            Func<bool> canDisplay = null, 
            ElementLayout? elementLayout = null, 
            LabelSettings? labelSettings = null) 
            : this(new GUIContent(label), value, minValue, maxValue, setValue, canDisplay, elementLayout, labelSettings)
        {
        }


        /// <inheritdoc/>
        protected override float DrawField(Rect rect, GUIContent content, float currentValue)
        {
            return EditorGUI.Slider(rect, content, currentValue, minValue, maxValue);
        }
    }
}