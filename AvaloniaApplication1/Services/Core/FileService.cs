using CookBook.Services.Abstractions;
using System;
using System.IO;
using System.Text;

namespace CookBook.Services.Core;
public class FileService : IFileService
{
    private const string APP_NAME = "CookBook";
    private const string RECIPES_DIR_NAME = "recipes";

    public string ReadFile(FileInfo file)
    {
        using var stream = file.OpenText();
        var data = stream.ReadToEnd();
        return data;
    }

    public FileInfo WriteFile(DirectoryInfo directory, string fileName, string data)
    {
        FileInfo fileInfo = new FileInfo(Path.Combine(directory.FullName, fileName));
        WriteFile(fileInfo, data);
        return fileInfo;
    }

    public void WriteFile(FileInfo file, string data)
    {
        byte[] bytes = Encoding.ASCII.GetBytes(data);
        using FileStream stream = file.OpenWrite();
        stream.Write(bytes, 0, bytes.Length);
        file.Refresh();
    }

    public DirectoryInfo GetAppDirectory()
    {
        string basePath;

        if (OperatingSystem.IsWindows())
        {
            basePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }
        else if (OperatingSystem.IsLinux() || OperatingSystem.IsMacOS())
        {
            basePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }
        else
        {
            throw new PlatformNotSupportedException();
        }

        string appDataPath = Path.Combine(basePath, APP_NAME);
        return Directory.CreateDirectory(appDataPath);
    }

    public DirectoryInfo GetRecipeDirectory()
    {
        var appDir = GetAppDirectory();
        return AddDirectory(appDir, RECIPES_DIR_NAME);
    }

    public DirectoryInfo AddDirectory(DirectoryInfo directory, string name)
    {
        if (directory.Exists is false)
        {
            throw new DirectoryNotFoundException();
        }

        string newDirPath = Path.Combine(directory.FullName, name);
        return Directory.CreateDirectory(newDirPath);
    }
}

