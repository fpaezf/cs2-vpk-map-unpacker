using SteamDatabase.ValvePak;

//Clear the console
Console.Clear();
Console.ResetColor();

//Maximize console window
//Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

//Write a welcome message
Console.WriteLine("Counter-Strike 2 VPK map unpacker v1.0");
Console.WriteLine("Created by Francesc Pàez (C) 2023");
Console.WriteLine("-------------------------------------------");
Console.WriteLine("Download the latest version on GitHub: https://github.com/fpaezf/cs2-vpk-map-unpacker");
Console.WriteLine("");


if (args.Length == 0)
{         //User has launched the application without arguments, throw a warning message and exit application
    PrintMessage("FAIL:", "No arguments detected!", ConsoleColor.DarkRed);
    Console.WriteLine("");
    Console.WriteLine("Launch this application again but using 2 command line arguments with quotes:");
    Console.WriteLine("MapUnPacker.exe \"c:\\targetfolder\\mymap.vpk\" \"c:\\sourcefolder\\mymap\"");
    Console.WriteLine("");
    Console.WriteLine("Hit a key to exit.");
    Console.ReadKey(true);
    return;
}
else if (args.Length == 1)
{   //User has launched the application with only one argument, throw a warning message and exit application
    PrintMessage("FAIL:", "Only 1 argument detected!", ConsoleColor.DarkRed);
    Console.WriteLine("");
    Console.WriteLine("Launch this application again but using 2 command line arguments with quotes:");
    Console.WriteLine("MapUnPacker.exe \"c:\\targetfolder\\mymap.vpk\" \"c:\\sourcefolder\\mymap\"");
    Console.WriteLine("");
    Console.WriteLine("Hit a key to exit.");
    Console.ReadKey(true);
    return;
}
else if (args.Length == 2)
{   //User has launched the application with 2 arguments, show pass message and continue
    PrintMessage("Source file:", args[0], ConsoleColor.DarkYellow);
    PrintMessage("Target directory:", args[1], ConsoleColor.DarkYellow);
    Console.WriteLine("");

    if (File.Exists(args[0]))
    { //Check if provided file exists and if so, show a pass message and continue
        PrintMessage("PASS:", "Source file is accesible.", ConsoleColor.DarkGreen);
    }
    else if (!File.Exists(args[0]))
    { //If source folder not exists, show a warning message and exit
        PrintMessage("FAIL:", "Source file is not accesible.", ConsoleColor.DarkRed);       
        Console.WriteLine("");
        Console.WriteLine("Hit a key to exit.");
        Console.ReadKey(true);
        return;
    }


    if (Directory.Exists(args[1]))
    {
        PrintMessage("PASS:", "Target directory is accesible.", ConsoleColor.DarkGreen);
        
    } else if (!Directory.Exists(args[1]))
    {
        PrintMessage("FAIL:", "Target directory not exists.", ConsoleColor.DarkRed);   
        try
        {
            Directory.CreateDirectory(args[1]);
            PrintMessage("WORK:", "Target directory created succesfully.", ConsoleColor.Blue);
        }
        catch (Exception e)
        {
            PrintMessage("FAIL:", "Can't create target directory.", ConsoleColor.DarkRed);
            Console.WriteLine("");
            Console.WriteLine("Hit a key to exit.");
            Console.ReadKey(true);
            return;
        }
    }

    string VPKFile = args[0];
    

    PrintMessage("WORK:", "Unpacking files and folders...", ConsoleColor.Blue);
    try
    {
        var mapPackage = new Package();
        mapPackage.Read(VPKFile);
        ExtractPackage(mapPackage);//Call the unpack folder routine
        mapPackage.Dispose();
        PrintMessage("PASS:", "All files were extracted!", ConsoleColor.DarkGreen);
        Console.WriteLine("");
        Console.WriteLine("Hit a key to exit.");
        Console.ReadKey(true);
        return;
    }
    catch (Exception ex)
    {
        PrintMessage("FAIL:", "Error extracting files!", ConsoleColor.DarkRed);
        Console.WriteLine("");
        Console.WriteLine("Hit a key to exit.");
        Console.ReadKey(true);
        return;
    }

    
}

void ExtractPackage(Package package)
{
    var inPackageSet = new HashSet<string>();
    try 
    {        
        foreach (var entries in package.Entries.Values)
        {
            foreach (var entry in entries)
            {
                var filePath = entry.GetFullPath();
                inPackageSet.Add(filePath);
                var extractFilePath = Path.Combine(args[1], filePath);
                Directory.CreateDirectory(Path.GetDirectoryName(extractFilePath)!);
                package.ReadEntry(entry, out var data);
                File.WriteAllBytes(extractFilePath, data);
            }
        }
    }
    catch (Exception a)
    {
        PrintMessage("FAIL:", "Error extracting files!", ConsoleColor.DarkRed);
        Console.WriteLine("");
        Console.WriteLine("Hit a key to exit.");
        Console.ReadKey(true);
        return;
    }
}

void PrintMessage(string Head, string Message, ConsoleColor Color) {
    Console.BackgroundColor = Color;
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(Head);
    Console.ResetColor();
    Console.Write(" " + Message);
    Console.WriteLine("");
}