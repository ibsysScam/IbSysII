#!/bin/bash
set -ev

# Build
mkdir testbin
dotnet build Ibsys2/IbSysUnitTests/*.csproj --framework netcoreapp1.0 -o testbin
mkdir publish
dotnet publish build Ibsys2/Ibsys2/*.csproj -o publish