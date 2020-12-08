# RimWorld-LanguageWorker_Portuguese
![]( https://raw.githubusercontent.com/wiki/b606/RimWorld-LanguageWorker_Portuguese/images/LWKR_Portuguese_Mod_banner.png)

A mod to make the Portuguese language in RimWorld as grammatically correct as possible.

Credits:

 - Modified from https://github.com/b606/RimWorld-LanguageWorker_French, which idea originated from Elevator89's LanguageWorker.
 - Include some code snippets from the official LanguageWorker_Portuguese and translators work.
 - Thanks to Pardeike for his fabulous libHarmony patching library.

### 1. Goal
 - Maintain the Portuguese RimWorld Translation at maximum quality.
 - Make the Portuguese LanguageWorker in RimWorld at maximum quality.
 - Testbed for the Portuguese LanguageWorker in RimWorld.

### 2. Features

This mod improves the grammar and typography rules specific to the target language in RimWorld, which are impossible to implement without modifying the C# code built in the game. It is a complement to the translators work at https://github.com/Ludeon/, until the patches that it introduces will be obsoleted by some future version of RimWorld.

This mod does not add more translation, so you need to get your language translation as complete and as updated as possible.

The mod is also designed to be as independent as possible and does not require any modification or special annotations in the official translation.It should not theoretically interfere with any other mods, it should work on any saved game, and can be activated or deactivated at will.

**Features list:**

- Fix plurals for single words. The list of exceptions to plurals such as irregular, foreign words, and invariants needs to be updated when needed (WIP). Plurals for compound or hyphenated words is also a WIP (Portuguese speaking testers needed.)
- Many contractions: `{de|em|por|a|para|com} {article|pronoun}`, ex. `dele|dela|...|do|da|dum` etc., `nele|nela|...|no|na|num` etc., and so on. These will be activated automatically where the official translation files use the tags {X_indefinite}, {X_definite}, {X_pronoun} or {X_objective}.
- Tribal pawns, cities and towns, factions and geographical features get proper uppercase.
- Quest titles get specialized uppercase algorithm (WIP, adapt to the cultural practice).
- (*)Epicene animals: the mod defines male only or female only animal labels. As of now, it appends a gender qualification to the generic label, ex. "a gazela", "a gazela macho" or "o rhinoceros fêmea". When the animal is tamed and named, the gender revert back to the physical gender.Please, advise if this behaviour is inappropriate. These will be activated automatically where the official translation files use the tags {X_label}, {X_indefinite}, {X_definite}. The tags {X_gender}, {X_pronoun} and {X_objective} change accordingly. NB: This is for single animal only, generic animal label (XXX_kindLabel) must be handled correctly in the official translation files.
- (*)Possessive pronoun depends on the object (possessed) gender, not the subject (possessor) gender. So for example, in order to translate "[INITIATOR_possessive] [TOOL_label]", one should use "[TOOL_possessive] [TOOL_label]". The mod adds keys for possessive plural "seus" and "suas". Then {X_possessive} should resolve to "sues" or "suas" if the word is categorized in is classified in WordInfo/Gender/{Male,Female}.txt. The bash script in `Notes/scripts/update-wordinfo.sh` can automatically extract most of the labels in the game.
- WIP: other contractions and elisions are not implemented (the portuguese language has many of them, native speaking testers can ask if more is needed)

My Portuguese speaking level is less than zero so I need testers to verify the correctness of what is implemented and to define the area of improvement. Please check the opened issues if one is related to your subject. Also, please feel free to submit suggestions and bug reports.

Features marked with (*) cannot be implemented in the vanilla LanguageWorker_Portuguese and require the provided patches or modification of the RimWorld built-in grammar engine.

### 3. Installation

- **Not yet on Steam Workshop**,

- or **download the zip archive** (https://github.com/b606/RimWorld-LanguageWorker_Portuguese/releases/latest), and extract it in the Mods folder of RimWorld, generally:

    - on Windows : `C:\Program Files (x86)\Steam\steamapps\common\RimWorld\Mods\LanguageWorker_Portuguese_Mod`
    - on Linux : `~/.steam/steam/steamapps/common/RimWorld/Mods/LanguageWorker_Portuguese_Mod`
    - on Mac : go to Finder, select `~/Library`, Application Support, Steam, SteamApps, Common, Rimworld, RimWorldMac, right-clic and "Show package contents" (https://ludeon.com/forums/index.php?topic=3549.msg468403#msg468403).

![]( https://raw.githubusercontent.com/wiki/b606/RimWorld-LanguageWorker_Portuguese/images/LWKR_Portuguese_Mod_folders.png)


### 4. Changelog

2020/11/06.
  - Initial release.

2020/11/30.
  - Initial commit.

### 5. Work in progress

  - Any suggestion is welcome.
 
---
[![ko-fi](https://www.ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/Z8Z51KQ21)
