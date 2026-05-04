# Changelog

All notable changes to this package will be documented in this file.

## [1.0.0] - 2026-05-04

### Added

- Initial release of KarlBanan Editor Layout Extras.
- Added `InspectorButton` for clickable inspector buttons.
- Added `ToggleField` for boolean toggle controls.
- Added `TextField` for single-line string input.
- Added `TextAreaField` for multi-line string input.
- Added `IntField`, `FloatField`, and `DoubleField` for numeric input.
- Added `EnumField<TEnum>` for enum popup fields.
- Added `ObjectField` for Unity object reference fields.
- Added `ColorField` for color input with optional eyedropper, alpha, and HDR support.
- Added `IntSliderField` and `FloatSliderField` for numeric slider input.
- Added `Vector2Field`, `Vector2IntField`, `Vector3Field`, and `Vector3IntField` for vector input.
- Added `Vector2SliderField`, `Vector2IntSliderField`, `Vector3SliderField`, and `Vector3IntSliderField` for component-based vector slider input.
- Added `VectorSliderLayout` for horizontal and vertical vector slider layouts.
- Added an Extras Usage sample with a demo scene, MonoBehaviour component, and custom inspector showcasing all extras fields.

### Changed

- Extras fields use the `KarlBanan.EditorLayout` namespace to match the core package API.

### Dependencies

- Requires `com.karlbanan.editorlayout` version `1.0.0`.