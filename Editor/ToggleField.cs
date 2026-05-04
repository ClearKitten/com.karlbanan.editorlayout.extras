using System;
using UnityEditor;
using UnityEngine;

namespace KarlBanan.EditorLayout
{
    /// <summary>
    /// Draws a toggle field as an inspector element.
    /// </summary>
    /// <remarks>
    /// This field draws its label and toggle together using <see cref="EditorGUI.ToggleLeft(Rect, GUIContent, bool)"/>.
    /// Because of that, it overrides the default field drawing behavior from <see cref="InspectorField{T}"/>.
    /// </remarks>
    public class ToggleField : InspectorField<bool>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToggleField"/> class.
        /// </summary>
        /// <param name="content">The content displayed next to the toggle.</param>
        /// <param name="value">The current toggle value.</param>
        /// <param name="setValue">The callback used to assign the changed value.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public ToggleField(
            GUIContent content, 
            bool value, 
            Action<bool> setValue, 
            Func<bool> canDisplay = null, 
            ElementLayout? elementLayout = null, 
            LabelSettings? labelSettings = null) 
            : base(content, value, setValue, canDisplay, elementLayout ?? new ElementLayout(12f, 12f, EditorGUIUtility.singleLineHeight, EditorGUIUtility.singleLineHeight, false, false), labelSettings)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ToggleField"/> class using a text label.
        /// </summary>
        /// <param name="label">The text displayed next to the toggle.</param>
        /// <param name="value">The current toggle value.</param>
        /// <param name="setValue">The callback used to assign the changed value.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public ToggleField(
            string label, 
            bool value, 
            Action<bool> setValue, 
            Func<bool> canDisplay = null, 
            ElementLayout? elementLayout = null, 
            LabelSettings? labelSettings = null) 
            : base(label, value, setValue, canDisplay, elementLayout ?? new ElementLayout(12f, 12f, EditorGUIUtility.singleLineHeight, EditorGUIUtility.singleLineHeight, false, false), labelSettings)
        {
        }


        /// <inheritdoc/>
        public override void Draw(Rect rect)
        {
            if (!CanDraw) return;

            bool newValue = DrawField(rect, content, value);

            if(newValue != value)
            {
                value = newValue;
                setValue?.Invoke(newValue);
            }
        }


        /// <inheritdoc/>
        protected override bool DrawField(Rect rect, GUIContent content, bool currentValue)
        {
            return EditorGUI.ToggleLeft(rect, content, currentValue);
        }


        /// <inheritdoc/>
        protected override float GetTotalWidth(float fieldWidth)
        {
            return EditorStyles.toggle.CalcSize(content).x + 20f;
        }
    }
}