#!/bin/bash
echo Game logic:
find Assets/Roots -name '*.cs' | sed 's/.*/"&"/' | xargs  wc -l | grep total

#echo HexLib:
#find Assets/Plugins/HexLib -name '*.cs' | sed 's/.*/"&"/' | xargs  wc -l | grep total
#echo Localization plugin:
#find Assets/Plugins/Localization -name '*.cs' | sed 's/.*/"&"/' | xargs  wc -l | grep total
#echo Other utils:
#find Assets/Plugins/Utils -name '*.cs' | sed 's/.*/"&"/' | xargs  wc -l | grep total