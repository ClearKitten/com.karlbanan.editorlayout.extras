using System;
using UnityEditor;
using UnityEngine;

namespace KarlBanan.EditorLayout
{
    /// <summary>
    /// Draws a <see cref="Color"/> field as an inspector element.
    /// </summary>
    /// <remarks>
    /// This field supports optional eyedropper, alpha, and HDR controls through Unity's color field API.
    /// </remarks>
    public class ColorField : InspectorField<Color>
    {
        private readonly bool showEyedropper;
        private readonly bool showAlpha;
        private readonly bool hdr;


        /// <summary>
        /// Initializes a new instance of the <see cref="ColorField"/> class.
        /// </summary>
        /// <param name="content">The content used as the field label.</param>
        /// <param name="value">The current field value.</param>
        /// <param name="showEyedropper">Whether the eyedropper control should be shown.</param>
        /// <param name="showAlpha">Whether the alpha channel should be shown.</param>
        /// <param name="setValue">The callback used to assign the changed value.</param>
        /// <param name="hdr">Whether the field should allow HDR color values.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public ColorField(
           GUIContent content,
           Color value,
           bool showEyedropper,
           bool showAlpha,
           Action<Color> setValue,
           bool hdr = false,
           Func<bool> canDisplay = null,
           ElementLayout? elementLayout = null,
           LabelSettings? labelSettings = null)
           : base(content, value, setValue, canDisplay, elementLayout, labelSettings)
        {
            this.showEyedropper = showEyedropper;
            this.showAlpha = showAlpha;
            this.hdr = hdr;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ColorField"/> class using a text label.
        /// </summary>
        /// <param name="label">The text used as the field label.</param>
        /// <param name="value">The current field value.</param>
        /// <param name="showEyedropper">Whether the eyedropper control should be shown.</param>
        /// <param name="showAlpha">Whether the alpha channel should be shown.</param>
        /// <param name="setValue">The callback used to assign the changed value.</param>
        /// <param name="hdr">Whether the field should allow HDR color values.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public ColorField(
           string label,
           Color value,
           bool showEyedropper,
           bool showAlpha,
           Action<Color> setValue,
           bool hdr = false,
           Func<bool> canDisplay = null,
           ElementLayout? elementLayout = null,
           LabelSettings? labelSettings = null)
           : this(new GUIContent(label), value, showEyedropper, showAlpha, setValue, hdr, canDisplay, elementLayout, labelSettings)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ColorField"/> class with the eyedropper and alpha controls enabled.
        /// </summary>
        /// <param name="content">The content used as the field label.</param>
        /// <param name="value">The current field value.</param>
        /// <param name="setValue">The callback used to assign the changed value.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public ColorField(
            GUIContent content, 
            Color value, 
            Action<Color> setValue, 
            Func<bool> canDisplay = null, 
            ElementLayout? elementLayout = null, 
            LabelSettings? labelSettings = null) 
            : this(content, value, true, true, setValue, false, canDisplay, elementLayout, labelSettings)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ColorField"/> class with a text label and the eyedropper and alpha controls enabled.
        /// </summary>
        /// <param name="label">The text used as the field label.</param>
        /// <param name="value">The current field value.</param>
        /// <param name="setValue">The callback used to assign the changed value.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public ColorField(
            string label, 
            Color value, 
            Action<Color> setValue, 
            Func<bool> canDisplay = null, 
            ElementLayout? elementLayout = null, 
            LabelSettings? labelSettings = null)
            : this(new GUIContent(label), value, true, true, setValue, false, canDisplay, elementLayout, labelSettings)
        {
        }


        /// <inheritdoc/>
        protected override Color DrawField(Rect rect, GUIContent content, Color currentValue)
        {
            return EditorGUI.ColorField(rect, content, currentValue, showEyedropper, showAlpha, hdr);
        }
    }
}