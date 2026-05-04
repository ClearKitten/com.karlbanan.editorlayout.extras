using System;
using UnityEditor;
using UnityEngine;

namespace KarlBanan.EditorLayout
{
    /// <summary>
    /// Draws a <see cref="Vector2"/> field as an inspector element.
    /// </summary>
    public class Vector2Field : InspectorField<Vector2>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2Field"/> class.
        /// </summary>
        /// <param name="content">The content used as the field label.</param>
        /// <param name="value">The current field value.</param>
        /// <param name="setValue">The callback used to assign the changed value.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Opitonal label settings for the field.</param>
        public Vector2Field(
          GUIContent content,
          Vector2 value,
          Action<Vector2> setValue,
          Func<bool> canDisplay = null,
          ElementLayout? elementLayout = null,
          LabelSettings? labelSettings = null)
          : base(content, value, setValue, canDisplay, elementLayout, labelSettings)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2Field"/> class.
        /// </summary>
        /// <param name="label">The text used as the field label.</param>
        /// <param name="value">The current field value.</param>
        /// <param name="setValue">The callback used to assign the changed value.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Opitonal label settings for the field.</param>
        public Vector2Field(
          string label,
          Vector2 value,
          Action<Vector2> setValue,
          Func<bool> canDisplay = null,
          ElementLayout? elementLayout = null,
          LabelSettings? labelSettings = null)
          : base(label, value, setValue, canDisplay, elementLayout, labelSettings)
        {
        }

        /// <inheritdoc/>
        protected override Vector2 DrawField(Rect rect, GUIContent content, Vector2 currentValue)
        {
            return EditorGUI.Vector2Field(rect, content, currentValue);
        }
    }
}