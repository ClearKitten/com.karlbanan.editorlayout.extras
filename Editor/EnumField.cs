using System;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

namespace KarlBanan.EditorLayout
{
    /// <summary>
    /// Draws an enum popup field as an inspector element.
    /// </summary>
    /// <typeparam name="TEnum">The enum type drawn by the field.</typeparam>
    public class EnumField<TEnum> : InspectorField<TEnum> where TEnum : struct, Enum 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumField{TEnum}"/> class.
        /// </summary>
        /// <param name="content">The content used as the field label.</param>
        /// <param name="value">The current enum value.</param>
        /// <param name="setValue">The callback used to assign the changed enum value.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public EnumField(
            GUIContent content,
            TEnum value, 
            Action<TEnum> setValue, 
            Func<bool> canDisplay = null, 
            ElementLayout? elementLayout = null, 
            LabelSettings? labelSettings = null) 
            : base(content, value, setValue, canDisplay, elementLayout, labelSettings)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="EnumField{TEnum}"/> class using a text label.
        /// </summary>
        /// <param name="label">The text used as the field label.</param>
        /// <param name="value">The current enum value.</param>
        /// <param name="setValue">The callback used to assign the changed enum value.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public EnumField(
            string label,
            TEnum value, 
            Action<TEnum> setValue, 
            Func<bool> canDisplay = null, 
            ElementLayout? elementLayout = null, 
            LabelSettings? labelSettings = null) 
            : base(label, value, setValue, canDisplay, elementLayout, labelSettings)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="EnumField{TEnum}"/> class from an enum value index.
        /// </summary>
        /// <param name="content">The content used as the field label.</param>
        /// <param name="enumValueIndex">The index of the enum value to select.</param>
        /// <param name="setValue">The callback used to assign the changed enum value index.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        /// <remarks>
        /// The provided index is clamped to the available enum values. When the value changes,
        /// the callback receives the selected value's index.
        /// </remarks>
        public EnumField(
            GUIContent content,
            int enumValueIndex,
            Action<int> setValue,
            Func<bool> canDisplay = null,
            ElementLayout? elementLayout = null,
            LabelSettings? labelSettings = null) 
            : base(content, canDisplay, elementLayout, labelSettings)
        {
            TEnum[] values = (TEnum[])Enum.GetValues(typeof(TEnum));

            int clampedIndex = Mathf.Clamp(enumValueIndex, 0, values.Length -1);
            this.value = values[clampedIndex];
            this.setValue = e =>
            {
                int index = Array.IndexOf(values, e);
                setValue?.Invoke(index);
            };
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="EnumField{TEnum}"/> class from an enum value index using a text label.
        /// </summary>
        /// <param name="label">The text used as the field label.</param>
        /// <param name="enumValueIndex">The index of the enum value to select.</param>
        /// <param name="setValue">The callback used to assign the changed enum value index.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public EnumField(
            string label,
            int enumValueIndex,
            Action<int> setValue,
            Func<bool> canDisplay = null,
            ElementLayout? elementLayout = null,
            LabelSettings? labelSettings = null)
            : this(new GUIContent(label), enumValueIndex, setValue, canDisplay, elementLayout, labelSettings)
        {
        }


        /// <inheritdoc/>
        protected override TEnum DrawField(Rect rect, GUIContent content, TEnum currentValue)
        {
            return (TEnum)EditorGUI.EnumPopup(rect, content, currentValue);
        }
    }
}