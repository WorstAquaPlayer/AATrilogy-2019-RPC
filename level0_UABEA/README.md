# level0_UABEA
Simply open the **level0** file in the game's **PWAAT** folder, then replace the assets dump's with the files here. To know which one to replace, check the "Path ID" at the end of the file's name and find it in UABEA. The "File ID" is **always** 0, so be careful when looking for the "Path ID".
## Sub-folders
They're separated to organize it a bit better, but they both follow the same procedure. In the "Assets Info" window in UABEA, go to *File -> Add* and add every file in each folder and insert the corresponding dump.<br />
To know what **"Path ID"** to add, simply check the first number in the file's name.
To know what to put in **"Type name/ID"**, simply add the name after the second number in the file's name.<br />
For example, if the file's name is: *3221-1441-SpriteRenderer.json*, then the "Path ID" to add is **3221**, and the "Type name/ID" is **SpriteRenderer**.<br />
If the file's name says **"MonoBehaviour"**, then the "Type name/ID" field is always 114, and the "Mono class ID" is the last number in the file's name.<br />
For example, if the file's name is: *3170-2844-MonoBehaviour optionWindow(114-34).txt*, then the "Path ID" to add is **3170**, the "Type name/ID" is **114**, and the "Mono class ID" is **34**.<br />
