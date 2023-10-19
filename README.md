![1](https://github.com/fpaezf/cs2-vpk-map-unpacker/assets/28062918/1286d24d-525e-4874-a6fa-cdcdae794521)

# Counter-Strike 2 VPK map unpacker
MapUnPacker.exe is a console application written in C# to unpack VPK files used in Source 2 engine games like Counter-Strike 2.

Uses **ValvePAK** Nugget package: https://github.com/ValveResourceFormat/ValvePak

Uses .NET 6 runtime: https://dotnet.microsoft.com/es-es/download/dotnet/6.0

# How to use
To unpack files you have to start MapPacker.exe with 2 command line arguments each one enclosed in quotes.
- **#1:** A source vpk file to unpack
- **#2:** A target folder to store the extracted files and folders


**EXAMPLE:**

**MapPacker.exe** "C:\Users\Francesc\Desktop\test.vpk" "C:\Users\Francesc\Downloads\Map Files" 

If you not enclose the parameters in quotes, te application will fail.

![2](https://github.com/fpaezf/cs2-vpk-map-unpacker/assets/28062918/01922e3a-837f-4d1b-a987-68ccee42d954)

Edit the included **MapUnPacker.bat** file to properly work with the application.
