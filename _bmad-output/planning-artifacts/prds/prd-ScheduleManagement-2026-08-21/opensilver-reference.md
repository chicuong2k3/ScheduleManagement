# OpenSilver Reference for AI Development

> Feasibility + usage reference for building the ScheduleScope design system and components on OpenSilver. Verified against official documentation (doc.opensilver.net, opensilver.net, github.com/OpenSilver) on 2026-08-21. Use this to avoid guessing about OpenSilver's XAML capabilities.

## 1. What OpenSilver Is

- Open-source reimplementation of **Silverlight** → "WPF Everywhere". Write C#/VB/F# + XAML once, run on **web (WASM)**, **Android, iOS, Windows, macOS** (via MAUI Hybrid), **Linux** (via Photino).
- Maintained by **Userware** (French, founded 2007); MIT license; source at `github.com/OpenSilver`.
- Runs in all modern browsers without a plugin (HTML5 + CSS3 + WebAssembly).
- Supports **Prism**, MEF, MvvmLight, Newtonsoft, SharpZipLib (Userware confirms Prism support).
- Supports .NET Standard; reference .NET Standard assemblies directly. Silverlight assemblies must be recompiled.

## 2. Theming & Dark Mode

- OpenSilver **2.1+ ships 12 customizable themes** (ported from Silverlight Toolkit).
- Semantic token approach works: define brushes in a ResourceDictionary, swap via `DynamicResource` at runtime for light/dark.
- Custom `ControlTemplate` restyling is fully supported — build components from scratch.

```xml
<!-- App.xaml or merged dictionary: semantic brush -->
<ResourceDictionary>
    <SolidColorBrush x:Key="BrandBrush" Color="#4F6BF6"/>
    <!-- components reference {StaticResource BrandBrush}; swap value for dark mode -->
</ResourceDictionary>
```

## 3. Custom Fonts (Inter, Vietnamese)

Steps (verified from CSHTML5→OpenSilver custom-fonts doc):

1. Add the `.ttf` **or `.woff`** font file to the project.
2. Set **Build Action = Content** (F4 → Build Action).
3. Reference in XAML:
   - `FontFamily="ms-appx:///AssemblyName/Folder/MyFontFileName.ttf"` — or —
   - `FontFamily="/AssemblyName;component/Folder/MyFontFileName.ttf"`
4. For reuse: declare `<FontFamily x:Key="MyFontKey">ms-appx:///AssemblyName/Folder/MyFontFileName.ttf</FontFamily>` in `App.xaml` / merged dictionary, then `<TextBlock FontFamily="{StaticResource MyFontKey}"/>`.

**Cross-browser:** prefer **.WOFF** (TTF may not work in Internet Explorer unless marked "installable"). Inter supports Vietnamese — required for the VN market.

## 4. Animations (fully supported)

Complete animation support (OpenSilver 2.1+ reimplemented all Silverlight animation types + easing + keyframes):

- **Animation types:** `DoubleAnimation`, `DoubleAnimationUsingKeyFrames`, `ColorAnimation`, `ColorAnimationUsingKeyFrames`, `PointAnimation`, `PointAnimationUsingKeyFrames`, `ObjectAnimationUsingKeyFrames`.
- **Easing:** all Silverlight easing functions (e.g. `QuarticEase`, `BounceEase`, `CubicEase`...).
- **Keyframes:** Discrete, Linear, Easing, Spline.
- **In XAML** (Storyboard in Resources, triggered by name) or **programmatically** (C#).

```xml
<Storyboard x:Key="SlideIn">
    <DoubleAnimation Duration="0:0:0.25" To="0"
        Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.TranslateX)"
        Storyboard.TargetName="Panel">
        <DoubleAnimation.EasingFunction>
            <QuarticEase EasingMode="EaseOut"/>
        </DoubleAnimation.EasingFunction>
    </DoubleAnimation>
</Storyboard>
```
```csharp
// programmatic
var anim = new DoubleAnimation { Duration = new Duration(TimeSpan.FromMilliseconds(250)), To = 0 };
var sb = new Storyboard();
sb.Children.Add(anim);
Storyboard.SetTarget(anim, element);
Storyboard.SetTargetProperty(anim, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.TranslateX)"));
sb.Begin();
```

Use `CompositeTransform` for translate/scale/rotate. **Design-system rule:** keep durations 150–250ms, ≤2 concurrent animations per scene for WASM perf.

## 5. Brushes & Visuals

- `LinearGradientBrush` supported in foreground brushes (2.1+).
- `UIElement.Clip` supports more than RectangleGeometry (2.1+).
- Use `Border` with `CornerRadius` for rounded cards; keep shadows light (single-layer) for performance.
- `DropShadowEffect` works but is a WASM perf risk on mobile — prefer subtle elevation via Border + thin brush.

## 6. Layout & Responsive

- Standard WPF layout model: `Grid`, `StackPanel`, `Canvas`, `DockPanel`, `WrapPanel`.
- Responsive via `Grid` column/row definitions + `VisualState` triggered at breakpoints (phone 0–600px / tablet 600px+).
- **Avoid fixed pixel layouts** — use relative sizing, `*` rows/columns, `Auto`, and max-width wrappers.

## 7. Performance (critical for mobile WASM)

From OpenSilver GitHub performance tips — publish correctly:

- **Publish with AOT**: ~6× faster than debug (benchmark: 760ms published → 360ms published+AOT for 30k elements).
- **Virtualization** for long lists/comboboxes/treeviews — critical for the TimetableGrid over a semester.
- **IIS compression**, **lazy-load large assemblies**, **trimming** to reduce app size.
- Debug mode is not representative of production performance.

## 8. Integration Notes

- **Blazor** components importable in XAML (planned for v3.3), plus mix XAML + Razor in one project.
- Third-party: Telerik UI suite components implemented; check compatibility for others.
- Migrate existing WPF/Silverlight by creating an OpenSilver project per original project and copying files; expect some manual fixes for unsupported libs.

## 9. Design-System Implications (for ScheduleScope)

Everything in `design-system.md` is feasible:
- ✅ Custom fonts (Inter, .woff, Vietnamese)
- ✅ Light/dark theming (semantic brushes + DynamicResource, 12 built-in themes)
- ✅ All motion (Storyboard + easing, short durations)
- ✅ Rounded cards, gradients, custom ControlTemplates
- ⚠️ Discipline: AOT publish, virtualize TimetableGrid, light shadows, .woff fonts

## Key URLs

- Overview: https://doc.opensilver.net/documentation/general/overview.html
- Storyboards & animations: https://doc.opensilver.net/documentation/in-depth-topics/storyboards-and-animations.html
- Custom fonts: https://cshtml5.com/documentation/custom-fonts.aspx (CSHTML5 = OpenSilver predecessor, same engine)
- Performance: https://doc.opensilver.net/documentation/in-depth-topics/performance-improvement.html
- GitHub: https://github.com/OpenSilver/OpenSilver
- Docs root: https://doc.opensilver.net/
