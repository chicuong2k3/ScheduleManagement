# Design System — ScheduleScope (Custom, OpenSilver + Prism)

> Custom design system for the mobile student timetable app, built in XAML on OpenSilver (WASM) with Prism MVVM. Feeds `bmad-ux` for screen-level spec and `bmad-build` for component implementation. Design decisions ratified 2026-08-21.

## 1. Design Principles

1. **Calm surface, loud schedule.** The neutral background must stay quiet so the color-coded subject palette does the visual work. The timetable *is* the hero; chrome recedes.
2. **Typography over boxes.** Establish hierarchy with type weight/size, not borders and fills. Cards are flat with soft shadow; we don't box everything.
3. **Motion with intent, not decoration.** Animate only when it carries meaning (view transition, sheet open, task complete). Short and fast.
4. **Anti-bloat.** One way to do a thing. No competing patterns for the same control. (Direct counter to the MyStudyLife feature-bloat failure mode.)
5. **Mobile-first by construction.** Touch targets ≥44px, bottom navigation, one-thumb reachability.

## 2. Token Architecture (two layers)

**Primitives** hold raw values; **Semantics** map them to meaning. This enables clean light/dark swap and future re-theming.

```
Primitives (raw)                Semantics (meaning)
─────────────                   ──────────────────
color.brand.500  = #4F6BF6  →   color.brand          (primary action, active)
color.neutral.50 = #F7F8FA  →   color.surface        (app background)
color.neutral.0  = #FFFFFF  →   color.surfaceCard    (cards, sheets)
color.neutral.900= #1A1D21  →   color.textPrimary
color.neutral.500= #6B7280  →   color.textSecondary
color.neutral.200= #E5E7EB  →   color.divider
radius.12                    →   radius.card
space.16                     →   space.md
type.body.16                 →   type.body
```

Only Semantics are referenced in components; only Primitives change value. This is the WPF-UI / Material / Avalonia token pattern.

## 3. Color

### 3.1 Brand & Neutral (two themes)

**Light:**
| Semantic | Hex | Use |
|---|---|---|
| `surface` | `#F7F8FA` | app background |
| `surfaceCard` | `#FFFFFF` | card, sheet, dialog |
| `textPrimary` | `#1A1D21` | headings, body |
| `textSecondary` | `#6B7280` | captions, meta |
| `textDisabled` | `#9CA3AF` | disabled |
| `brand` | `#4F6BF6` | primary button, active nav, link |
| `brandMuted` | `#E8ECFF` | selected/bg chip |
| `onBrand` | `#FFFFFF` | text on brand |
| `divider` | `#E5E7EB` | hairlines |
| `surfaceSunken` | `#EFF1F5` | input bg, pressed |

**Dark:**
| Semantic | Hex |
|---|---|
| `surface` | `#121418` |
| `surfaceCard` | `#1C1F24` |
| `textPrimary` | `#F2F4F8` |
| `textSecondary` | `#9AA3B2` |
| `textDisabled` | `#6B7280` |
| `brand` | `#6C85FF` (raised for contrast) |
| `brandMuted` | `#232B4D` |
| `onBrand` | `#FFFFFF` |
| `divider` | `#2A2F38` |
| `surfaceSunken` | `#0E1013` |

*Contrast:* all text pairs meet WCAG 2.1 AA (≥4.5:1 body, ≥3:1 large). Brand on surface ≥4.5:1.

### 3.2 Subject Palette (the timetable's color language)

8 colors, CVD-safe across both themes, pastel-friendly so they read as soft fills with dark text:

| Subject | Hex | Dark-tuned |
|---|---|---|
| Blue | `#5B8DEF` | `#6C9DF2` |
| Purple | `#7C5CBF` | `#8E6FD4` |
| Orange | `#E1704F` | `#E88463` |
| Green | `#3FB98C` | `#55C79E` |
| Pink | `#D6457D` | `#DE5B8F` |
| Amber | `#F2A33C` | `#F5B35C` |
| Teal | `#4CC9C7` | `#61D6D4` |
| Brown | `#8D6E63` | `#9C7F74` |

Each subject maps to one palette color; the color is the primary identifier of the subject across timetable cell, chip, and agenda card.

### 3.3 Semantic status colors

| Token | Light | Dark | Use |
|---|---|---|---|
| `success` | `#2E9E6B` | `#3FC58A` | done, present |
| `warning` | `#D98E04` | `#E5A81F` | upcoming, warning |
| `danger` | `#D64545` | `#E55C5C` | overdue, absent |
| `info` | `#4F6BF6` | `#6C85FF` | neutral info |

## 4. Typography

**Font:** Inter (variable weight). Supports Vietnamese fully — required for the VN market. Embedded via OpenSilver `FontFamily` (TTF asset).

| Token | Size/Weight/Line | Use |
|---|---|---|
| `display` | 32 / Bold / 40 | screen title |
| `headline` | 24 / Semibold / 32 | section title |
| `title` | 20 / Semibold / 28 | card title |
| `body` | 16 / Regular / 24 | body text |
| `bodyStrong` | 16 / Semibold / 24 | emphasized body |
| `caption` | 13 / Regular / 18 | timestamps, meta |
| `label` | 12 / Medium / 16 | chips, buttons, nav labels |
| `numeric` | 16 / Semibold / 24 | times, counts (tabular-nums) |

*OpenSilver note:* keep tabular-nums for time display so digits don't jitter; apply via font-feature or a monospaced-digit variant.

## 5. Spacing, Radius, Elevation

**Spacing scale (4px grid):** `space.xs` 4 · `space.sm` 8 · `space.md` 16 · `space.lg` 24 · `space.xl` 32 · `space.xxl` 48. Internal padding uses `sm`–`md`; section gaps `lg`–`xl`.

**Radius:**
| Token | Value | Use |
|---|---|---|
| `radius.sm` | 8 | chips, small inputs |
| `radius.md` | 12 | buttons, inputs |
| `radius.lg` | 20 | cards, sheets |
| `radius.pill` | 999 | pills, FAB, nav |

**Elevation (soft, minimal — OpenSilver WASM performance):**
| Token | Shadow | Use |
|---|---|---|
| `elev.1` | `0 2px 8px rgba(0,0,0,.06)` | resting cards |
| `elev.2` | `0 8px 24px rgba(0,0,0,.10)` | sheets, bottom bar |
| `elev.3` | `0 16px 40px rgba(0,0,0,.16)` | modal, FAB raised |

*OpenSilver note:* keep shadows to one layer and light — heavy/stacked `DropShadowEffect` is a WASM performance risk on mobile.

## 6. Touch & Density

- **Touch target:** ≥44×44px for all interactive elements (48px preferred for primary).
- **Hit area** extends beyond visual size for small controls (chip).
- **Bottom nav** height 64px + safe-area inset; center FAB floats above it.
- **Content max-width:** 480px on phone, 600px on tablet; grid reflows, never stretches.

## 7. Component Inventory (timetable-specific)

| Component | Purpose | Key states |
|---|---|---|
| **TimetableGrid** | week view, color-coded cells, current-time line | today highlighted |
| **ScheduleCard** | event row in agenda: color bar, time, title | normal / done / past / conflict |
| **DayStrip** | 7-day selector, today's date auto-jump | selected / today / dimmed |
| **FilterChip** | filter by event type (school, tutoring, club, exam, deadline) | selected / unselected |
| **EventTypePill** | inline type badge | per type |
| **AddButton (FAB)** | primary add-event affordance | rest / pressed |
| **BottomBar** | primary navigation (Today, Schedule, Tasks, Profile) | active tab |
| **Sheet** | bottom sheet for create/edit event | open / dismiss |
| **EmptyState** | no-events / no-results with illustration | — |
| **Toast/Snackbar** | transient confirmation | info / success / error |

Each ships a dark-mode variant via semantic tokens; no component hard-codes color.

## 8. Motion

- **Duration:** 150–250ms (fast, responsive).
- **Easing:** `cubic-bezier(0.2, 0, 0, 1)` (Material standard) — snappy in, soft settle.
- **When to animate:**
  - View/tab transition: 250ms fade+slide.
  - Sheet open: 250ms slide-up.
  - Task complete: 200ms check-pop.
  - Day/date switch: 150ms crossfade.
- **Reduced motion:** honor OS setting — collapse all non-essential animation (crossfade only).
- *OpenSilver note:* use `Storyboard`/`DoubleAnimation`; test on mobile WASM; keep concurrent animations ≤2 per scene.

## 9. Accessibility (ties to FR-8 NFRs)

- **Contrast:** WCAG 2.1 AA (4.5:1 body, 3:1 large).
- **Focus states:** clear 2px visible ring on all interactive elements; not color-only.
- **4 CVD modes** (color-vision deficiency): a palette override for deuteranopia, protanopia, tritanopia, achromatopsia — swaps the 8 subject colors to distinguishable hues AND adds a distinct per-subject icon/pattern so color is never the only channel. (Parity with Student Trove.)
- **Text scaling:** 0.5×–2.0×; layout reflows (no clipping).
- **Reduced motion** (above).
- **Semantic roles / labels** on custom controls for screen readers.

## 10. Dark Mode Strategy

- Two semantic token sets (light/dark above), single component set.
- OpenSilver theme swap: a `ThemeDictionary` / `DynamicResource` approach toggles semantic brushes at runtime; primitives differ, components unchanged.
- System preference drives default; user override persists.
- Persist choice; flash-free first paint (resolve theme before first frame).

## 11. OpenSilver Implementation Notes (feasibility — verified against official docs 2026-08-21)

- **ControlTemplate restyling:** fully supported — build custom controls from scratch.
- **Custom fonts:** embed TTF **or WOFF** (Inter) via OpenSilver font asset — add the `.ttf`/`.woff` file with **Build Action = Content**, then reference by URI `ms-appx:///AssemblyName/Folder/MyFont.ttf` or `/AssemblyName;component/Folder/MyFont.ttf`. **Prefer .WOFF for cross-browser compat** (TTF may not work in IE unless "installable"). Declare as `<FontFamily x:Key="MyFont">` in `App.xaml` (or merged ResourceDictionary) and consume with `{StaticResource MyFont}`. Supports Vietnamese. *(Source: doc.opensilver.net / CSHTML5 custom-fonts doc)*
- **Theming / dark mode:** OpenSilver 2.1+ ships 12 customizable themes (ported from Silverlight Toolkit). Semantic brushes via `DynamicResource` swap at runtime; primitives differ, components unchanged. *(Source: opensilver.net announcements/2-1)*
- **Motion:** full animation support — `DoubleAnimation`, `DoubleAnimationUsingKeyFrames`, `ColorAnimation`, `ColorAnimationUsingKeyFrames`, `PointAnimation`, `ObjectAnimationUsingKeyFrames`, all easing functions (QuarticEase etc.), and Discrete/Linear/Easing/Spline keyframes; via XAML Storyboard or programmatic C#. Use `CompositeTransform` for translate/scale. *(Source: doc.opensilver.net in-depth-topics/storyboards-and-animations)*
- **Brushes:** `LinearGradientBrush` supported in foreground brushes (2.1+).
- **Layout / responsive:** `Grid` + `VisualState` for breakpoints; supports WPF layout model.
- **Performance:** publish with **AOT** (~6× faster than debug); enable **virtualization** for long lists (TimetableGrid over a semester), use IIS compression, trim assemblies. *(Source: github.com/OpenSilver/OpenSilver performance tips)*
- **Prism:** supported by Userware (Prism/MEF/MvvmLight compatibility confirmed in overview doc).
- **Shadows:** keep light single-layer only (WASM perf); prefer `Border` with thin brush + subtle elevation over heavy `DropShadowEffect`.

**Verified-feasibility summary:** A fully custom design system is realistic on OpenSilver — fonts, themes/dark mode, animations, gradients, and custom ControlTemplates all work. The main discipline is performance (AOT + virtualization + light shadows) and using `.woff` fonts.

## 12. Anti-References (what we deliberately avoid)

- **MyStudyLife:** feature bloat, unreadable accent colors, no hierarchy.
- **Busy dashboards:** dense borders, heavy chrome.
- **Dark-on-black** with low contrast.
- **Shadow stacks** / glassmorphism overload (perf + clutter on a schedule tool).

---

*Canonical source of truth for all UI work. Downstream: `bmad-ux` (screen-level spec), `bmad-build` (component impl), `bmad-architecture` (theme-swap infra). Ratified 2026-08-21.*