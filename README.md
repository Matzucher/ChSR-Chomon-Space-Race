# ChSR-Chomon Space Race

# Jak ustawić Visual Studio 2022 aby kompilowało godota
 - pobierz "GodotAddinVS.vsix" z https://github.com/godotengine/godot-csharp-visualstudio/releases , a następnie zainstaluj 
 - (jeśli jeszcze tego nie zrobiłeś) pociągnij zmiany z projektu
 - odpal ChomonSpaceRace.sln w Visual Studio 2022
 - klikamy prawym na folder projektu (nie rozwiązania)
 - Wchodzimy w Properties->Debuger->General->Open Debug Lunch Profile UI
 - po otwarciu okna wybieramy "Start in Godot"
 - nastepnie zmieniamy ścierzkę "Executable" na swoją ścierzkę do "godot.windows.editor.double.x86_64.mono.exe"
 - zamykamy okno i możemy spróbować odpalić projekt w Visualu. Breakpointy też powinny działać
