using CookBook.Services.Abstractions;
using CookBook.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Tests;
public class FileServiceTests
{
    IFileService _fileService = new FileService();

    [Fact]
    public void Get_AppDataDirectory_CorrectPath()
    {
        var dir = _fileService.GetAppDirectory();
    }
}

