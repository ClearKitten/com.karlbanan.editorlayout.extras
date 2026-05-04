using System;
using UnityEditor;
using UnityEngine;

namespace KarlBanan.EditorLayout
{
    /// <summary>
    /// Draws a <see cref="double"/> field as an inspector element.
    /// </summary>
    public class DoubleField : InspectorField<double>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleField"/> class.
        /// </summary>
        /// <param name="content">The content used as the field label.</param>
        /// <param name="value">The current field value.</param>
        /// <param name="setValue">The callback used to assign the changed value.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public DoubleField(
            GUIContent content,
            double value,
            Action<double> setValue,
            Func<bool> canDisplay = null,
            ElementLayout? elementLayout = null,
            LabelSettings? labelSettings = null)
            : base(content, value, setValue, canDisplay, elementLayout, labelSettings)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleField"/> class using a text label.
        /// </summary>
        /// <param name="label">The text used as the field label.</param>
        /// <param name="value">The current field value.</param>
        /// <param name="setValue">The callback used to assign the changed value.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public DoubleField(
           string label,
           double value,
           Action<double> setValue,
           Func<bool> canDisplay = null,
           ElementLayout? elementLayout = null,
           LabelSettings? labelSettings = null)
           : base(label, value, setValue, canDisplay, elementLayout, labelSettings)
        {
        }


        /// <inheritdoc/>
        protected override double DrawField(Rect rect, GUIContent content, double currentValue)
        {
            return EditorGUI.DoubleField(rect, content, currentValue);
        }
    }
}