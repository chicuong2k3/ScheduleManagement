---
title: 'Home page with bottom navigation for mobile app prototype'
type: 'feature'
created: '2026-08-21'
status: 'in-review'
baseline_commit: '32f1d99cf05a641f5e0bc8d31c8bed881375c6f6'
review_loop_iteration: 0
context: []
---

<frozen-after-approval reason="human-owned intent — do not modify unless human renegotiates">

## Intent

**Problem:** The app's MainPage is a bare template (a text box + a button) with no mobile app structure. It needs a real home screen with a bottom navigation bar to serve as the app's first mobile prototype.

**Approach:** Rebuild MainPage as a mobile-style layout with a home content area and a bottom navigation bar (Today / Schedule / Tasks / Profile). Keep the existing single-Page architecture and Prism 4 patterns — no Prism navigation framework, just a bottom-bar tab switcher driven by the ViewModel.

## Boundaries & Constraints

**Always:**
- Follow existing Prism 4 patterns: `NotificationObject` (RaisePropertyChanged), `DelegateCommand`, constructor-injected ViewModel, DataContext set in MainPage.xaml.cs.
- Keep single `Page` shell (MainPage) — do not introduce a separate shell + region architecture.
- Use the app's existing Modern theme (App.xaml) and semantic brushes.
- File output in English.

**Ask First:**
- Adding a real icon font/SVG asset for tab icons (prototype may use text/emoji glyphs instead).
- Switching the theme palette from Dark to Light.

**Never:**
- Do NOT add a DI framework change or migrate Prism version.
- Do NOT introduce external navigation libs (Prism navigation regions, MVVM toolkit).
- Do NOT modify AppBootstrapper, App.xaml, MainModule, or the .csproj — MainPage + its ViewModel only.

## I/O & Edge-Case Matrix

| Scenario | Input / State | Expected Output / Behavior | Error Handling |
|----------|--------------|---------------------------|----------------|
| HAPPY_PATH | User taps a bottom nav tab | Content area switches to that tab's panel; the tapped tab is visually selected | N/A |
| TAB_SWITCH_REPEAT | User taps the already-selected tab | No change; content stays; no error | No-op |

</frozen-after-approval>

## Code Map

- `src/ScheduleManagement.Ui/ScheduleManagement.Ui/MainPage.xaml` -- The page to rebuild: replace the template TextBox/Button layout with the home content area + bottom nav bar.
- `src/ScheduleManagement.Ui/ScheduleManagement.Ui/MainPage.xaml.cs` -- Constructor-injects `MainPageViewModel` and sets DataContext; unchanged except possibly nothing.
- `src/ScheduleManagement.Ui/ScheduleManagement.Ui/ViewModels/MainPageViewModel.cs` -- Add bottom-nav state: a `SelectedTab` property (index or enum) + `SelectTabCommand` (DelegateCommand) + per-tab content; keep existing `WelcomeText`/`SomeCommand` or replace with home-relevant content.
- `src/ScheduleManagement.Ui/ScheduleManagement.Ui/App.xaml` -- Read-only reference: Modern theme, Dark palette, semantic brushes (`Theme_TextBrush`, `Theme_BackgroundBrush`).
- `src/ScheduleManagement.Ui/ScheduleManagement.Ui/ScheduleManagement.Ui.csproj` -- Read-only: OpenSilver 3.3.3, OpenSilver.Prism4 3.3.0, OpenSilver.Themes.Modern 3.3.0. Do not modify.
- `src/ScheduleManagement.Ui/ScheduleManagement.Ui/AppBootstrapper.cs` -- Read-only: UnityBootstrapper registers MainPage + MainPageViewModel. Do not modify.
- `src/ScheduleManagement.Ui/ScheduleManagement.Ui/Modules/MainModule.cs` -- Read-only: registers MainPageViewModel. Do not modify.

## Tasks & Acceptance

**Execution:**
- [x] `ViewModels/MainPageViewModel.cs` -- Replace template members with bottom-nav state: `SelectedTab` (int 0..3 or enum), `SelectTabCommand` (DelegateCommand taking tab index), expose tab selection; add `CurrentTabTitle` for a home header. Keep NotificationObject pattern.
- [x] `MainPage.xaml` -- Build mobile layout: top header (app title + current tab title), central content area with per-tab panels bound to `SelectedTab` visibility, and a bottom nav bar with 4 tab buttons (Today / Schedule / Tasks / Profile) each bound to `SelectTabCommand`, visually highlighting the selected tab.

**Acceptance Criteria:**
- Given the app starts, when MainPage loads, then the home content (Today tab) is shown and the Today nav item is highlighted.
- Given the user taps "Schedule" in the bottom bar, when the tap fires SelectTabCommand, then the central panel switches to the Schedule content and the Schedule nav item is highlighted.
- Given any tab is selected, when the user taps that same tab again, then nothing changes and no error occurs.

## Design Notes

Bottom-nav tab switching uses a simple approach consistent with Prism 4 + NotificationObject: the ViewModel exposes `SelectedTab` (int) and a `SelectTabCommand` (DelegateCommand<int>). Each tab panel in XAML binds its `Visibility` to `SelectedTab` via a small converter or four bool properties (IsTodayVisible, IsScheduleVisible, ...) set inside SelectTab. Prefer four bool properties + a `SelectTab(int index)` method that flips them, raising PropertyChanged — this avoids adding an IValueConverter dependency. Nav item selected state is driven by the same bools (e.g. a style trigger on IsTodayVisible).

Keep the app title header simple text for the prototype; tab labels may use text (e.g. "Today", "Schedule", "Tasks", "Profile") — an icon font is optional and Ask First.

## Verification

**Commands:**
- `dotnet build src/ScheduleManagement.Ui/ScheduleManagement.Ui/ScheduleManagement.Ui.csproj` -- expected: build succeeds (exit 0), no XAML compile errors.

**Manual checks (if no CLI):**
- Run the app (OpenSilver in browser); confirm the home page shows a header, a content area, and a 4-item bottom bar; tapping each tab switches the central content and highlights that tab; the app uses the existing Modern theme.
