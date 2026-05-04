using System;
using UnityEditor;
using UnityEngine;

namespace KarlBanan.EditorLayout
{
    /// <summary>
    /// Represents a clickable button that can be drawn inside a custom inspector layout.
    /// </summary>
    /// <remarks>
    /// The button can be conditionally displayed, conditionally enabled, and optionally drawn with a custom style.
    /// </remarks>
    public class InspectorButton : IInspectorElement
    {
        private readonly GUIContent content;
        private readonly Action onClick;
        private readonly Func<bool> canDraw;
        private readonly Func<bool> isEnabled;
        private readonly ElementLayout elementLayout;
        private readonly GUIStyle style;
        private readonly bool debugDraw;

        /// <inheritdoc/>
        public bool CanDraw => canDraw == null || canDraw();

        /// <inheritdoc/>
        public bool ExpandWidth => elementLayout.ExpandWidth;

        /// <inheritdoc/>
        public bool ExpandHeight => elementLayout.ExpandHeight;

        /// <inheritdoc/>
        public float GetMinWidth() => elementLayout.MinWidth;

        /// <inheritdoc/>
        public float GetPreferredWidth() => elementLayout.PreferredWidth;

        /// <inheritdoc/>
        public float GetMinHeight() => elementLayout.MinHeight;

        /// <inheritdoc/>
        public float GetPreferredHeight() => elementLayout.PreferredHeight;


        /// <summary>
        /// Initializes a new instance of the <see cref="InspectorButton"/> class.
        /// </summary>
        /// <param name="content">The content displayed on the button.</param>
        /// <param name="onClick">The callback invoked when the button is clicked.</param>
        /// <param name="canDraw">An optional condition that determines whether the button should be drawn.</param>
        /// <param name="isEnabled">An optional condition that determines whether the button should be enabled.</param>
        /// <param name="elementLayout">Optional layout settings for the button.</param>
        /// <param name="style">An optional GUI style used to draw the button.</param>
        /// <param name="debugDraw">Whether to draw a translucent debug background behind the button.</param>
        public InspectorButton(
            GUIContent content,
            Action onClick,
            Func<bool> canDraw = null,
            Func<bool> isEnabled = null,
            ElementLayout? elementLayout = null,
            GUIStyle style = null,
            bool debugDraw = false)
        {
            this.content = content;
            this.onClick = onClick;
            this.canDraw = canDraw;
            this.isEnabled = isEnabled;
            this.elementLayout = elementLayout ?? new(
                80f, 120f, EditorGUIUtility.singleLineHeight + 4, EditorGUIUtility.singleLineHeight + 4, false, false
            );

            this.style = style;
            this.debugDraw = debugDraw;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="InspectorButton"/> class.
        /// </summary>
        /// <param name="label">The text displayed on the button.</param>
        /// <param name="onClick">The callback invoked when the button is clicked.</param>
        /// <param name="canDraw">An optional condition that determines whether the button should be drawn.</param>
        /// <param name="isEnabled">An optional condition that determines whether the button should be enabled.</param>
        /// <param name="elementLayout">Optional layout settings for the button.</param>
        /// <param name="style">An optional GUI style used to draw the button.</param>
        /// <param name="debugDraw">Whether to draw a translucent debug background behind the button.</param>
        public InspectorButton(
          string label,
          Action onClick,
          Func<bool> canDraw = null,
          Func<bool> isEnabled = null,
          ElementLayout? elementLayout = null,
          GUIStyle style = null,
          bool debugDraw = false)
          : this(new GUIContent(label), onClick, canDraw, isEnabled, elementLayout, style, debugDraw)
        {
        }


        /// <inheritdoc/>
        public void Draw(Rect rect)
        {
            if (!CanDraw) return;

            if (debugDraw) EditorGUI.DrawRect(rect, new(1f, 0f, 0f, 0.2f));

            bool wasEnabled = GUI.enabled;
            GUI.enabled = wasEnabled && (isEnabled == null || isEnabled());

            bool clicked = style == null
                ? GUI.Button(rect, content)
                : GUI.Button(rect, content, style);

            if (clicked) onClick?.Invoke();

            GUI.enabled = wasEnabled;
        }
    }
}