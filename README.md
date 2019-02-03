Plugin Sample in .Net Core 3
============================

This project shows how to dynamically load and unload assemblies in C# .Net Core SDK 3.0+.

## How to use this sample

1. Make sure to have installed the .NET Core SDK 3.0 or newer. In the time of writing, this is only available as preview.
2. Clone the repository, open the solution, and build the solution
3. Copy the build-output (`/DevTease.Plugins.PluginA/bin/netcoreapp3.0/DevTease.Plugins.PluginA.*`) of the sample application inside `/DevTease.Plugins.Host/PluginFolder/PluginA`
4. Run the DevTease.Plugins.Host application

## Solution structure

### Plugins.Api project

This class library describes the interface that a given plugin can implement and describes
the communication between the host application and plugin code.

### Plugins.Host project

This console application is the main application, that is capable of loading and unloading plugins.
This project contains a folder called "PluginFolder". This is directory, into which previously built plugins can be moved into.

### Plugins.PluginA project

This is a very basic sample plugin, that implements the IPlugin interface from the API project.

## How is this different from a project reference?

Dynamically loading assemblies means, that you can call code in the host application, that didn't exist during the development and shipping of the host application.

Dynamically unloading/reloading means, that you do not have to kill the host application to change parts of it's implementation.

Common examples of when this is really useful include:

- Mod support in games
- Extensions for integrating 

