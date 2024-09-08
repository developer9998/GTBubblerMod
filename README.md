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

### Use Vibrations

The Use Vibrations config will determine if the Bubbler cosmetic will vibrate the controller when activated.

## Usage

**GTBubblerMod** is used when a Bubbler cosmetic is activated, where a "loop audio" is played and modified by the mod, the mod will do the same if a "pop audio" exists.

## Table
This is a table consisting of all Bubbler cosmetics in Gorilla Tag as of September 2024.
| Icon | Name | ID | Loop Audio  | Pop Audio |
| ---- | ---- | -- | ----------- | --------- |
| <img src="https://github.com/developer9998/GTBubblerMod/blob/main/CosmeticSprites/bubbler.png" width=80px height=auto> | Bubbler | LMAAM. | ✔ | ✔ |
| <img src="https://github.com/developer9998/GTBubblerMod/blob/main/CosmeticSprites/SnowBlowerSprite.png" width=80px height=auto> | Snow Blower | LMADH. | ✔ | ✔ |
| <img src="https://github.com/developer9998/GTBubblerMod/blob/main/CosmeticSprites/DrillSprite.png" width=80px height=auto> | Hand Drill | LMAFO. | ✔ | ❌ |
| <img src="https://github.com/developer9998/GTBubblerMod/blob/main/CosmeticSprites/RayGunToySprite.png" width=80px height=auto> | Toy Ray Gun | LMAHU. | ✔ | ❌ |
| <img src="https://github.com/developer9998/GTBubblerMod/blob/main/CosmeticSprites/FireExtinguisherSprite.png" width=80px height=auto> | Fire Extinguisher | LMAIH. | ✔ | ❌ |
| <img src="https://github.com/developer9998/GTBubblerMod/blob/main/CosmeticSprites/FlameThrowerSprite.png" width=80px height=auto> | Flame Thrower | LMAII. | ✔ | ❌ |
| <img src="https://github.com/developer9998/GTBubblerMod/blob/main/CosmeticSprites/GunGlitterSprite.png" width=80px height=auto> | Glitter Gun | LMAJU. | ✔ | ❌ |
| <img src="https://github.com/developer9998/GTBubblerMod/blob/main/CosmeticSprites/LightShowToySprite.png" width=80px height=auto> | Lightshow Toy | LMAKX. | ✔ | ❌ |

## Format
This is the format used for Bubble cosmetic configuration, replace ``{Name}`` and ``{ID}`` with data for the cosmetic.
```
[{Name} ({ID})]

## Audio path for the looped bubbler sound
# Setting type: String
# Default value: 
Audio Loop Path = 

## Audio volume for the looped bubbler sound
# Setting type: Single
# Default value: 1
# Acceptable value range: From 0 to 1.5
Audio Loop Volume = 1

## Whether the looped bubbler sound will resume after being stopped
# Setting type: Boolean
# Default value: true
Retain Loop Time = true

## Audio path for the bubbler pop sound
# Setting type: String
# Default value: 
Audio Pop Path = 

## Audio volume for the bubbler pop sound
# Setting type: Single
# Default value: 1
# Acceptable value range: From 0 to 1.5
Audio Pop Volume = 1

## Whether the bubbler will vibrate the controller when active
# Setting type: Boolean
# Default value: true
Use Vibrations = true
```

## Disclaimer
***This product is not affiliated with Gorilla Tag or Another Axiom LLC and is not endorsed or otherwise sponsored by Another Axiom LLC. Portions of the materials contained herein are property of Another Axiom LLC. © 2021 Another Axiom LLC.***
