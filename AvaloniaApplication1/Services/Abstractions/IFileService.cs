using CookBook.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Services.Abstractions;
public interface IFileService
{

    /// <summary>
    /// Read file.
    /// </summary>
    /// <param name="path">Path to file</param>
    /// <returns>Content of file</returns>
    string ReadFile(FileInfo file);

    /// <summary>
    /// Write string to file. Rewrite existing file.
    /// </summary>
    /// <param name="directory">Directory in which will be file written</param>
    /// <param name="fileName">File name</param>
    /// <param name="data">New content of file</param>
    /// <returns>FileInfo of file</returns>
    FileInfo WriteFile(DirectoryInfo directory, string fileName, string data);

    /// <summary>
    /// Write string to file. Rewrite existing file.
    /// </summary>
    /// <param name="file">Written file</param>
    /// <param name="data">New content of file</param>
    void WriteFile(FileInfo file, string data);

    /// <summary>
    /// Application directory.
    /// </summary>
    DirectoryInfo GetAppDirectory();

    /// <summary>
    /// Directory with recipe files.
    /// </summary>
    DirectoryInfo GetRecipeDirectory();

    /// <summary>
    /// Add new directoryInfo (and create directory if does not exist)
    /// </summary>
    /// <param name="directory">Existing directory</param>
    /// <param name="name">Name of new directory</param>
    /// <returns></returns>
    DirectoryInfo AddDirectory(DirectoryInfo directory, string name);
}

