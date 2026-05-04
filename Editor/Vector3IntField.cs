using System;
using UnityEditor;
using UnityEngine;

namespace KarlBanan.EditorLayout
{
    /// <summary>
    /// Draws a <see cref="Vector3Int"/> field as an inspector element.
    /// </summary>
    public class Vector3IntField : InspectorField<Vector3Int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3IntField"/> class.
        /// </summary>
        /// <param name="content">The content used as the field label.</param>
        /// <param name="value">The current field value.</param>
        /// <param name="setValue">The callback used to assign the changed value.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public Vector3IntField(
            GUIContent content,
            Vector3Int value,
            Action<Vector3Int> setValue,
            Func<bool> canDisplay = null,
            ElementLayout? elementLayout = null,
            LabelSettings? labelSettings = null)
            : base(content, value, setValue, canDisplay, elementLayout, labelSettings)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3IntField"/> class using a text label.
        /// </summary>
        /// <param name="label">The text used as the field label.</param>
        /// <param name="value">The current field value.</param>
        /// <param name="setValue">The callback used to assign the changed value.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public Vector3IntField(
          string label,
          Vector3Int value,
          Action<Vector3Int> setValue,
          Func<bool> canDisplay = null,
          ElementLayout? elementLayout = null,
          LabelSettings? labelSettings = null)
          : base(label, value, setValue, canDisplay, elementLayout, labelSettings)
        {
        }


        /// <inheritdoc/>
        protected override Vector3Int DrawField(Rect rect, GUIContent content, Vector3Int currentValue)
        {
            return EditorGUI.Vector3IntField(rect, content, currentValue);
        }
    }
}