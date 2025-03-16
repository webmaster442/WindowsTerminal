[`< Back`](./)

---

# TerminalCommand

Namespace: Webmaster442.WindowsTerminal

Represents a terminal command

```csharp
public sealed class TerminalCommand
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [TerminalCommand](./webmaster442.windowsterminal.terminalcommand.md)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Fields

### **Quit**

This closes all open terminal windows. A confirmation dialog will appear in the current window to ensure you'd like to close all windows.

```csharp
public static TerminalCommand Quit;
```

### **CloseWindow**

This closes the current window and all tabs within it.

```csharp
public static TerminalCommand CloseWindow;
```

### **OpenSystemMenu**

Opens the system menu at the top left corner of the window.

```csharp
public static TerminalCommand OpenSystemMenu;
```

### **toggleFullscreen**

This allows you to switch between full screen and default window sizes.

```csharp
public static TerminalCommand toggleFullscreen;
```

### **ToggleFocusMode**

This allows you to enter "focus mode", which hides the tabs and title bar.

```csharp
public static TerminalCommand ToggleFocusMode;
```

### **ToggleAlwaysOnTop**

This allows you toggle the "always on top" state of the window. When in "always on top" mode, the window will appear on top of all other non-topmost windows.

```csharp
public static TerminalCommand ToggleAlwaysOnTop;
```

### **CloseOtherTabs**

This closes all tabs except for the one at an index. If no index is provided, use the focused tab's index.

```csharp
public static TerminalCommand CloseOtherTabs;
```

### **CloseTabsAfter**

This closes the tabs following the tab at an index. If no index is provided, use the focused tab's index.

```csharp
public static TerminalCommand CloseTabsAfter;
```

### **DuplicateTab**

This makes a copy of the current tab's profile and directory and opens it. This does not include modified/added ENV VARIABLES.

```csharp
public static TerminalCommand DuplicateTab;
```

### **NextTab**

This opens the tab to the right of the current one.

```csharp
public static TerminalCommand NextTab;
```

### **PrevTab**

This opens the tab to the left of the current one.

```csharp
public static TerminalCommand PrevTab;
```

### **ToggleBroadcastInput**

This command will toggle "broadcast mode" for a pane. When broadcast mode is enabled, all input sent to the pane will be sent to all panes in the same tab. This is useful for sending the same input to multiple panes at once.
 As with any action, you can also invoke "broadcast mode" by search for "Toggle broadcast input to all panes" in the Command palette.

```csharp
public static TerminalCommand ToggleBroadcastInput;
```

### **showContextMenu**

This command will open the "right-click" context menu for the active pane. This menu has context-relevant actions for managing panes, copying and pasting, and more.

```csharp
public static TerminalCommand showContextMenu;
```

## Methods

### **SendInput(String)**

Send arbitrary text input to the shell. As an example the input "text\n" will write "text" followed by a newline to the shell.
 ANSI escape sequences may be used, but escape codes like \x1b must be written as \u001b. For instance "\u001b[A" will behave as if the up arrow button had been pressed.

```csharp
public static TerminalCommand SendInput(string input)
```

#### Parameters

`input` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The text input to feed into the shell.

#### Returns

[TerminalCommand](./webmaster442.windowsterminal.terminalcommand.md)<br>
A command that sends text input to the shell.

### **AdjustOpacity(Int32, Nullable&lt;Boolean&gt;)**

This changes the opacity of the window. If relative is set to true, it will adjust the opacity relative to the current opacity. Otherwise, it will set the opacity directly to the given opacity

```csharp
public static TerminalCommand AdjustOpacity(int opacity, Nullable<bool> relative)
```

#### Parameters

`opacity` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
How opaque the terminal should become or how much the opacity should be changed by, depending on the value of relative

`relative` [Nullable&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
If true, then adjust the current opacity by the given opacity parameter. If false, set the opacity to exactly that value.

#### Returns

[TerminalCommand](./webmaster442.windowsterminal.terminalcommand.md)<br>
A command that adjusts opacity

### **SetColorScheme(String)**

Changes the active color scheme.

```csharp
public static TerminalCommand SetColorScheme(string scheme)
```

#### Parameters

`scheme` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the color scheme to apply.

#### Returns

[TerminalCommand](./webmaster442.windowsterminal.terminalcommand.md)<br>

---

[`< Back`](./)
