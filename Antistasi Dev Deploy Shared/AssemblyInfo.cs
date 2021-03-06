﻿using System.Resources;
using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
#if ADD
[assembly: AssemblyTitle("Antistasi Dev Deploy")]
[assembly: AssemblyDescription("Dynamically deploys any map template into mpmissions for testing.")]
#endif
#if ADDB
[assembly: AssemblyTitle("Antistasi Dev Deploy Benchmark")]
[assembly: AssemblyDescription("Tests speed of ADD.")]
#endif
#if ADDC
[assembly: AssemblyTitle("Antistasi Dev Deploy Configurator")]
[assembly: AssemblyDescription("GUI which allows you to edit settings for Antistasi Dev Deploy.")]
#endif
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Caleb S. Serafin")]
[assembly: AssemblyProduct("github.com/CalebSerafin/Arma-3-Dev-Deploy")]
[assembly: AssemblyCopyright("Copyright (c) 2019 Caleb Sebastian Serafin")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("9936a835-0899-4319-9a74-a575a66d8d82")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("4.5.1.0")]
[assembly: NeutralResourcesLanguage("en-ZA")]
