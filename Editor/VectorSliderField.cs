using System;
using UnityEditor;
using UnityEngine;

namespace KarlBanan.EditorLayout
{
    /// <summary>
    /// Defines how vector slider components should be arranged.
    /// </summary>
    public enum VectorSliderLayout
    {
        Horizontal,
        Vertical,
    }

    /// <summary>
    /// Base class for vector fields that draw each vector component as a slider.
    /// </summary>
    /// <typeparam name="T">The vector value type drawn by the field.</typeparam>
    /// <remarks>
    /// Derived classes provide the actual component slider drawing logic for a specific vector type.
    /// </remarks>
    public abstract class VectorSliderField<T> : InspectorField<T>
    {
        private readonly string[] componentLabels;
        private readonly VectorSliderLayout sliderLayout;
        private readonly float spacing;
        private readonly float componentLabelWidth;


        /// <summary>
        /// Initializes a new instance of the <see cref="VectorSliderField{T}"/> class.
        /// </summary>
        /// <param name="content">The content used as the field label.</param>
        /// <param name="value">The current vector value.</param>
        /// <param name="setValue">The callback used to assign the changed vector value.</param>
        /// <param name="componentLabels">The labels used for the vector components.</param>
        /// <param name="sliderLayout">The layout direction used for the component sliders.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        protected VectorSliderField(
            GUIContent content,
            T value,
            Action<T> setValue,
            string[] componentLabels,
            VectorSliderLayout sliderLayout = VectorSliderLayout.Horizontal,
            Func<bool> canDisplay = null,
            ElementLayout? elementLayout = null,
            LabelSettings? labelSettings = null)
            : base(content, value, setValue, canDisplay, elementLayout ?? GetDefaultLayout(componentLabels.Length, sliderLayout), labelSettings)
        {
            this.componentLabels = componentLabels;
            this.sliderLayout = sliderLayout;

            spacing = 4f;
            componentLabelWidth = 14f;
        }


        /// <inheritdoc/>
        protected override T DrawField(Rect rect, GUIContent content, T currentValue)
        {
            return sliderLayout == VectorSliderLayout.Horizontal 
                ? DrawHorizontal(rect, currentValue)
                : DrawVertical(rect, currentValue);
        }


        private T DrawHorizontal(Rect rect, T currentValue)
        {
            int count = componentLabels.Length;

            float totalSpacing = spacing * (count - 1);
            float componentWidth = (rect.width - totalSpacing) / count;

            for(int i = 0; i < count; i++)
            {
                Rect componentRect = new(
                    rect.x + i * (componentWidth + spacing),
                    rect.y,
                    componentWidth,
                    EditorGUIUtility.singleLineHeight
                );

                currentValue = DrawComponent(componentRect, currentValue, i);
            }
            return currentValue;
        }

        private T DrawVertical(Rect rect, T currentValue)
        {
            int count = componentLabels.Length;
            float lineHeight = EditorGUIUtility.singleLineHeight;

            for (int i = 0; i < count; i++)
            {
                Rect componentRect = new(
                    rect.x,
                    rect.y + i * (lineHeight + spacing),
                    rect.width,
                    lineHeight
                );

                currentValue = DrawComponent(componentRect, currentValue, i);
            }
            return currentValue;
        }

        private T DrawComponent(Rect rect, T currentValue, int index)
        {
            Rect labelRect = new(rect.x, rect.y, componentLabelWidth, rect.height);
            Rect sliderRect = new(labelRect.xMax, rect.y, rect.width - componentLabelWidth, rect.height);

            EditorGUI.LabelField(labelRect, componentLabels[index]);

            return DrawComponentSlider(sliderRect, currentValue, index);
        }


        /// <summary>
        /// Draws a single vector component slider
        /// </summary>
        /// <param name="sliderRect">The rectangle used to draw the slider.</param>
        /// <param name="currentValue">The current vector value.</param>
        /// <param name="index">The index of the component being drawn.</param>
        /// <returns>The updated vector value.</returns>
        protected abstract T DrawComponentSlider(Rect sliderRect, T currentValue, int index);

        private static ElementLayout GetDefaultLayout(int componentCount, VectorSliderLayout sliderLayout)
        {
            float lineHeight = EditorGUIUtility.singleLineHeight;
            float spacing = 4f;

            if(sliderLayout == VectorSliderLayout.Vertical)
            {
                float height = componentCount * lineHeight + (componentCount - 1) * spacing;

                return new(160f, 260f, height, height, true, false);
            }

            return new(260f, 360f, lineHeight, lineHeight, true, false);
        }
    }
}