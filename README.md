# GTBubblerMod

**GTBubblerMod** is a mod for Gorilla Tag that customizes Bubbler cosmetic sounds, like the audio that is played and the volume of the audio.

## Config

**GTBubblerMod** can be configured through the "dev.gtbubblermod.cfg" file in the config folder for BepInEx.

### Audio Path

The Audio Path config is relative to the mod. If you have an audio named "Pop.wav" in the same folder as the mod that you wanted to use as the pop sound, you would set the config to that.

### Audio Volume

The Audio Volume config is ranged from a number value from 0 (0%) to 1.5 (150%) volume, a volume set over 1 (100%) may diminish audio quality.

### Retain Loop Time

The Retain Loop Time config will retain the timestamp of a looped audio when the Bubbler cosmetic is no longer activated, making the audio not restart each time after the cosmetic is activated.

## Usage

**GTBubblerMod** is used when a Bubbler cosmetic is activated, where a "loop audio" is played and modified by the mod, the mod will do the same if a "pop audio" exists.

## Table
This is a table consisting of all Bubbler cosmetics in Gorilla Tag as of September 2024.
| Name | ID   | Loop Audio  | Pop Audio |
| ---- | ---- | ----------- | --------- |
| Bubbler | LMAAM. | True | True |
| Snow Blower | LMADH. | True | True |
| Hand Drill | LMAFO. | True | False |
| Toy Ray Gun | LMAHU. | True | False |
| Fire Extinguisher | LMAIH. | True | False |
| Flame Thrower | LMAII. | True | False |
| Glitter Gun | LMAJU. | True | False |
| Lightshow Toy | LMAKX. | True | False |

## Disclaimer
This product is not affiliated with Gorilla Tag or Another Axiom LLC and is not endorsed or otherwise sponsored by Another Axiom LLC. Portions of the materials contained herein are property of Another Axiom LLC. © 2021 Another Axiom LLC.
