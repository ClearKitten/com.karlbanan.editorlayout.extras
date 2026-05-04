using System;
using UnityEditor;
using UnityEngine;

namespace KarlBanan.EditorLayout
{
    /// <summary>
    /// Draws an <see cref="int"/> field as an inspector element.
    /// </summary>
    public class IntField : InspectorField<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntField"/> class.
        /// </summary>
        /// <param name="content">The content used as the field label.</param>
        /// <param name="value">The current field value.</param>
        /// <param name="setValue">The callback used to assign the changed value.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public IntField(
            GUIContent content, 
            int value, 
            Action<int> setValue, 
            Func<bool> canDisplay = null,
            ElementLayout? elementLayout = null, 
            LabelSettings? labelSettings = null) 
            : base(content, value, setValue, canDisplay, elementLayout, labelSettings)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="IntField"/> class using a text label.
        /// </summary>
        /// <param name="label">The text used as the field label.</param>
        /// <param name="value">The current field value.</param>
        /// <param name="setValue">The callback used to assign the changed value.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public IntField(
            string label, 
            int value, 
            Action<int> setValue, 
            Func<bool> canDisplay = null, 
            ElementLayout? elementLayout = null, 
            LabelSettings? labelSettings = null) 
            : base(label, value, setValue, canDisplay, elementLayout, labelSettings)
        {
        }


        /// <inheritdoc/>
        protected override int DrawField(Rect rect, GUIContent content, int currentValue)
        {
            return EditorGUI.IntField(rect, content, currentValue);
        }
    }
}