---
title: Schedule Management — Mobile Student Life-Planner with Tutor Vertical
created: 2026-08-21
updated: 2026-08-21
status: final
---

# PRD: Schedule Management

*Working title: "ScheduleScope" — confirm name at finalize.*

## 0. Document Purpose

This PRD defines a **mobile-first student life-planner** (Android + iOS, built with .NET MAUI) with a **tutor/center management vertical** layered on the same schedule engine. It is for the product owner, engineering, and downstream workflow owners (UX, architecture, epics). It builds on the completed competitive analysis in `_bmad-output/brainstorming/brainstorm-competitor-analysis-student-schedule-2026-08-20/brainstorm-intent.md` — that document holds the evidence (competitor tables, pricing, complaints); this PRD converts it into requirements.

The product serves **three roles on one shared schedule reality**: students (free, core planner), tutors/small centers (paid management layer), and parents (zero-install Zalo Mini App / WhatsApp window). The architecture principle is **one engine, two roles, three windows** — a general-purpose typed schedule engine, a role-based UI toggle for tutor management, and a messaging-app parent surface.

Structure: Glossary-anchored vocabulary; features grouped with globally numbered FRs; assumptions tagged inline and indexed in §9. **[ASSUMPTION]** tags mark every inference made without explicit confirmation — review these first.

## 1. Vision

Every student's academic life is scattered across school timetables, tutoring sessions, clubs, exams, and deadlines — each tracked in a different app, a paper notebook, or a teacher's spreadsheet. Existing student planners either lose data on update (MyStudyLife's 2024 redesign), shut down entirely (iStudiez Pro), or only cover one slice of the student's week. Existing tutor/center tools are web-only and desktop-bound, and none of them connect to the student or parent side at all.

ScheduleScope is a **general-purpose, offline-first schedule engine** that holds the student's entire week — school classes, tutoring, clubs, exams, assignments, personal plans — in one reliable place that never loses data. On the same engine, a **tutor mode** adds attendance, package tracking, and VN-native billing (VietQR + MoMo/ZaloPay). Parents connect through **Zalo Mini App (VN) / WhatsApp Business (global)** with zero install.

It matters because the student–tutor–parent triangle is currently served by three disconnected tools. Owning the shared schedule reality lets each role see and act on the same truth — the student plans, the tutor manages, the parent watches — and each role's adoption feeds the others' (students invite tutors; tutors bring their other students).

## 2. Target User

### 2.1 Jobs To Be Done

**Students (free core users):**
- "Keep my whole week — school, tutoring, clubs, deadlines — in one place I can check without losing my notes."
- "Never lose my schedule because an update went wrong or I lost signal on the bus."
- "Get reminded before a class, exam, or assignment deadline without being spammed."
- "See at a glance what's coming today and this week."

**Tutors / small centers (paid users):**
- "Manage my teaching schedule and my students' attendance from my phone, not a desktop spreadsheet."
- "Track how many paid sessions remain in each student's package and get paid without chasing invoices." *(Paid tier unlocks package tracking and billing; see §6.1.)*
- "Keep parents informed without manual messages."

**Parents (zero-install window):**
- "Check my child's schedule and attendance and pay tuition without installing another app."

### 2.2 Non-Users (v1)

- **Enterprise tutoring chains >50 tutors** — served by TutorCruncher, Wise, Alinaflow; their multi-branch, multi-currency, complex-payroll needs are out of scope for v1.
- **K-12 public schools** — face-ID attendance and SIS workflows are saturated by VNPT vnFace, SchoolX, VIETSCHOOL; we do not compete for school-wide deployments.
- **Pure booking users** — appointment-only schedulers (Calendly, Setmore, Square) serve them; we are not a generic booking tool.
- **AI handwriting graders** — IntelGrader owns this category; not our entry.

### 2.3 Key User Journeys

- **UJ-1. Linh (16, HCMC high-schooler) sets up her real week — school, tutoring, club — and survives a week of patchy bus Wi-Fi.**
  - **Persona + context:** Linh takes the bus 40 minutes each way; signal drops in tunnels. She previously lost a semester's timetable to a MyStudyLife update.
  - **Entry state:** First launch, fresh install, no account required.
  - **Path:** She opens the app and taps "Add class" → picks type "School class", enters name/time/room → repeats for "Tutoring (English)", "Badminton club", adds two exam dates and three assignment deadlines. All saved locally. She creates an account (optional, for sync) — data is already on device.
  - **Climax:** Her week appears as a color-coded grid; today's classes are on the home screen widget without opening the app.
  - **Resolution:** She rides the bus, opens the app offline — everything is there. Changes she made offline sync silently when signal returns. **Edge case:** two events collide (club moved to tutoring time) — the app flags the conflict and asks which to keep rather than silently dropping one.
  - **Realizes:** FR-1, FR-2, FR-3, FR-6.

- **UJ-2. Linh adds her tutoring sessions and invites her tutor, Mr. Minh.**
  - **Persona + context:** Linh has weekly English tutoring with Mr. Minh, a solo tutor with 15 students who still tracks attendance in Excel.
  - **Entry state:** Linh is logged in, has her school schedule set up.
  - **Path:** She adds a "Tutoring session" event → the app offers "Invite your tutor" → she enters Mr. Minh's phone (Zalo) or shares a link. Mr. Minh gets a Zalo message: "Linh invited you to manage her sessions."
  - **Climax:** Mr. Minh accepts, and the session appears in his tutor-mode calendar with Linh's profile attached — no data re-entry.
  - **Resolution:** Linh's sessions and Mr. Minh's schedule now share one reality. Mr. Minh sees his other students have the same app and invites them.
  - **Realizes:** FR-9, FR-10.

- **UJ-3. Mr. Minh marks attendance and tracks packages on his phone between sessions.**
  - **Persona + context:** Solo tutor, 15 students, teaches at 3 locations; previously spent Sundays reconciling Excel sheets.
  - **Entry state:** Tutor mode enabled (paid tier), authenticated.
  - **Path:** Opens the app → today's sessions listed → taps the session → marks each student Present/Absent via QR scan or one tap → sees remaining sessions in each student's package → for a new student, creates a 12-session package.
  - **Climax:** A session completes; the package decrements automatically; a VietQR invoice is generated and sent to the parent's Zalo.
  - **Resolution:** Payment arrives via MoMo/ZaloPay and reconciles automatically. Mr. Minh's monthly totals are ready without spreadsheet work.
  - **Realizes:** FR-11, FR-12, FR-13, FR-14.

- **UJ-4. Ms. Hoa checks her daughter's attendance and pays tuition from Zalo.**
  - **Persona + context:** Working mother; doesn't want another app; lives on Zalo.
  - **Entry state:** Zero install — she opens the Zalo Mini App link from the school/tutor's Zalo OA.
  - **Path:** Sees daughter's week, today's attendance status, and an unpaid invoice → taps Pay → chooses MoMo/ZaloPay/VietQR → confirms.
  - **Climax:** Payment confirmed in 30 seconds; the tutor's app shows it reconciled.
  - **Resolution:** She closes Zalo. No app installed, no account created.
  - **Realizes:** FR-15, FR-16, FR-17.

- **UJ-5. Ms. Trang, small center owner (80 students, 6 tutors), runs payroll and a parent report.**
  - **Persona + context:** Runs a small English center; currently uses Daytot plus manual payroll in Excel.
  - **Entry state:** Center tier, tutor mode with multiple tutors.
  - **Path:** End of month → app aggregates each tutor's sessions → generates payroll split with VN PIT/BHXH rules → one tap sends an AI-drafted parent report (Vietnamese) per student via Zalo → finalizes payroll payout via MoMo Payroll.
  - **Climax:** Payroll calculated and paid out; parents receive readable progress summaries.
  - **Resolution:** Month-end admin that took 1–2 days now takes an afternoon.
  - **Realizes:** FR-18, FR-19.

## 3. Glossary

- **Schedule Event** — The atomic unit of the engine: a typed calendar entry with time, location, color, recurrence, notes, reminders. Every other domain concept is a kind of event. *(1 student ↔ N events; 1 tutor ↔ N events)*
- **Event Type** — The typed category of a Schedule Event: `school class`, `tutoring session`, `club / extracurricular`, `exam`, `assignment deadline`, `personal`. Type determines which capabilities attach.
- **Tutoring Session** — A Schedule Event of type `tutoring session` that links a Student, a Tutor, an optional Package, and an attendance record. The unit the paid tier manages.
- **Student** — The free-tier user whose Schedule Events form their timetable. A Student may be linked to one or more Tutors.
- **Tutor** — A paid-tier user who manages Tutoring Sessions, attendance, packages, and billing. May be a solo tutor or belong to a Center.
- **Center** — A paid-tier organization of multiple Tutors (small centers, 2–50 tutors) with shared billing, payroll, and reporting.
- **Parent** — A viewer/actor on the messaging-app window (Zalo Mini App / WhatsApp Business). Linked to one or more Students. Does not install the app.
- **Package** — A prepaid block of Tutoring Sessions (e.g. 12 sessions). Decrements per session; drives billing.
- **Attendance** — Per-session record of present/absent/excused for each linked Student. Realized via QR scan or manual mark.
- **Invoice** — A generated bill (VietQR-embedded PDF or message) for a Package or session group, sent to the Parent's messaging window.
- **Window** — A surface for a role: the Student app (native), the Tutor mode (same app, role toggle), or the Parent window (Zalo Mini App / WhatsApp Business). One engine, three windows.
- **Timetable Photo** — A photograph of a paper timetable (Vietnamese school format) imported via OCR (FR-22) as an editable draft.
- **Schedule Share** — A link sharing a Student's week schedule (FR-23); the acquisition loop's distribution mechanism.

## 4. Features

### 4.0 Cú Chụp TKB — Photo-to-Timetable Acquisition (lead phase-1 feature) *(new — from party discussion 2026-08-21)*

**Description:** The acquisition engine of phase 1. A Student photographs a paper timetable (Vietnamese school format: periods 1–5, days Mon–Sun, room numbers) and the app converts it into a full week schedule via OCR, presented as an **editable draft** to be confirmed in ~30 seconds — not requiring perfect OCR, only eliminating the 10-minute manual entry. A Student can then share their week schedule to classmates via a link ("see my week"); the recipient sees the shared schedule *first*, and is invited to photograph *their own* timetable *after* — value before ask. Each recipient has their own reason to import their schedule, so the loop is self-sustaining. Realizes UJ-1, and is the primary acquisition differentiator vs. both global (English-only OCR, no VN format) and local (no photo-import) competitors.

**Why it is the lead feature:** Phase-1 objective is **acquisition** (user choice 2026-08-21). OCR photo-import solves the single highest-friction moment for a new student (entering a semester timetable) and the share loop turns every importing student into an acquisition vector. It is placed *above* the general engine in priority.

**Functional Requirements:**

#### FR-22: Photo-to-Timetable OCR Import (VN format)

A Student can photograph a paper timetable (Vietnamese school format) and generate an editable draft of Schedule Events in ~30 seconds, then confirm or adjust before committing.

**Consequences (testable):**
- OCR of a standard VN paper timetable produces a draft recognizing periods (tiết 1–5), days (thứ 2–7), and room numbers; mis-parsed cells are flagged for correction.
- Confirm creates all Schedule Events in one action; cancel discards the draft with no partial write.
- Target: ≥90% of cells correct on first pass for clean printed timetables; the draft must still be usable (≤30s to confirm) when accuracy is lower.

**Out of Scope:** handwriting OCR (IntelGrader's category); autonomous import with no confirmation step.

#### FR-23: Schedule Sharing Loop (acquisition)

A Student can share their week schedule to a classmate via a link; the recipient views the shared schedule, then is invited to photograph their own timetable, completing a self-sustaining acquisition loop.

**Consequences (testable):**
- A shared link renders the sender's week (including any Deadline events) without the recipient creating an account.
- After viewing, the recipient receives a single non-blocking invitation to photograph their own timetable.
- Each unique view is attributed for funnel measurement (SM-2a).

**Feature-specific NFRs:**
- Share link opens and renders in <2s; no account required to view.
- Deadline events appear in the shared schedule (this is what creates learning context — see FR-8 coupling).

**Notes:** This feature is coupled to FR-8 (deadline tracking) — the shared schedule must carry deadlines to create learning context that motivates recipients to import their own; FR-8 is therefore **required** in phase 1 (party decision 2026-08-21), not optional.

### 4.1 General Schedule Engine (core — all roles)

**Description:** The foundational typed-event engine. A Student (or Tutor, for their own availability) creates Schedule Events of any type with time, location, color, recurrence (daily/weekly/A-B weeks up to 4-week cycles), notes, and reminders. The engine is offline-first: all writes hit local encrypted storage first, sync in the background when connectivity returns, and resolve conflicts deterministically (last-write-wins per field with an explicit conflict notice — never silent data loss). Realizes UJ-1, UJ-2.

**Functional Requirements:**

#### FR-1: Typed Schedule Events

A Student can create, edit, delete, and reorder Schedule Events of any Event Type with time, location, color, notes, and per-type icons.

**Consequences (testable):**
- Creating an event of type `tutoring session` surfaces tutor-linking UI; creating `school class` does not.
- Events persist to local storage in <200ms; visible immediately with an offline indicator when disconnected.

**Out of Scope:** calendar import from Google/Outlook in v1 (deferred — see §6.2).

#### FR-2: Flexible Recurrence

A Student can define recurring events including A/B-week cycles (up to 4-week patterns) with per-occurrence overrides.

**Consequences (testable):**
- A B-week timetable displays the correct week's classes automatically based on an anchor date.
- Overriding one occurrence does not alter the base pattern.

#### FR-3: Conflict Detection

The engine detects overlapping events on the same Student schedule and prompts resolution rather than silently dropping either.

**Consequences (testable):**
- Two overlapping events on one schedule produce an explicit conflict card with keep/reschedule choices; the user's choice persists and is undoable within the session.

#### FR-4: Offline-First Persistence with No-Data-Loss Guarantee

All writes persist to local encrypted storage first; sync is background and never destructive. A data-integrity invariant: **no update or sync operation may destroy user-created data.**

**Consequences (testable):**
- Full CRUD works with airplane mode on; changes queue and sync on reconnect.
- A forced-kill mid-sync leaves local data intact and re-syncs on next launch.
- Schema migrations preserve all existing events (tested against a fixture simulating MyStudyLife's data-loss scenario).

#### FR-5: Reliable Cross-Device Sync

A Student with an account can sync the same schedule across devices with deterministic conflict resolution.

**Consequences (testable):**
- Conflict resolution is per-field last-write-wins with an explicit "conflict resolved" notice; no silent merge.
- Sync latency <5s on reconnect under normal network.

#### FR-6: Reminders and Widgets

A Student can set per-event reminders (multiple offsets, exact-time firing) and pin today's classes to the home-screen widget.

**Consequences (testable):**
- Reminders fire at configured times even if the app was backgrounded; a "missed reminder" log exists.
- Widget updates within 1 minute of schedule changes on the same device.

**Feature-specific NFRs:**
- Widget refresh cost must not exceed 1% battery/day (measured via Android battery stats / iOS Energy Impact over a 7-day cohort).
- Cold start to interactive home screen <1.5s on mid-range Android.

### 4.2 Student Planner Experience (free tier)

**Description:** The student-facing surface: timetable grid, agenda list, assignment/exam tracking, and a simple, uncluttered UX in Vietnamese and English. Explicitly avoids feature bloat (MyStudyLife anti-pattern): the core is read-and-remember, not a study suite. Realizes UJ-1.

**Functional Requirements:**

#### FR-7: Timetable and Agenda Views

A Student can switch between a week grid (color-coded), a day agenda, and a month overview of all Schedule Events.

**Consequences (testable):**
- Views render from the same event set with no data duplication.
- Week grid supports 1–4 week cycle labels.

#### FR-8: Assignment, Exam, and Deadline Tracking *(REQUIRED in phase 1 — couples with FR-23)*

A Student can create `assignment deadline` and `exam` events with due-time-of-day (not just due-date), completion toggles, and per-category color coding.

**Consequences (testable):**
- A task due at 14:00 today is distinguishable from one due at first class.
- Completed tasks collapse in agenda view.
- Deadline events are included in shared schedules (FR-23), creating the learning context that motivates recipients to import their own schedule.

**Feature-specific NFRs:**
- Text scaling 0.5×–2.0×; color-vision-deficiency modes for the four main CVD types (accessibility parity with Student Trove).

### 4.3 Role Toggle and Tutor Mode (paid tier)

**Description:** The same engine exposes a **Tutor role** via a mode toggle (never mixed into the Student UI). In Tutor mode, Tutoring Sessions gain management capabilities: attendance, packages, billing, and multi-tutor organization (Center). The student UI never shows these controls. Realizes UJ-2, UJ-3, UJ-5.

**Functional Requirements:**

#### FR-9: Role-Based UI Toggle

A user with a Tutor account can switch between Student view and Tutor view; the Tutor view shows management controls only for events they teach.

**Consequences (testable):**
- A tutor's own Student schedule is unaffected by enabling Tutor mode.
- No management control (attendance, billing, payroll) appears in Student view.

#### FR-10: Tutor–Student Invite Loop

A Student can invite a Tutor (by phone/Zalo/link) to manage their Tutoring Sessions; a Tutor can invite their other Students.

**Consequences (testable):**
- Invite acceptance links the pair without re-entering schedule data; the shared session appears on both sides.
- Invite lands as a Zalo/WhatsApp message with a one-tap accept.

#### FR-11: Attendance

A Tutor can mark Attendance per Student per Tutoring Session via QR scan or manual tap (present/absent/excused).

**Consequences (testable):**
- Attendance records persist per session and roll up to per-student reports.
- QR scanning works offline (QR contains a session token; sync validates later).

#### FR-12: Package Tracking

A Tutor can create Packages (prepaid session blocks) per Student; sessions decrement the Package automatically.

**Consequences (testable):**
- Completing a session decrements the Package; reaching zero triggers an upsell/reminder to the Parent window.
- Package balances are visible to the Student/Parent in their windows.

#### FR-13: Session Completion Workflow

A Tutor can mark a session complete, which triggers package decrement, invoice generation, and optional parent notification in one action.

**Consequences (testable):**
- One "Complete" tap produces: attendance saved, package decremented, invoice queued, parent notified (if configured).

### 4.4 Billing and Payments — VN Rails (paid tier)

**Description:** Native Vietnamese payment rails are a differentiator (no competitor unifies these): package decrement → VietQR invoice → MoMo/ZaloPay T+0 reconciliation. Payments are processed by licensed processors (MoMo, ZaloPay); the app orchestrates, never holds card data. Realizes UJ-3, UJ-4.

**Functional Requirements:**

#### FR-14: VietQR Invoice Generation

The system generates a VietQR-embedded invoice for a Package or session group, delivered to the Parent's messaging window.

**Consequences (testable):**
- Invoices render correctly in a PDF/message with a scannable VietQR code (NAPAS-247 standard, CRC-16).
- Invoice references the correct Package balance and student.

#### FR-15: MoMo / ZaloPay Payment Collection and Reconciliation

The system initiates payment via MoMo or ZaloPay and reconciles incoming payments to invoices automatically.

**Consequences (testable):**
- A confirmed payment marks the `Invoice` paid and updates the `Package` balance in <60s.
- Failed/reversed payments surface a retry prompt with automatic reminder scheduling.

**Feature-specific NFRs:**
- The app itself must never store card numbers or full PANs (PCI scope minimized to processor-hosted flows).

#### FR-16: Parent Payment via Messaging Window *(MVP: Zalo only)*

A Parent can pay an `Invoice` from the messaging window (`Zalo Mini App` in MVP; `WhatsApp Business` in v2) without installing the app.

**Consequences (testable):**
- Pay action completes within the messaging window; confirmation returns to both Parent and Tutor.

### 4.5 Parent Window (zero-install)

**Description:** The third window, delivered inside Zalo Mini App (VN) and WhatsApp Business (global). Parents see their child's schedule, attendance, and invoices; they never install the app. Realizes UJ-4. This is the VUS-proven engagement pattern (4× lead quality, +26pp interaction).

**Functional Requirements:**

#### FR-17: Read-Only Schedule and Attendance Visibility

A Parent linked to a Student can view that Student's Schedule Events and Attendance history in the messaging window.

**Consequences (testable):**
- View reflects live data (no stale cache >1 min after sync).
- A Parent sees only their own children (authorization enforced server-side).

#### FR-18: Notification Delivery via Zalo ZNS / WhatsApp Business API

The system delivers schedule-change, attendance, and invoice notifications through the messaging platform's official business APIs.

**Consequences (testable):**
- Notification delivery success rate and open rate are measurable per campaign.
- Opt-out is honored within the messaging platform's rules.

### 4.6 Small-Center Payroll and AI Reports (v2, roadmap P4)

**Description:** Expands the paid tier to small centers: payroll with VN PIT/BHXH split rules, and AI-drafted parent reports in Vietnamese delivered via Zalo. Also an AI timetable assistant that is reliable and explainable (explicitly avoiding MyStudyLife's broken-AI anti-pattern). Realizes UJ-5.

**Functional Requirements:**

#### FR-19: Center Payroll with VN Compliance

A Center can generate per-tutor payroll from session data with configurable pay rates and VN statutory split (PIT/BHXH) for staff vs. contractor flows.

**Consequences (testable):**
- Payroll output matches a reference calculation for staff vs. contractor cases.
- Payout initiation via MoMo Payroll API (T+0) is supported.

#### FR-20: AI Parent Reports (Vietnamese, Zalo-delivered)

The system drafts a short, honest parent report per student per period, in Vietnamese, delivered via Zalo, editable by the Tutor before send.

**Consequences (testable):**
- Draft is generated from attendance + package + notes data; a Tutor can edit before send.
- A report is never sent without an explicit tutor action (human-in-the-loop).

#### FR-21: Explainable AI Timetable Assistant

The system can propose timetable adjustments (conflict-free) with an explanation of why each proposal was made; a user accepts, rejects, or edits.

**Consequences (testable):**
- Every proposal carries a human-readable reason.
- Proposal acceptance is never automatic; no silent reordering.

**Out of Scope for v2:** autonomous AI scheduling without confirmation (MyStudyLife anti-pattern); AI handwriting grading (IntelGrader's category).

## 5. Non-Goals (Explicit)

- **We are not a marketplace** — no tutor discovery/search, no commission on lessons (unlike Preply, Wyzant, WeTeach). We manage, we don't broker.
- **We are not a K-12 school SIS** — no school-wide deployments, no Sở/Phòng reporting, no official school records.
- **We are not a generic booking tool** — no public booking pages, no appointment-only flows for non-education use.
- **We are not an LMS** — no course content, quizzes, or content delivery (LMS features stay out; we are scheduling + management).
- **We are not an AI-grading platform** — no handwriting OCR grading (IntelGrader's category).
- **We are not a payroll company** — we compute splits and initiate payouts via partners; we are not the processor of record.
- **v1 is not web-first** — the admin surface is mobile-first; a minimal web dashboard may follow in v2, never leading.

## 6. MVP Scope

### 6.1 In Scope (MVP = roadmap P1 + P2)

**Lead acquisition feature (priority 1 — phase-1 student objective is acquisition, decided 2026-08-21):**
- **Cú Chụp TKB** (photo-to-timetable): OCR import of VN paper timetables as an editable draft (FR-22), plus the schedule-sharing acquisition loop (FR-23).

**Required coupling (must ship with the lead feature):**
- Assignment/exam/deadline tracking (FR-8) — required in phase 1 because deadlines must be present in shared schedules (FR-23) to create learning context; not deferrable.

**Student core (supports the lead feature):**
- General schedule engine: typed events, flexible recurrence (A/B weeks), conflict detection, offline-first persistence with no-data-loss guarantee, reliable sync, reminders, widgets (FR-1 → FR-6).
- Student planner UX: timetable/agenda/month views, VN+EN localization, accessibility (FR-7).

**Monetization + parent (phase 1.5 / P2 — see note):**
- Role toggle + tutor mode: attendance (QR/manual), package tracking, session completion workflow, invite loop (FR-9 → FR-13).
- VN billing: VietQR invoices, MoMo/ZaloPay collection + reconciliation (FR-14, FR-15).
- Parent window: Zalo Mini App read-only schedule/attendance + payment (FR-16, FR-17), ZNS notifications (FR-18).

`[NOTE FOR PM]` Phase-1 student slice is acquisition-led (Cú Chụp TKB + engine + FR-8). Tutor mode, billing, and the parent window are listed here but sequenced after the student acquisition slice proves out; confirm the exact cut in planning.

### 6.2 Out of Scope for MVP (deferred to v2)

- Center payroll + AI reports + explainable AI timetable (FR-19 → FR-21) — deferred to roadmap P4. `[NOTE FOR PM]` Payroll is emotionally load-bearing for small centers; revisit if a center pilot emerges early.
- Calendar import (Google/Outlook) — v2. `[NOTE FOR PM]` A recurring early-user request; consider a lightweight CSV import sooner.
- WhatsApp Business window (global) — MVP ships Zalo (VN); WhatsApp follows in the global expansion phase.
- Web dashboard — v2.
- Multi-currency / non-VN payment rails — v2+.

## 7. Success Metrics

**Primary**

- **SM-1**: **Student D30 retention** — % of new students still active at day 30. Target: ≥35%. Validates FR-1–FR-8. Counter-metric SM-C1 guards against gaming.
- **SM-2a**: **Student→tutor invite** — % of active students who invite a tutor. Target: ≥8%. Validates FR-10.
- **SM-2b**: **Invited tutor→paid conversion** — % of invited tutors who enable paid Tutor mode within 30 days. Target: ≥25%. Validates FR-9–FR-13.
- **SM-3**: **Parent window engagement** — % of linked parents who open the Zalo Mini App within 7 days of link. Target: ≥40% (VUS baseline shows 41% interaction with Mini App + ZNS). Validates FR-16–FR-18.

**Secondary**

- **SM-4**: **Data-loss incidents** — count of user-reported data-loss events per 1,000 MAU. Target: 0 after GA (this is the trust metric that beats MyStudyLife). Validates FR-4, FR-5.
- **SM-5**: **Payment reconciliation rate** — % of invoices auto-reconciled without manual action. Target: ≥95%. Validates FR-14, FR-15.
- **SM-6**: **Crash-free sessions** — ≥99.5%. Validates the reliability NFR set.

**Counter-metrics (do not optimize)**

- **SM-C1**: **Session count / engagement depth** — do NOT optimize raw engagement minutes or event-creation volume; they reward friction and bloat, the MyStudyLife trap. Optimize retention and conversion instead.
- **SM-C2**: **Notification volume** — do NOT optimize total notifications sent; spam kills the messaging window. Optimize open rate and opt-out rate (<1% opt-out target).
- **SM-C3**: **Feature count / breadth** — do NOT optimize number of features shipped; the plan is explicitly an anti-bloat product.

## 8. Open Questions

1. Pricing for the Tutor tier: intent doc targets "below 149k–199k VND/mo, flat" — exact number and free-tier limits to decide before launch.
2. Whether the Parent window ships in the MVP release or the first follow-up (plan assumes MVP).
3. Solo-tutor invite: phone-number vs. Zalo handle resolution — which identifier is primary in VN launch.
4. Account model: anonymous offline-first → optional account for sync — confirm the exact upgrade prompt timing.
5. Center tier definition: minimum size, multi-tutor pricing, and whether Center billing needs separate invoicing in v1 or v2.

## 9. Assumptions Index

- §0 — Working title "ScheduleScope" is a placeholder; name to be confirmed. `[ASSUMPTION]`
- §2.1 — Students are the acquisition engine; tutors are the monetization engine. `[ASSUMPTION]`
- §2.2 — The three anti-targets (enterprise chains, K-12 SIS, pure booking, AI grading) remain out of scope through v2. `[ASSUMPTION]`
- §4.1 — Offline-first with per-field last-write-wins is sufficient conflict resolution for v1 (no collaborative multi-user editing of one schedule). `[ASSUMPTION]`
- §4.2 — Accessibility parity with Student Trove (CVD modes, text scaling) is the baseline bar. `[ASSUMPTION]`
- §4.3 — QR attendance uses a session token validated on later sync; acceptable for v1 (no live verification). `[ASSUMPTION]`
- §4.4 — PCI scope stays minimal via processor-hosted flows; we never handle card data. `[ASSUMPTION]`
- §4.5 — Zalo Mini App is the correct VN parent surface; WhatsApp Business is the global equivalent. `[ASSUMPTION]`
- §6.2 — Payroll/AI features are deferred to P4; if a center pilot appears early, revisit. `[ASSUMPTION]`
- §4.0/FR-22 — VN paper timetables are the dominant real-world import source for the target students, and OCR of a printed table (not handwriting) is feasible to ≥90% first-pass accuracy. `[ASSUMPTION]`
- §4.0/FR-23 — A share link with "value before ask" is sufficient to drive a self-sustaining acquisition loop; no external incentive (referral reward) is needed in v1. `[ASSUMPTION]`
- §4.0 — Deadlines present in a shared schedule are enough to create learning context that motivates recipients to import their own timetable (the reason FR-8 is required in phase 1). `[ASSUMPTION]`
- §7 — SM-1/SM-2/SM-3 targets are initial hypotheses to validate with the first cohort, not fixed commitments. `[ASSUMPTION]`