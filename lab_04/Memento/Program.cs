using Memento;

var editor = new TextDocument();
var history = editor.GetHistory();

editor.WriteText("First row. ");
history.Backup(editor.Save());

editor.WriteText("Second row. ");
history.Backup(editor.Save());

editor.WriteText("Third row. ");
editor.ShowCurrentDocument();

Console.WriteLine("\nRestoring history<<<");
editor.Undo();
editor.ShowCurrentDocument();

Console.WriteLine("\nRestoring history<<<");
editor.Undo();
editor.ShowCurrentDocument();

Console.WriteLine("\nRestoring history<<<");
editor.Undo();