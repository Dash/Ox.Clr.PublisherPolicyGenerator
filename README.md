# Publisher Policy Generator

The purpose of this tool is to generate .NET Publisher Policy Assemblies.  The purpose of these, is to redirect binds to GAC'd assemblies to another version.

 * [Redirecting Assembly Versions (MSDN)](https://docs.microsoft.com/en-us/dotnet/framework/configure-apps/redirect-assembly-versions)
 * [How to: Create a Publisher Policy (MSDN)](https://docs.microsoft.com/en-us/dotnet/framework/configure-apps/how-to-create-a-publisher-policy)

## Example

You have an application that was compiled against version 1.0.0.0 of a shared library.  That library has a bug, and you want to release a fix, version 1.1.0.0

Normally with .NET, you would have to recompile your application to use the new version; this may not be practical due to deployment complexities etc.

Instead you can redirect the bind to a specific version to a different version without having to recompile.  There are a few approaches one can take, this tool is purely for the Publisher Policy approach.

## Requirements

For Publisher Policies to work, your assemblies need to be strong-named and signed.

## Usage

 1. Run this program
 2. Enter the assembly details (name and public key), or browse to any version of the DLL to automatically (and accurately) load that information
 3. Specify the version(s) to redirect _from_.  This can be a single version, or a range, e.g. 1.0.0.0-1.0.0.5
 4. Specify the new version of that calls should be redirected to
 5. Create the policy

The output will be a file named policy.x.x.myAssembly.dll as well as an XML file with the same name.  You can then GAC the dll in the normal fashion to install the policy file.