csc /target:library /out:Calc.dll Simple.cs Complex.cs
csc /target:exe /reference:Calc.dll mainCalc.cs
WP1.exe