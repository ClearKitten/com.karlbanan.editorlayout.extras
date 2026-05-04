using System;
using UnityEditor;
using UnityEngine;

namespace KarlBanan.EditorLayout
{
    /// <summary>
    /// Draws a single-line text field as an inspector element.
    /// </summary>
    public class TextField : InspectorField<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextField"/> class.
        /// </summary>
        /// <param name="content">The content used as the field label.</param>
        /// <param name="text">The current text value.</param>
        /// <param name="setValue">The callback used to assign the changed text value.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public TextField(
            GUIContent content,
            string text,
            Action<string> setValue,
            Func<bool> canDisplay = null,
            ElementLayout? elementLayout = null,
            LabelSettings? labelSettings = null)
            : base(content, text, setValue, canDisplay, elementLayout, labelSettings)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="TextField"/> class using a text label.
        /// </summary>
        /// <param name="label">The text used as the field label.</param>
        /// <param name="text">The current text value.</param>
        /// <param name="setValue">The callback used to assign the changed text value.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public TextField(
           string label,
           string text,
           Action<string> setValue,
           Func<bool> canDisplay = null,
           ElementLayout? elementLayout = null,
           LabelSettings? labelSettings = null)
           : base(label, text, setValue, canDisplay, elementLayout, labelSettings)
        {
        }


        /// <inheritdoc/>
        protected override string DrawField(Rect rect, GUIContent content, string currentValue)
        {
            return EditorGUI.TextField(rect, content, currentValue);
        }
    }
}