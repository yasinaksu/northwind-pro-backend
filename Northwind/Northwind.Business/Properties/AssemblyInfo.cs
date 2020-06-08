﻿using Core.Aspects.PostSharp.LogAspects;
using Core.Aspects.PostSharp.ValidationAspects;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Northwind.Business.ValidationRules.FluentValidation;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Northwind.Business")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Northwind.Business")]
[assembly: AssemblyCopyright("Copyright ©  2020")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("8c7447b0-8a0d-43be-b4eb-31e85af87ddc")]

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
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

//Aspects
[assembly: LogAspect(typeof(DatabaseLogger), AttributeTargetTypes = "Northwind.Business.Concrete.Managers.*")]
//[assembly: FluentValidationAspect(typeof(ProductValidator),AttributeTargetTypes = "Northwind.Business.Concrete.Managers.ProductManager*Add*")]

