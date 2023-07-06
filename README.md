
# AATrilogy-2019-RPC
This mod adds **Discord RPC** to the game **"Phoenix Wright: Ace Attorney Trilogy".**<br  />
This is achieved by using the game's code to retrieve the strings seen in the Save/Load menu, which means the text is localized to the language you're playing on.<br  />
In addition to the text, the logo also changes depending on if you're playing one of these languages: Japanese, Korean, Chinese (Simplified) or Chinese (Traditional). This is due to the fact that these languages have unique logos for each game.

## Installation
Simply [download the latest release](https://github.com/WorstAquaPlayer/AATrilogy-2019-RPC/releases/latest/download/AATrilogy-RPC.zip), and extract the contents into the game's root folder.
### IMPORTANT:
This mod is meant to be installed in clean copies of the game, so if you have a mod that modifies the files **PWAAT_DATA/level0**, **PWAAT_DATA/Managed/Assembly-CSharp.dll** or any of the **PWAAT_Data/StreamingAssets/menu/text/option_text\*.bin** and **PWAAT_Data/StreamingAssets/menu/text/title_text\*.bin** files, this will replace those files and probably break the other mod.

## Usage
Once the mod is installed, a new option is added in the options menu, simply called Discord RPC.
By default, it's set to *Off*, but you can set it to *Simple* or *Detailed*.
### Simple and Detailed differences:
| Simple | Detailed | Detailed (Language Example) |
|--|--|--|
| ![simple](https://github.com/WorstAquaPlayer/AATrilogy-2019-RPC/assets/25833407/332d429f-97e5-44ca-ac20-892d94190850) | ![detailed](https://github.com/WorstAquaPlayer/AATrilogy-2019-RPC/assets/25833407/26788dd0-d489-4e6d-8346-ed524b81263f) | ![detailed_jp](https://github.com/WorstAquaPlayer/AATrilogy-2019-RPC/assets/25833407/a241621f-85de-4127-bd30-25bc40c65aa6) |

## "Building"
Since this is a mod, there's no actual way to "build" this in the traditional way. To compensate that fact, this repository contains the sources of how I achieved this, along with explanations to do so.
### Folder contents
-  **dnSpyEx_Changes:** To modify the game's **Assembly-CSharp.dll**, I used [dnSpyEx v6.4.0](https://github.com/dnSpyEx/dnSpy/releases/tag/v6.4.0). To get more details into what files are modified and in what order, enter the folder and read the *README* in there.
-  **level0_UABEA:** To modify the game's **level0** file, I used [UABEA v6](https://github.com/nesrak1/UABEA/releases/tag/v6). To get more details into what files are modified and added, enter the folder and read the *README* in there.
-  **InGame_Text:** Contains the source of the modified text files that are located in the game's **PWAAT/StreamingAssets/menu/text** folder. The tool used to recompile the text is currently private, but when it's public I'll include it here.
-  **option_window:** Contains the source image for the file **option_window_new.unity3d** that is included in the mod. The file was done using **Unity 2017.4.8f1**.
-  **RPC_Assets:** Art Assets for the Discord RPC application. If you were to modify the images used in the RPC, or simply change the application name, you'll need to do a new application in the Discord Developer Portal, and include these assets if you need to.

## discord-rpc.dll License
```
Copyright 2017 Discord, Inc.

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
of the Software, and to permit persons to whom the Software is furnished to do
so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```
