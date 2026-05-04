using System;
using UnityEditor;
using UnityEngine;

namespace KarlBanan.EditorLayout
{
    /// <summary>
    /// Draws a <see cref="float"/> field as an inspector element.
    /// </summary>
    public class FloatField : InspectorField<float>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FloatField"/> class.
        /// </summary>
        /// <param name="content">The content used as the field label.</param>
        /// <param name="value">The current field value.</param>
        /// <param name="setValue">The callback used to assign the changed value.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public FloatField(
            GUIContent content, 
            float value, 
            Action<float> setValue, 
            Func<bool> canDisplay = null,
            ElementLayout? elementLayout = null, 
            LabelSettings? labelSettings = null)
            : base(content, value, setValue, canDisplay, elementLayout, labelSettings) 
        { 
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="FloatField"/> class using a text label.
        /// </summary>
        /// <param name="label">The text used as the field label.</param>
        /// <param name="value">The current field value.</param>
        /// <param name="setValue">The callback used to assign the changed value.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public FloatField(
            string label,
            float value,
            Action<float> setValue,
            Func<bool> canDisplay = null,
            ElementLayout? elementLayout = null,
            LabelSettings? labelSettings = null)
            : base(new GUIContent(label), value, setValue, canDisplay, elementLayout, labelSettings)
        {
        }


        /// <inheritdoc/>
        protected override float DrawField(Rect rect, GUIContent content, float currentValue)
        {
            return EditorGUI.FloatField(rect, content, currentValue);
        }
    }
}