dotnet tool install -g XMLDoc2Markdown
dotnet build
xmldoc2md bin\Debug\net8.0\Webmaster442.WindowsTerminal.dll --output docs --back-button
xmldoc2md bin\Debug\net8.0\Webmaster442.WindowsTerminal.Sixel.dll --output docs\Sixel --back-button