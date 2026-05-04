using System;
using UnityEditor;
using UnityEngine;

namespace KarlBanan.EditorLayout
{
    /// <summary>
    /// Draws a <see cref="Vector3"/> field as an inspector element.
    /// </summary>
    public class Vector3Field : InspectorField<Vector3>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3Field"/> class.
        /// </summary>
        /// <param name="content">The content used as the field label.</param>
        /// <param name="value">The current field value.</param>
        /// <param name="setValue">The callback used to assign the changed value.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public Vector3Field(
           GUIContent content,
           Vector3 value,
           Action<Vector3> setValue,
           Func<bool> canDisplay = null,
           ElementLayout? elementLayout = null,
           LabelSettings? labelSettings = null)
           : base(content, value, setValue, canDisplay, elementLayout, labelSettings)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3Field"/> class using a text label.
        /// </summary>
        /// <param name="label">The text used as the field label.</param>
        /// <param name="value">The current field value.</param>
        /// <param name="setValue">The callback used to assign the changed value.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public Vector3Field(
          string label,
          Vector3 value,
          Action<Vector3> setValue,
          Func<bool> canDisplay = null,
          ElementLayout? elementLayout = null,
          LabelSettings? labelSettings = null)
          : base(label, value, setValue, canDisplay, elementLayout, labelSettings)
        {
        }

        /// <inheritdoc/>
        protected override Vector3 DrawField(Rect rect, GUIContent content, Vector3 currentValue)
        {
            return EditorGUI.Vector3Field(rect, content, currentValue);
        }
    }
}