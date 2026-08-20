# Schedule Management — Mobile-First Student Life-Planner + Tutor Vertical

> Intent doc derived from brainstorming session `brainstorm-competitor-analysis-student-schedule-2026-08-20` (status: complete). Designed to feed directly into `bmad-product-brief` / `bmad-prd`.

---

## 1. Positioning Statement

A **mobile-first (Android + iOS, .NET MAUI) general-purpose schedule engine** for students — covering the *entire* student timetable (school classes, tutoring sessions, clubs, exams, assignment deadlines, personal plans) — with **tutoring management as one optional vertical layer** on the same engine. Students use it free as a reliable, offline-first life-planner; tutors and small centers pay for the management layer (attendance, package tracking, billing, payroll). Parents connect through **Zalo Mini App (VN) / WhatsApp (global)** with zero install.

**One engine. Two roles. Three windows.** No competitor occupies all three.

---

## 2. Competitor Landscape — Detailed Comparison Tables

### 2.1 B2C Student Planner Apps (App Store + Google Play) — DIRECT competitors

| App | Rating | Price | Offline | Sync | Known complaints (quoted) | What to LEARN | What NOT to COPY |
|---|---|---|---|---|---|---|---|
| **MyStudyLife** | 4.7★ | Free | ✅ | ❌ unreliable | **Data loss after 2024 redesign** ("schedule and all assignments... no longer there. Completely blank"); AI timetable glitchy; paywall creep ($50/yr); forced re-login; no time-of-day due times; color accessibility (yellow unreadable) | Cross-platform reach; free core; big feature set | Data-destroying redesigns; AI features shipped broken; paywalling core; forced logins; feature bloat that buries simple use |
| **iStudiez Pro** | — | Paid | — | — | **APP SHUT DOWN 2024–2026**; sync blocked UI on launch; no recurring assignments; no offline write-conflict handling | Was the "legendary" planner — its users are now orphaned and searching | Abandonment; sync that blocks the app; non-adaptive schedules |
| **Weeklie** | — | Free + one-time | ✅ | — | Minimal (pure timetable) | **Offline, no account required, A/B weeks up to 4-week cycles, Siri/Widget, one-time payment, no ads-subscription creep** | Staying timetable-only (no assignments/grades = weaker stickiness) |
| **myHomework** | 4.6★ | Free/$4.99yr | ✅ | — | Homework-focused only | Simple, cheap premium | Timetable weakness; no tutor/parent side |
| **Power Planner** | 4.5★ | $1.99 | ✅ | — | Dated UI | GPA calculator as engagement feature | Outdated design |
| **Student Trove** | 4.7★ | Freemium | ✅ | optional | Small (1K+ downloads); "keeps logging me out" | **Local-first encrypted storage; offline OCR smart import; attendance tracking; accessibility (4 CVD modes); university/high-school modes; 18 themes** | New/unproven at scale |
| **ClassUp (Schedule, Note)** | 4.3★ | Free | — | ❌ sync bugs | Black screen on signup; schedule appears only on first device; day-range bugs | — | Broken signup; unreliable cross-device sync |
| **Egenda / Smart Timetable / Class Timetable** | ~4.5★ | Free | — | — | Simple, feature-light | Simple onboarding | Feature-light (no lifecycle plan) |
| **Lịch Học (lichhoc.com.vn)** | VN | Free | — | — | Basic | **VN-native: timetable + flashcards + study groups in Vietnamese** | VN feature set still thin; no tutor/parent side |

**Group takeaway:** The category is **fragmented with no clear winner**; sync bugs and data-loss are the #1 recurring complaint. An app that is offline-first, never loses data, and syncs reliably wins by default.

---

### 2.2 Vietnam B2B Center-Management Tools — web-first incumbents (NOT direct competitors, but the monetization benchmark)

| Tool | Price (VND) | Mobile app? | Target | Weaknesses | What to LEARN | What NOT to COPY |
|---|---|---|---|---|---|---|
| **DotB EMS** | 39k/student/mo | Web + app | Centers 100+ | PC-first admin; feature-heavy (150+) | Depth: 150+ features, 40 reports; big-center credibility (POLY English 2,500 students) | Feature bloat; per-student pricing complexity |
| **Easy Edu** | ~60k/user/mo (2k/day) | ✅ iOS/Android | Centers 1,400+ | Financial-heavy | Financial management strength | Per-user pricing opacity |
| **PSE One** | 199k–1M/mo | Web + apps | Centers 1,000+ | Tiered pricing ladder | CRM/ERP breadth | Price ladder complexity |
| **Center Pro** | Free/199k/399k/599k/14.999k lifetime | Web + Zalo Mini App for teachers | Small-medium | — | **Zalo Mini App for teachers; lifetime option; free tier** | Confusing 5-tier pricing |
| **SMAS Viettel** | FREE for public schools | ✅ app | K-12 schools 20k+ | K-12 gov-focused | 250 features; scale | K-12 school-only focus (wrong buyer) |
| **MISA EMIS** | Contact-only (12M init) | Web + app | K-12 schools | Expensive, enterprise sales cycle | Institutional trust (MISA brand) | Enterprise pricing; sales-led onboarding |
| **iLeader** | From 45M VND | ✅ apps | Multi-vertical | **Very expensive for solo/small** | Full vertical coverage | Price; complexity |
| **Mona eLMS** | From 10M VND | ✅ apps | SMB centers | Slow support (complaints) | LMS + center mgmt combo | Support model; price floor |
| **DayTot** | 149k–499k/mo | Mobile-first | Solo teacher + center | New, smaller | **Solo teacher 149k/mo; 30-day trial; mobile-first** | Single-role focus (teacher only) |
| **LopHoc.app** | 990k–1.99M/yr | Mobile-first | Solo tutor | New | **AI + SePay QR; mobile-first solo tutor** | Price point (yr-only billing) |
| **ClassHub.io.vn** | — | iOS/Android | Centers | New (2026) | **QR attendance, tuition mgmt, AI assistant, mobile-first** | Unproven |
| **KLASSA (klassa.vn)** | Not public | — | Dạy-thêm centers 50+ | Price not public | Parent portal + LMS for dạy-thêm niche | Niche lock-in (tutoring centers only) |
| **GoEdu** | From 149k/mo | ✅ iOS/Android | — | — | Low entry price + mobile app | — |

**Group takeaway:** VN incumbents are **PC-first, expensive for solo/small operators (45M+ VND for iLeader), complex to onboard, with dated UI and vendor-dependent data export**. The 2024–26 entrants weaponize AI + Zalo OA + QR/face attendance + SePay/VietQR — validating our direction. **Pricing sweet spot for us: below 149k–199k/mo tier, flat and transparent.**

---

### 2.3 Global B2B Tutor Tools — web-only incumbents (the "no mobile" wedge)

| Tool | Price (USD) | Mobile app? | Billing model | Complaints | What to LEARN | What NOT to COPY |
|---|---|---|---|---|---|---|
| **TutorCruncher** | $30–240/mo + 3.85% card / 1% offline; +$50/branch | ❌ Web-only | % of revenue + base | "Not intuitive"; invoice editing causes double fees; reverts to Stripe; slow bug fixes; no workflow automation; English-only | Split-payment (tutor cut vs agency commission); ISO 27001 | %-of-revenue fees; complex UX; English-only; slow roadmap |
| **Teachworks** | $16.49/mo + $0.32/lesson | ❌ Web-only (mobile app request = **156 votes, "Not planned"**) | Per-lesson | **No mobile app (deliberate)**; English-only; 60+ add-ons paralysis; per-lesson fee scales unpredictably | Tutor management layer (schedule, hours, pay rates per tutor); 70+ integrations incl. QuickBooks | No mobile; add-on complexity; opaque scaling costs |
| **Classcard** | $99/199/349/mo flat (unlimited students) | ⚠️ Branded apps = **$249/mo ADD-ON** | Flat + processing fees | Mobile apps are an upsell, not included | **Flat pricing (transparent); family billing (siblings under one account); lead-to-enrolled single action; failed-payment retries** | Charging extra for mobile apps; requiring Growth/Business for basics like automations |
| **Tutorbase** | Free + 1% | ❌ Web-only | % of revenue | No mobile app at all | "Find Slot" AI suggestion; solo-tutor solutions | Web-only; % of revenue |
| **TutorBird** | $16.95/mo; free tier 10 students | ❌ Web-only | Flat | Web-only; slow feature requests; no multi-staff per appointment; single timezone; no split-parent billing | **Same-day setup speed; simple solo-tutor invoicing; free tier** | Ignoring community feature requests; single-timezone |
| **Oases** | $99–399/mo by student count (25–100+) | ⚠️ "Mobile Access" feature only | Flat by size | Tutors: "data entry not as straightforward on phones as web" | Student-count tiering; reporting depth | Mobile as afterthought; tier walls |
| **Wise** | $0.69/session | ✅ White-label iOS/Android apps | Per-session, 0% tx fee | — | White-label apps; automated tutor payouts; session-linked billing | Per-session pricing at scale |
| **Fons** | Custom | — | Flat/custom | — | Automated cancellation enforcement; recurring billing for independent tutors | Custom pricing opacity |

**Group takeaway:** **7/8 major global B2B tools are web-only.** Native mobile for tutor-side admin is the single biggest structural gap in the market. Also note: per-student/per-lesson/%-of-revenue pricing models all punish growth — flat transparent pricing is the differentiator.

---

### 2.4 Generic Booking Apps (used by tutors as workaround) — adjacent, incomplete

| Tool | What they lack for tutoring |
|---|---|
| Setmore, Calendly, Cal.com, Acuity, Skedda, Appointy, Square Appointments, SimplyBook.me, Fresha | No lesson packages / package-lesson decrement; no class-group management; no payroll; no parent portal; no attendance-per-student; no VN payment rails (VietQR/MoMo/ZaloPay). Booking ≠ teaching-business management. |

---

### 2.5 Mobile Booking/Marketplace Apps — broken mobile UX proof

| App | Rating | Problem |
|---|---|---|
| **Wyzant Tutor app** | 2.8★ Android | Buggy, slow, messages don't load; no offline note entry; broken address management; whiteboard desync; student list out of sync |
| **ClassUp / Cosmo (VN IELTS)** | 4.5★ | Branding confusion (two different ClassUps); cost shock complaints ($100/class, $1,500/mo) |
| **Preply (tutor side)** | — | Marketplace model, not management tool |

---

### 2.6 AI Feature Landscape — what exists vs. what's broken

| Capability | Existing | Verdict |
|---|---|---|
| AI timetable generation | MyStudyLife (glitchy, complained about); academic-scheduler.com; AIPCSS/ReSched (OSS); Oponeko | **Consumer-grade AI timetable = broken promise today** — reliability + explainability is a real wedge |
| AI parent reports | TutorLab, Studeia, iStarPal, Notie AI, Toddle, Tyb.ai | Real 2026 category — but **none target VN center→parent-Zalo flow** |
| AI scheduling / conflict resolution | Tutorbase "Find Slot"; Vi-Office AI 4-dim class placement (VN) | Nascent; no mobile-native option |
| Face-ID attendance | VNPT vnFace (20K schools, 6M students), SchoolX, VIETSCHOOL, KDI, Daytot, CenterUp | **Saturated for schools — NOT for tutoring centers / solo tutors** (our opening) |
| AI grading (handwriting OCR) | IntelGrader only | Category owner already exists — **anti-target** |

---

## 3. What to LEARN (copy the winners)

1. **Weeklie** — offline, no-account, one-time payment, no subscription creep. Dead-simple UX.
2. **Student Trove** — local-first encrypted storage, offline OCR smart import, accessibility (CVD modes), attendance tracking, high-school/university modes.
3. **Classcard** — flat transparent pricing, family billing under one account, lead→enrolled single action, failed-payment retries.
4. **TutorBird** — same-day setup speed, free tier, simple solo-tutor invoicing.
5. **VUS × Zalo** — Zalo Mini App + ZNS parent engagement (4× lead quality, +26pp interaction, −30% data-processing time). Parent portal on Zalo = zero-install.
6. **Center Pro / DayTot / LopHoc.app / ClassHub** — VN mobile-first entrants: Zalo Mini App for teachers, AI + SePay/VietQR, QR attendance, 30-day free trials, low entry price.
7. **MoMo Payroll API + VietQR (Tutor Pro OSS)** — T+0 payouts; VietQR-embedded PDF invoices.
8. **Face-ID attendance (Daytot/CenterUp)** — bring school-grade face-ID to the tutoring-center tier (under 2s recognition claims).
9. **Power Planner** — GPA/goal calculator as engagement hook.

## 4. What NOT to COPY (anti-patterns)

1. **MyStudyLife** — data-destroying redesigns; AI shipped broken; paywall creep; forced re-login; feature bloat.
2. **iStudiez Pro** — abandonment; sync blocking UI; no offline write-conflict handling.
3. **TutorCruncher** — %-of-revenue fees; non-intuitive UX; English-only; slow bug fixes.
4. **Teachworks** — "mobile app not planned" (156-vote request ignored); 60+ add-on paralysis; per-lesson pricing that surprises at scale.
5. **Classcard** — charging $249/mo extra for branded mobile apps (mobile is an upsell, not table stakes).
6. **Zalo-as-notification-only** — treating Zalo as a broadcast channel instead of the primary parent UX.
7. **PC-first admin** — VN incumbents' admin is desktop-bound; mobile admin is limited.
8. **Enterprise pricing + sales-led onboarding** — 45M+ VND iLeader, contact-only MISA: wrong for solo/small.
9. **Web-only everything** — the entire global B2B tier's cardinal sin.
10. **Per-student / per-lesson / %-of-revenue pricing** — all punish growth; opacity breeds churn.

## 5. Build Priority Order (each phase enables the next's growth loop)

| Phase | Scope | Why this order |
|---|---|---|
| **P1 — Student app core** | General schedule engine (typed events: school class, tutoring, club, exam, deadline, personal); offline-first with local encrypted storage; **no-data-loss guarantees**; reliable cross-device sync; simple UX; free; Vietnamese + English; widgets/reminders | Fastest to ship, lowest friction to download, daily-use stickiness; builds the user base that later invites tutors |
| **P2 — Tutor mode (same engine)** | Role-based toggle; attendance (QR/face-ID), package-lesson tracking, simple billing via **VietQR + MoMo/ZaloPay**, student-invite-tutor + tutor-invite-student loop | Monetization layer; rides the P1 user base; direct attack on web-only incumbents' weakness |
| **P3 — Parent channel** | **Zalo Mini App (VN) + WhatsApp Business (global)**: read-only schedule view, attendance alerts, payments, auto parent reports (AI, Vietnamese, ZNS-delivered) | Zero-install adoption; completes the student–tutor–parent triangle; VUS-proven engagement |
| **P4 — Small-center payroll + AI** | Tutor payroll with VN PIT/BHXH split; AI timetable that actually works (with explanation); conflict-resolution bot; WhatsApp/Zalo reminders | Expands TAM to small centers; AI as reliability + convenience, never shipped broken |

## 6. Distinctive Differentiators (what makes us win)

1. **One engine, two roles, three windows** — general schedule core + tutor vertical + Zalo/WhatsApp parent channel. No competitor spans all three.
2. **Offline-first reliability** — works on intermittent 3G/trains (proven demand: Zegju enrolled half of Ethiopia's freshmen going offline-first); never loses data (MyStudyLife's worst sin).
3. **Tam giác student–tutor–parent on one thread** — one shared schedule reality, three tailored surfaces.
4. **Zalo-native parent channel** — zero-install Mini App (VUS: 4× lead quality); incumbents use Zalo as notification, not UX.
5. **VN payment rails built-in** — package decrement → VietQR invoice → MoMo/ZaloPay T+0 reconciliation → tutor payroll split (PIT/BHXH). No competitor unifies these.
6. **Flat transparent pricing** — students free forever (core); tutor tier below the 149k–199k VND/mo market floor, flat (vs per-student/per-lesson/%-of-revenue opacity).
7. **No paywall creep** — core stays free and complete (vs MyStudyLife's $50/yr wall).

## 7. Anti-Targets (do NOT compete here)

- **Enterprise tutoring chains >50 tutors** — TutorCruncher, Wise, Alinaflow own this.
- **K-12 school-wide face-ID attendance** — VNPT vnFace (20K schools), SchoolX, VIETSCHOOL saturated.
- **AI handwriting grading** — IntelGrader's category; hard entry.
- **Generic booking** — Calendly/Setmore/Square own pure booking; we don't fight them head-on.

---

## 8. Key Numbers Cheat-Sheet (for PRD/positioning use)

- **VN tutor-tier price floor:** 149k–199k VND/mo (DayTot, GoEdu entry); incumbents up to 45M VND (iLeader) or 1M/mo (PSE One)
- **Global:** TutorBird $16.95/mo → TutorCruncher $30–240 + fees → Classcard $99 flat
- **Mobile apps:** 7/8 global B2B tools web-only; Classcard charges $249/mo for branded apps
- **Zalo:** ~80M users; Mini App + ZNS = 4× lead quality, +26pp interaction (VUS)
- **Face-ID:** VNPT vnFace 20K schools / 6M students — saturated in schools, open in tutoring tier
- **iStudiez Pro:** shut down → orphaned user base looking for a reliable replacement
- **MyStudyLife:** data-loss redesign complaints = the cautionary tale for reliability