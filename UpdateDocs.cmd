dotnet tool install -g XMLDoc2Markdown
dotnet build
xmldoc2md Src\bin\Debug\net8.0\Webmaster442.WindowsTerminal.dll --output docs --github-pages --back-button