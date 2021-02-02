using System.Reflection;
using System.Runtime.CompilerServices;

//
// Allgemeine Informationen Ã¼ber eine Assembly werden Ã¼ber folgende Attribute 
// gesteuert. Ã„ndern Sie diese Attributswerte, um die Informationen zu modifizieren,
// die mit einer Assembly verknÃ¼pft sind.
//
[assembly: AssemblyTitle("SimPE Database")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Ambertation")]
#if DEBUG
[assembly: AssemblyProduct("[DEBUG]")]
#else
	[assembly: AssemblyProduct("")]
#endif

//
// Versionsinformationen fÃ¼r eine Assembly bestehen aus folgenden vier Werten:
//
//      Hauptversion
//      Nebenversion 
//      Buildnummer
//      Revision
//
// Sie kÃ¶nnen alle Werte oder die standardmÃ¤ÃŸige Revision und Buildnummer 
// mit '*' angeben:

[assembly: AssemblyVersion("1.0.*")]

//
// Um die Assembly zu signieren, mÃ¼ssen Sie einen SchlÃ¼ssel angeben. Weitere Informationen 
// Ã¼ber die Assemblysignierung finden Sie in der Microsoft .NET Framework-Dokumentation.
//
// Mit den folgenden Attributen kÃ¶nnen Sie festlegen, welcher SchlÃ¼ssel fÃ¼r die Signierung verwendet wird. 
//
// Hinweise: 
//   (*) Wenn kein SchlÃ¼ssel angegeben ist, wird die Assembly nicht signiert.
//   (*) KeyName verweist auf einen SchlÃ¼ssel, der im CSP (Crypto Service
//       Provider) auf Ihrem Computer installiert wurde. KeyFile verweist auf eine Datei, die einen
//       SchlÃ¼ssel enthÃ¤lt.
//   (*) Wenn die Werte fÃ¼r KeyFile und KeyName angegeben werden, 
//       werden folgende VorgÃ¤nge ausgefÃ¼hrt:
//       (1) Wenn KeyName im CSP gefunden wird, wird dieser SchlÃ¼ssel verwendet.
//       (2) Wenn KeyName nicht vorhanden ist und KeyFile vorhanden ist, 
//           wird der SchlÃ¼ssel in KeyFile im CSP installiert und verwendet.
//   (*) Um eine KeyFile zu erstellen, kÃ¶nnen Sie das Programm sn.exe (Strong Name) verwenden.
//       Wenn KeyFile angegeben wird, muss der Pfad von KeyFile
//       relativ zum Projektausgabeverzeichnis sein:
//       %Project Directory%\obj\<configuration>. Wenn sich KeyFile z.B.
//       im Projektverzeichnis befindet, geben Sie das AssemblyKeyFile-Attribut 
//       wie folgt an: [assembly: AssemblyKeyFile("..\\..\\mykey.snk")]
//   (*) Das verzÃ¶gern der Signierung ist eine erweiterte Option. Weitere Informationen finden Sie in der
//       Microsoft .NET Framework-Dokumentation.
//
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("")]
[assembly: AssemblyKeyName("")]
