# DIALOGUE TOOL by Pabron

***

A tool that helps developers create dialogues/stories in their games. 

> Is it a non-coding tool?
> NO!

> Is it simple enough for non-coders?
> YES!!

---

### INSTRUCTIONS

1. Attach 'DialogueManager' script into the desired game component. Suggested naming: _DialogueManager_
2. Place your UI elements (UI objects, Text, Button, etc.) into required fields in DialogueManager Inspector.
3. Declare new public variables in _<DialogueEntry>_ types
4. Enter your entries in a linear way.
5. Lastly, call your dialogues/stories through _CallDialogue(bool isFullscreen, List<DialogueEntry> dialogue)_ format.

### HOW DOES IT WORK?

It reads your dialogue entries in order & replaces your UI elements. When it reaches the end of your dialogues, it automatically closes the dialogue elements.