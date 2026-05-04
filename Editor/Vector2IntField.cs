using System;
using UnityEditor;
using UnityEngine;

namespace KarlBanan.EditorLayout
{
    /// <summary>
    /// Draws a <see cref="Vector2Int"/> field as an inspector element.
    /// </summary>
    public class Vector2IntField : InspectorField<Vector2Int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2IntField"/> class.
        /// </summary>
        /// <param name="content">The content used as the field label.</param>
        /// <param name="value">The current field value.</param>
        /// <param name="setValue">The callback used to assign the changed value.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public Vector2IntField(
          GUIContent content,
          Vector2Int value,
          Action<Vector2Int> setValue,
          Func<bool> canDisplay = null,
          ElementLayout? elementLayout = null,
          LabelSettings? labelSettings = null)
          : base(content, value, setValue, canDisplay, elementLayout, labelSettings)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2IntField"/> class using a text label.
        /// </summary>
        /// <param name="label">The text used as the field label.</param>
        /// <param name="value">The current field value.</param>
        /// <param name="setValue">The callback used to assign the changed value.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public Vector2IntField(
          string label,
          Vector2Int value,
          Action<Vector2Int> setValue,
          Func<bool> canDisplay = null,
          ElementLayout? elementLayout = null,
          LabelSettings? labelSettings = null)
          : base(label, value, setValue, canDisplay, elementLayout, labelSettings)
        {
        }


        /// <inheritdoc/>
        protected override Vector2Int DrawField(Rect rect, GUIContent content, Vector2Int currentValue)
        {
            return EditorGUI.Vector2IntField(rect, content, currentValue);
        }
    }
}