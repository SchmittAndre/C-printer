/*
 * Erstellt mit SharpDevelop.
 * Benutzer: schmitta
 * Datum: 19.01.2017
 * Zeit: 08:17
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
using System;

namespace Fileobserver
{
  
using System;
using System.IO;
public class TxtWatcher {
static void Main() {
string dirname = @"D:\unterordner";
FileSystemWatcher watcher = new FileSystemWatcher(dirname);
// Zu Überwachen: Ändern und Umbenennen von Dateien
watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName;
// Filter für Dateinamen
watcher.Filter = "*.txt";
// Ereignisbehandlungsroutinen registrieren
watcher.Changed += new FileSystemEventHandler(FsoChanged);
watcher.Created += new FileSystemEventHandler(FsoChanged);
watcher.Deleted += new FileSystemEventHandler(FsoChanged);
watcher.Renamed += new RenamedEventHandler(FsoRenamed);
// Überwachung aktivieren
watcher.EnableRaisingEvents = true;
Console.WriteLine("TxtWatcher gestartet. Beenden mit 'q' + Enter\n");
Console.WriteLine("Überwachter Ordner: "+dirname+"\n");
ConsoleKeyInfo cki;
do
cki = Console.ReadKey(true);
while (cki.KeyChar != 'q');
}
// Ereignisroutinen implementieren
static void FsoChanged(object source, FileSystemEventArgs e) {
Console.WriteLine("Datei: " + e.Name + " " + e.ChangeType);
}
static void FsoRenamed(object source, RenamedEventArgs e) {
Console.WriteLine("Datei: {0} umbenannt in {1}", e.OldName, e.Name);
}
}

}