# PRD Quality Review — Schedule Management (Mobile Student Life-Planner with Tutor Vertical)

## Overall verdict
The PRD is decision-ready and strategically coherent: it has a clear thesis (one engine, two roles, three windows), FRs with testable consequences, honest scope boundaries, and counter-metrics that guard the anti-bloat intent. The main risk is assumption density around monetization and the MVP parent-window scope — both flagged as `[ASSUMPTION]`/`[NOTE FOR PM]` honestly. Substance is earned from the competitive analysis; the shape fits the consumer multi-stakeholder product.

## Decision-readiness — strong
Trade-offs are named with what was given up (e.g. §4.3 notes the student UI never shows management controls; §6.2 defers payroll with a NOTE FOR PM). Open Questions are genuinely open (pricing number, identifier choice, account-prompt timing). The thesis decision — students free, tutors paid, parents zero-install — is stated as a decision, not a consideration.

### Findings
- **[medium]** (§2.1) Tutor JTBD says "get paid without chasing invoices" but monetization mechanics (who pays, what unlocks) live only in §6.1/§7. *Fix:* add one line in §2.1 Tutor JTBD pointing to the paid tier boundary.

## Substance over theater — strong
Personas (Linh, Mr. Minh, Ms. Hoa, Ms. Trang) each drive journeys that map to distinct FRs; none are furniture. The "no-data-loss guarantee" is a real differentiator tied to a measured SM-4, not boilerplate. NFRs carry thresholds (cold start <1.5s, widget ≤1% battery, sync <5s) rather than adjectives. Anti-targets are grounded in named competitors (TutorCruncher, vnFace, IntelGrader).

### Findings
- **[low]** (§4.1 FR-6) Widget NFR "must not exceed 1% battery/day" is specific but measurement method unstated. *Fix:* add "measured via Android battery stats / iOS Energy Impact over 7-day cohort."

## Strategic coherence — strong
The thesis is a single bet: own the shared schedule reality across the student–tutor–parent triangle. Feature priority follows the roadmap (engine → student UX → tutor mode → billing → parent window), and each phase's growth loop is named in the intent doc this PRD builds on. SMs validate the thesis (retention, tutor conversion, parent engagement), and three counter-metrics explicitly block the bloat/engagement-gaming trap — a genuine tell of coherent thinking.

### Findings
- **[medium]** (§7) SM-2 mixes two different conversion rates (students inviting AND tutors converting) into one metric ID. *Fix:* split into SM-2a (student→invite) and SM-2b (invited tutor→paid) for clean attribution.

## Done-ness clarity — strong
Every FR (FR-1..FR-21) has at least one testable consequence. Notable: FR-4's data-integrity invariant is testable ("forced-kill mid-sync leaves local data intact"), FR-2's A/B-week override is testable, FR-19's payroll is testable against a reference calculation. No "handles gracefully" or "user-friendly" language.

### Findings
- **[low]** (§4.1 FR-3) Conflict detection consequence says "produces an explicit conflict card" but the resolution UX (keep/reschedule options) is described in the FR body, not the consequence. *Fix:* fold the resolution choice into the consequence so it's independently verifiable.

## Scope honesty — strong
Non-Goals are explicit and load-bearing (six "we are not X" statements). Out-of-MVP items carry reasons and two `[NOTE FOR PM]` callouts on emotionally load-bearing deferrals (payroll, calendar import). Ten assumptions are tagged and indexed; Open Questions are real. De-scoping is proposed, not silent.

### Findings
- **[medium]** (§6.2) WhatsApp parent window deferred to v2 but §4.5/FR-17 describe it as if in MVP; the FR text says "Zalo Mini App (VN) and WhatsApp Business (global)" without scope marking. *Fix:* annotate FR-16/FR-17 with the MVP scope marker `(MVP: Zalo only)`.

## Downstream usability — strong
Glossary (8 terms) anchors all FRs and journeys; terms are used consistently (Schedule Event, Event Type, Tutoring Session, Package, Window). IDs are contiguous (FR-1..FR-21, UJ-1..UJ-5, SM-1..SM-6, SM-C1..SM-C3) with resolving cross-references. UJs have named protagonists with inline context. Each section reads standalone.

### Findings
- **[low]** (§4.4) FR-14/FR-15 reference "Parent's messaging window" and "reconciliation" but never the Glossary term `Invoice` for the payment link. *Fix:* use `Invoice` and `Package` terms explicitly in FR-15 consequences.

## Shape fit — strong
Consumer, multi-stakeholder product: UJs with named protagonists are load-bearing and correctly shaped (entry state, path, climax, resolution, edge case). The role-toggle architecture is reflected in the feature grouping. Not over-formalized — journeys are narrative-first, not flowcharts.

## Mechanical notes
- Glossary drift: none found; "window" used consistently with its Glossary definition (three windows = Student app, Tutor mode, Parent window).
- ID continuity: FR-1..FR-21 contiguous; UJ-1..UJ-5 contiguous; SM set contiguous. Cross-references resolve (UJ citations in FRs match journey numbering).
- Assumptions Index roundtrip: 10 inline `[ASSUMPTION]` tags, all indexed in §9; index entries all appear inline. ✓
- UJ protagonist naming: all 5 UJs have named protagonists (Linh, Linh, Mr. Minh, Ms. Hoa, Ms. Trang).
- Required sections present for launch stakes: Vision, Target User with UJs, Glossary, Features with FRs, Non-Goals, MVP Scope, Success Metrics with counter-metrics, Open Questions, Assumptions Index. Cross-cutting NFRs live inline per-feature and in the counter-metrics; a standalone NFR section is optional at this stake level given the per-FR thresholds.