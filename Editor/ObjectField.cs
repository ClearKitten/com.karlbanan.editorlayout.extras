using UnityEngine;
using System;
using Object = UnityEngine.Object;
using UnityEditor;

namespace KarlBanan.EditorLayout
{
    /// <summary>
    /// Draws a Unity object reference field as an inspector element.
    /// </summary>
    /// <remarks>
    /// Use the optional <paramref name="type"/> constructor argument to restrict the accepted object type.
    /// </remarks>
    public class ObjectField : InspectorField<Object>
    {
        private readonly bool allowSceneObjects;
        private readonly Type type;


        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectField"/> class.
        /// </summary>
        /// <param name="content">The content used as the field label.</param>
        /// <param name="value">The current object reference.</param>
        /// <param name="allowSceneObjects">Whether scene objects can be assigned to the field.</param>
        /// <param name="setValue">The callback used to assign the changed object reference.</param>
        /// <param name="type">The type of object that can be assigned. If null, <see cref="Object"/> is used.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public ObjectField(
            GUIContent content, 
            Object value,
            bool allowSceneObjects,
            Action<Object> setValue,
            Type type = null,
            Func<bool> canDisplay = null, 
            ElementLayout? elementLayout = null, 
            LabelSettings? labelSettings = null) 
            : base(content, value, setValue, canDisplay, elementLayout, labelSettings)
        {
            this.allowSceneObjects = allowSceneObjects;
            this.type = type;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectField"/> class using a text label.
        /// </summary>
        /// <param name="label">The text used as the field label.</param>
        /// <param name="value">The current object reference.</param>
        /// <param name="allowSceneObjects">Whether scene objects can be assigned to the field.</param>
        /// <param name="setValue">The callback used to assign the changed object reference.</param>
        /// <param name="type">The type of object that can be assigned. If null, <see cref="Object"/> is used.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public ObjectField(
            string label,
            Object value,
            bool allowSceneObjects,
            Action<Object> setValue,
            Type type = null,
            Func<bool> canDisplay = null,
            ElementLayout? elementLayout = null,
            LabelSettings? labelSettings = null)
            : this(new GUIContent(label), value, allowSceneObjects, setValue, type, canDisplay, elementLayout, labelSettings)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectField"/> class that does not allow scene objects.
        /// </summary>
        /// <param name="content">The content used as the field label.</param>
        /// <param name="value">The current object reference.</param>
        /// <param name="setValue">The callback used to assign the changed object reference.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public ObjectField(
            GUIContent content,
            Object value,
            Action<Object> setValue,
            Func<bool> canDisplay = null,
            ElementLayout? elementLayout = null,
            LabelSettings? labelSettings = null)
            : this(content, value, false, setValue, null, canDisplay, elementLayout, labelSettings)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectField"/> class using a text label and disallowing scene objects.
        /// </summary>
        /// <param name="label">The text used as the field label.</param>
        /// <param name="value">The current object reference.</param>
        /// <param name="setValue">The callback used to assign the changed object reference.</param>
        /// <param name="canDisplay">An optional condition that determines whether the field should be drawn.</param>
        /// <param name="elementLayout">Optional layout settings for the field.</param>
        /// <param name="labelSettings">Optional label settings for the field.</param>
        public ObjectField(
            string label, 
            Object value, 
            Action<Object> setValue, 
            Func<bool> canDisplay = null, 
            ElementLayout? elementLayout = null, 
            LabelSettings? labelSettings = null) 
            : this(new GUIContent(label), value, false, setValue, null, canDisplay, elementLayout, labelSettings)
        {
        }


        /// <inheritdoc/>
        protected override Object DrawField(Rect rect, GUIContent content, Object currentValue)
        {
            return EditorGUI.ObjectField(rect, content, currentValue, type, allowSceneObjects);
        }
    }
}